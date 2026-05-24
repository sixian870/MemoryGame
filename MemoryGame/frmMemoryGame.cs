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
using System.Text;

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

        // 用來記錄每個獨立播放軌道的 ID
        int soundIdCounter = 0;
        // 用來記錄釋放後的實體音檔路徑
        Dictionary<string, string> soundPathCache = new Dictionary<string, string>();

        public frmMemoryGame()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            StartLevel(1);
        }

        /// <summary>
        /// 核心方法：初始化並啟動指定關卡
        /// </summary>
        private void StartLevel(int level)
        {
            currentLevel = level;
            firstClick = null;
            secondClick = null;
            lockClick = false;

            // 目前關卡亮起，其餘變灰
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
            int rows = 4, cols = 4;
            if (level == 1) { rows = 4; cols = 4; maxTime = 120; }       // 4x4 限時 120 秒
            else if (level == 2) { rows = 6; cols = 6; maxTime = 300; }  // 6x6 限時 300 秒
            else if (level == 3) { rows = 8; cols = 8; maxTime = 900; }  // 8x8 限時 900 秒
            else if (level == 4) { rows = 10; cols = 10; maxTime = 0; }  // 10x10 正向計時

            remainingPairs = (rows * cols) / 2;

            // 設定計時模式與介面文字
            if (level == 4)
            {
                timeLeft = 0; // 從 0 秒開始正向計時
                timeBar.Maximum = 1500;
                timeBar.Value = 0; // 隱藏關進度條全滿當裝飾
                lblTime.Text = "⏱️ 已用時間：";
                lblRemaining.Text = $"剩餘：{remainingPairs} 未配對";
                this.Text = "終極隱藏關卡";

            }
            else
            {
                timeLeft = maxTime;
                timeBar.Maximum = maxTime;
                timeBar.Value = maxTime;
                lblTime.Text = "⏱️ 剩餘時間：";
                lblRemaining.Text = $"剩餘: {remainingPairs} 未配對";
            }

            // 清空舊的畫面與資料
            gamePanel.Controls.Clear();
            gamePanel.RowStyles.Clear();
            gamePanel.ColumnStyles.Clear();
            pics.Clear();
            images.Clear();

            // 網格
            gamePanel.RowCount = rows;
            gamePanel.ColumnCount = cols;
            for (int i = 0; i < rows; i++) gamePanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100f / rows));
            for (int i = 0; i < cols; i++) gamePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f / cols));

            // 隨機打亂 1~50 的數字，確保每場抽到的牌種類不重複
            List<int> imgIndexes = Enumerable.Range(1, 50).ToList();
            Random rand = new Random();
            imgIndexes = imgIndexes.OrderBy(x => rand.Next()).ToList();

            for (int i = 0; i < remainingPairs; i++)
            {
                // 根據隨機排序的數字，抓取 card_X
                string resName = "card_" + imgIndexes[i];
                Image img = (Image)Properties.Resources.ResourceManager.GetObject(resName);
                if (img != null)
                {
                    images.Add(img);
                }
            }
            images.AddRange(images); // 複製一份，達成兩兩配對

            // 產生 PictureBox 加入網格
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    PictureBox p = new PictureBox();
                    p.Dock = DockStyle.Fill;
                    p.SizeMode = PictureBoxSizeMode.Zoom;
                    p.Image = BackImage;
                    p.Margin = new Padding(4);
                    p.Click += pic_Click; // 綁定點擊事件

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

            // 啟動計時器
            timer1.Interval = 1000;
            timer1.Start();
        }

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

        // 延遲一秒
        private void timer2_Tick(object sender, EventArgs e)
        {
            timer2.Stop();

            firstClick.Image = BackImage;
            secondClick.Image = BackImage;

            firstClick = null;
            secondClick = null;
            lockClick = false;
        }

        // 倒數與正數
        private void timer1_Tick(object sender, EventArgs e)
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
                MessageBox.Show("⏰ 時間到！挑戰失敗，再試一次吧！", "遊戲結束");
                StartLevel(currentLevel); // 失敗則重來本關
            }
        }

        private void CheckWin()
        {
            if (remainingPairs == 0)
            {
                timer1.Stop();

                if (currentLevel == 1 || currentLevel == 2)
                {
                    PlaySound("next_level");
                    MessageBox.Show($"恭喜通過第 {currentLevel} 關！準備挑戰下一關！", "過關成功");

                    currentLevel++;
                    StartLevel(currentLevel); // 自動載入下一關
                }
                else if (currentLevel == 3)
                {
                    // 如果剩餘時間大於 200 秒，觸發隱藏關卡！
                    if (timeLeft > 200)
                    {
                        PlaySound("next_level");

                        DialogResult result = MessageBox.Show(
                            $"驚人速通！你竟然還剩餘 {timeLeft} 秒！\n\n是否接受終極隱藏關卡 (10 x 10) 的挑戰？",
                            "⚡ 隱藏挑戰觸發 ⚡",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Warning
                        );

                        if (result == DialogResult.Yes)
                        {
                            StartLevel(4); // 載入隱藏關卡
                        }
                        else
                        {
                            PlaySound("game_clear");
                            MessageBox.Show("太強了！你成功完成挑戰，完美破關！", "遊戲結束");
                        }
                    }
                    else
                    {
                        PlaySound("game_clear");
                        MessageBox.Show("恭喜你完美通關！", "遊戲結束");
                    }
                }
                else if (currentLevel == 4)
                {
                    PlaySound("game_clear");
                    MessageBox.Show($"神之操作！你成功征服了 10 x 10 終極隱藏關卡！\n總共花費時間：{timeLeft} 秒！你就是記憶之王！", "神話誕生");
                }
            }
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            this.Text = "記憶翻牌小遊戲";
            StartLevel(1); // 重新從第一關開始挑戰
        }

        private void PlaySound(string soundName)
        {
            try
            {
                string filePath = "";

                // 如果這個音檔還沒有被釋放到暫存區，先執行一次釋放
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
                    soundIdCounter++;
                    string alias = $"{soundName}_{soundIdCounter}";
                    mciSendString($"open \"{filePath}\" type waveaudio alias {alias}", null, 0, IntPtr.Zero);
                    mciSendString($"play {alias} from 0", null, 0, IntPtr.Zero);
                }
            }
            catch (Exception)
            {
                // 確保音效不崩潰
            }
        }

        private void frmMemoryGame_FormClosing(object sender, FormClosingEventArgs e)
        {
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
    }
}
