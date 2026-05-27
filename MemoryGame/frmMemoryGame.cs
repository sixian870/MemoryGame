using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MemoryGame
{
    public partial class frmMemoryGame : Form
    {
        List<PictureBox> pics = new List<PictureBox>();
        List<Image> images = new List<Image>();
        PictureBox firstClick = null;
        PictureBox secondClick = null;
        bool lockClick = false;

        int currentLevel = 1;      // 目前關卡：1=4x4, 2=6x6, 3=8x8, 4=10x10隱藏關
        int remainingPairs = 0;    // 剩餘未配對的對數
        int timeLeft = 0;          // 時間紀錄器（1~3關倒數，第4關正數）
        int maxTime = 0;           // 本關總時間 (秒)

        private Image BackImage = Properties.Resources.card_back;

        [System.Runtime.InteropServices.DllImport("winmm.dll")]

        private static extern long mciSendString(string strCommand, StringBuilder strReturn, int iReturnLength, IntPtr hwndCallback);

        Dictionary<string, string> soundPathCache = new Dictionary<string, string>();

        private Timer peekTimer = new Timer();

        public frmMemoryGame()
        {
            InitializeComponent();
            peekTimer.Interval = 1000;
            peekTimer.Tick += PeekTimer_Tick;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            PreloadAllSounds(new string[] { "click_flip", "match_success", "match_fail", "next_level", "game_fail", "surprise", "game_clear" });
            pnlWelcome.BringToFront();
            pnlWelcome.Visible = true;
            pnlGameOver.Visible = false;

        }

        private void btnStartGame_Click(object sender, EventArgs e)
        {
            PlaySound("click_flip");
            pnlWelcome.Visible = false;
            StartLevel(1);
        }

        #region 關卡設定
        private void StartLevel(int level)
        {
            currentLevel = level;
            firstClick = null;
            secondClick = null;
            lockClick = true;

            timer1.Stop();
            timer2.Stop();
            peekTimer.Stop();

            int rows = 4, cols = 4;
            if (level == 4)
            {
                rows = 10; cols = 10;

                this.BackColor = Color.RosyBrown;
                pnlGame.BackColor = Color.RosyBrown;
                gamePanel.BackColor = Color.RosyBrown;

                btnLv1.Visible = false;
                btnLv3.Visible = false;
                btnLv2.Enabled = true;
                btnLv2.Text = "終極隱藏關卡";

                btnLv2.ForeColor = Color.White;
                btnLv2.BackColor = Color.Maroon;
                btnRestart.BackColor = Color.Maroon;
                btnRestart.ForeColor = Color.White;

                lblRemaining.ForeColor = Color.Maroon;
                lbls.ForeColor = Color.Maroon;
                lblTime.ForeColor = Color.Maroon;

                // 進度條 紅色,正向計時
                timeLeft = 0;
                timeBar.Maximum = 1800;
                timeBar.Value = 1;
                timeBar.Value = 0;
                try { NativeMethods.SendMessage(timeBar.Handle, 0x410, (IntPtr)2, IntPtr.Zero); } catch { }

                lblTime.Text = "⏱️ 已用時間：";
                this.Text = "💀 終極隱藏關卡 💀";
            }
            else
            {
                this.BackColor = Color.Honeydew;
                pnlGame.BackColor = Color.Honeydew;
                gamePanel.BackColor = Color.Honeydew;

                lblRemaining.ForeColor = Color.Black;
                lbls.ForeColor = Color.Black;
                lblTime.ForeColor = Color.Black;

                btnRestart.BackColor = Color.DarkSeaGreen;
                btnRestart.ForeColor = Color.White;

                btnLv1.Visible = true;
                btnLv3.Visible = true;
                btnLv2.Text = "▶️ 第二關 6x6";

                btnLv1.Enabled = (level == 1);
                btnLv2.Enabled = (level == 2);
                btnLv3.Enabled = (level == 3);

                btnLv1.BackColor = (level == 1) ? Color.DarkSeaGreen : Color.LightGray;
                btnLv2.BackColor = (level == 2) ? Color.DarkSeaGreen : Color.LightGray;
                btnLv3.BackColor = (level == 3) ? Color.DarkSeaGreen : Color.LightGray;

                btnLv1.ForeColor = (level == 1) ? Color.White : Color.Black;
                btnLv2.ForeColor = (level == 2) ? Color.White : Color.Black;
                btnLv3.ForeColor = (level == 3) ? Color.White : Color.Black;

                // 依關卡決定網格大小與限時
                if (level == 1) { rows = 4; cols = 4; maxTime = 120; }
                else if (level == 2) { rows = 6; cols = 6; maxTime = 300; }
                else if (level == 3) { rows = 8; cols = 8; maxTime = 900; }

                timeLeft = maxTime;
                timeBar.Maximum = maxTime;
                timeBar.Value = maxTime;

                // 發送底層訊息，還原綠色進度條
                try { NativeMethods.SendMessage(timeBar.Handle, 0x410, (IntPtr)1, IntPtr.Zero); } catch { }

                lblTime.Text = "⏱️ 剩餘時間：";
                this.Text = "記憶翻牌小遊戲";
            }

            remainingPairs = (rows * cols) / 2;
            lblRemaining.Text = $"剩餘: {remainingPairs} 未配對";

            // 清空舊的畫面與網格配置
            gamePanel.Controls.Clear();
            gamePanel.RowStyles.Clear();
            gamePanel.ColumnStyles.Clear();
            pics.Clear();
            images.Clear();

            gamePanel.SuspendLayout();

            gamePanel.RowCount = rows;
            gamePanel.ColumnCount = cols;
            for (int i = 0; i < rows; i++) gamePanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100f / rows));
            for (int i = 0; i < cols; i++) gamePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f / cols));

            List<int> imgIndexes = Enumerable.Range(1, 50).ToList();
            Random rand = new Random();
            imgIndexes = imgIndexes.OrderBy(x => rand.Next()).ToList();

            for (int i = 0; i < remainingPairs; i++)
            {
                string resName = "card_" + imgIndexes[i];
                Image img = (Image)Properties.Resources.ResourceManager.GetObject(resName);
                if (img != null) images.Add(img);
            }
            images.AddRange(images); // 複製一份

            // 產生 PictureBox 並塞入網格
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    PictureBox p = new PictureBox();
                    p.Dock = DockStyle.Fill;
                    p.SizeMode = PictureBoxSizeMode.Zoom;
                    p.Image = BackImage;
                    p.Margin = new Padding(4);
                    p.Click += pic_Click;

                    pics.Add(p);
                    gamePanel.Controls.Add(p, c, r);
                }
            }

            // 洗牌
            Random rd = new Random();
            foreach (PictureBox p in pics)
            {
                int index = rd.Next(images.Count);
                p.Tag = images[index];
                images.RemoveAt(index);
            }

            foreach (PictureBox p in pics)
            {
                p.Image = (Image)p.Tag; // 強制顯示正面
            }

            gamePanel.ResumeLayout(true);

            peekTimer.Start();
        }
        #endregion

        private void PeekTimer_Tick(object sender, EventArgs e)
        {
            peekTimer.Stop();
            foreach (PictureBox p in pics)
            {
                p.Image = BackImage; // 全部翻回去
            }
            lockClick = false;
            timer1.Interval = 1500;
            timer1.Start(); // 啟動計時時鐘
        }

        #region 點擊規則
        private void pic_Click(object sender, EventArgs e)
        {
            PictureBox pic = sender as PictureBox;

            if (lockClick) return;
            if (pic.Image != BackImage) return; // 已翻開的不能再點

            PlaySound("click_flip"); // 翻牌點擊音效

            if (firstClick == null)
            {
                firstClick = pic;
                pic.Image = (Image)pic.Tag;
                return;
            }

            secondClick = pic;
            pic.Image = (Image)pic.Tag;

            // 比對兩張牌的 Tag
            if (firstClick.Tag != secondClick.Tag)
            {
                lockClick = true;
                PlaySound("match_fail"); // 配對失敗音效
                timer2.Interval = 1000; // 延遲 1 秒翻回
                timer2.Start();
            }
            else
            {
                // 配對成功！
                firstClick.Click -= pic_Click;
                secondClick.Click -= pic_Click;

                remainingPairs--;
                lblRemaining.Text = $"剩餘: {remainingPairs} 未配對";
                PlaySound("match_success"); // 配對成功音效

                firstClick = null;
                secondClick = null;

                CheckWin();
            }
        }
        #endregion

        #region 計時器
        // 延遲一秒
        private void timer2_Tick(object sender, EventArgs e)
        {
            timer2.Stop();

            if (firstClick != null) firstClick.Image = BackImage;
            if (secondClick != null) secondClick.Image = BackImage;

            firstClick = null;
            secondClick = null;
            lockClick = false;
        }

        // 倒數與正數
        private  void timer1_Tick(object sender, EventArgs e)
        {
            if (currentLevel == 4)
            {
                timeLeft++;
                lbls.Text = $"{timeLeft} 秒";
                timeBar.Value = Math.Min(timeLeft, timeBar.Maximum);
                return;
            }

            timeLeft--;
            if (timeLeft >= 0)
            {
                timeBar.Value = timeLeft; // 倒數線縮短
                lbls.Text = $"{timeLeft} 秒";
            }

            if (timeLeft <= 0)
            {
                timer1.Stop();
                lockClick = true;
                PlaySound("game_fail");
                MessageBox.Show("⏰ 時間到！挑戰失敗，再試一次吧！", "遊戲結束");
                StartLevel(currentLevel); // 失敗則重來本關
            }
        }
        #endregion

        #region 檢查贏
        private async void CheckWin()
        {
            if (remainingPairs == 0)
            {
                timer1.Stop();

                if (currentLevel == 1 || currentLevel == 2)
                {
                    await Task.Delay(1000);
                    PlaySound("next_level");
                    MessageBox.Show($"恭喜通過第 {currentLevel} 關！準備挑戰下一關！", "過關成功");

                    currentLevel++;
                    StartLevel(currentLevel); // 自動載入下一關
                }
                else if (currentLevel == 3)
                {
                    await Task.Delay(1000);

                    // 如果剩餘時間大於 200 秒，觸發隱藏關卡！
                    if (timeLeft > 200)
                    {
                        PlaySound("surprise");
                        ShowEndGamePanel(true, $"恭喜通關成功！\n總剩餘時間：{timeLeft} 秒\n榮譽稱號：【🏆 傳奇記憶大師】\n\n是否接受終極隱藏關卡 (10 x 10) 的挑戰？", allowSecret: true);
                    }
                    else
                    {
                        PlaySound("game_clear");
                        ShowEndGamePanel(true, $"恭喜通關成功！\n總剩餘時間：{timeLeft} 秒\n榮譽稱號：【🎖️ 高級記憶精英】\n\n(※ 提示：通關剩餘時間大於 200 秒能開啟隱藏關卡喔！)", allowSecret: false);
                    }
                }
                else if (currentLevel == 4)
                {
                    await Task.Delay(1000);
                    PlaySound("game_clear");
                    ShowEndGamePanel(true, $"👑 神之操作！\n你成功征服了 10 x 10 終極魔王隱藏關卡！\n總共花費時間：{timeLeft} 秒！\n榮譽稱號：【宇宙級·過目不忘真神】", allowSecret: false);
                }
            }
        }
        #endregion

        private void btnRestart_Click(object sender, EventArgs e)
        {
            pnlWelcome.Visible = false;
            pnlGameOver.Visible = false;
            this.Text = "記憶翻牌小遊戲";
            StartLevel(1);
        }

        #region 結束介面
        private void ShowEndGamePanel(bool isWin, string message, bool allowSecret = false)
        {
            pnlGameOver.BringToFront(); // 移到最上層
            pnlGameOver.Visible = true;

            lblOverTitle.Text = "🏆CHALLENGE CLEAR!🏆\n通關成功";
            lblOverTitle.ForeColor = Color.White;
            pnlGameOver.BackColor = Color.LightBlue;

            lblOverResult.Text = message;

            btnOverExit.Visible = true;
            btnOverRetry.Visible = true;
            btnOverSecret.Visible = allowSecret; // 只有達成特殊條件的常規大結局才會亮起！
        }

        private void btnOverExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnOverRetry_Click(object sender, EventArgs e)
        {
            pnlGameOver.Visible = false;
            this.Text = "記憶翻牌小遊戲";
            StartLevel(1);
        }

        private void btnOverSecret_Click(object sender, EventArgs e)
        {
            pnlGameOver.Visible = false;
            StartLevel(4);
        }
        #endregion

        #region 音檔
        private void PlaySound(string soundName)
        {
            try
            {
                string filePath = "";
                if (!soundPathCache.ContainsKey(soundName))
                {
                    byte[] soundBytes = null;
                    System.IO.Stream str = (System.IO.Stream)Properties.Resources.ResourceManager.GetObject(soundName);
                    if (str != null)
                    {
                        using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                        {
                            str.CopyTo(ms);
                            soundBytes = ms.ToArray();
                        }
                    }

                    if (soundBytes != null)
                    {
                        string tempPath = System.IO.Path.Combine(System.IO.Path.GetTempPath(), soundName + "_" + this.GetHashCode() + ".wav");
                        System.IO.File.WriteAllBytes(tempPath, soundBytes);
                        soundPathCache[soundName] = tempPath;
                    }
                }

                if (soundPathCache.TryGetValue(soundName, out filePath))
                {
                    mciSendString($"close {soundName}", null, 0, IntPtr.Zero);
                    mciSendString($"open \"{filePath}\" type waveaudio alias {soundName}", null, 0, IntPtr.Zero);
                    mciSendString($"play {soundName} from 0", null, 0, IntPtr.Zero);
                }
            }
            catch (Exception)
            {
                // 確保音效不崩潰
            }
        }

        private void PreloadAllSounds(string[] soundNames)
        {
            foreach (string name in soundNames)
            {
                try
                {
                    if (!soundPathCache.ContainsKey(name))
                    {
                        byte[] soundBytes = null;
                        System.IO.Stream str = (System.IO.Stream)Properties.Resources.ResourceManager.GetObject(name);
                        if (str != null)
                        {
                            using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                            {
                                str.CopyTo(ms);
                                soundBytes = ms.ToArray();
                            }
                        }

                        if (soundBytes != null)
                        {
                            string tempPath = System.IO.Path.Combine(System.IO.Path.GetTempPath(), name + "_" + this.GetHashCode() + ".wav");
                            System.IO.File.WriteAllBytes(tempPath, soundBytes);
                            soundPathCache[name] = tempPath;
                        }
                    }
                }
                catch { }
            }

        }
        #endregion

        #region 關閉視窗
        private void frmMemoryGame_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (var soundName in soundPathCache.Keys)
            {
                try { mciSendString($"close {soundName}", null, 0, IntPtr.Zero); } catch { }
            }

            // 遊戲關閉時把暫存的音檔砍掉
            foreach (var path in soundPathCache.Values)
            {
                try
                {
                    if (System.IO.File.Exists(path))
                    {
                        System.IO.File.Delete(path);
                    }
                }
                catch { }
            }
        }
        #endregion

        #region 修改進度條顏色的底層方法
        public static class NativeMethods
        {
            [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]

            public static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wparam, IntPtr lparam);
        }
        #endregion
    }
}