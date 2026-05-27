namespace MemoryGame
{
    partial class frmMemoryGame
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pnlGame = new System.Windows.Forms.Panel();
            this.lbls = new System.Windows.Forms.Label();
            this.lblRemaining = new System.Windows.Forms.Label();
            this.timeBar = new System.Windows.Forms.ProgressBar();
            this.lblTime = new System.Windows.Forms.Label();
            this.btnLv3 = new System.Windows.Forms.Button();
            this.btnLv2 = new System.Windows.Forms.Button();
            this.btnLv1 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.gamePanel = new System.Windows.Forms.TableLayoutPanel();
            this.btnRestart = new System.Windows.Forms.Button();
            this.pnlWelcome = new System.Windows.Forms.Panel();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.lblRule1 = new System.Windows.Forms.Label();
            this.lblRule2 = new System.Windows.Forms.Label();
            this.btnStartGame = new System.Windows.Forms.Button();
            this.pnlGameOver = new System.Windows.Forms.Panel();
            this.lblOverTitle = new System.Windows.Forms.Label();
            this.lblOverResult = new System.Windows.Forms.Label();
            this.btnOverExit = new System.Windows.Forms.Button();
            this.btnOverRetry = new System.Windows.Forms.Button();
            this.btnOverSecret = new System.Windows.Forms.Button();
            this.pnlGame.SuspendLayout();
            this.pnlWelcome.SuspendLayout();
            this.pnlGameOver.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlGame
            // 
            this.pnlGame.BackColor = System.Drawing.Color.Honeydew;
            this.pnlGame.Controls.Add(this.btnRestart);
            this.pnlGame.Controls.Add(this.gamePanel);
            this.pnlGame.Controls.Add(this.lbls);
            this.pnlGame.Controls.Add(this.lblRemaining);
            this.pnlGame.Controls.Add(this.timeBar);
            this.pnlGame.Controls.Add(this.lblTime);
            this.pnlGame.Controls.Add(this.btnLv3);
            this.pnlGame.Controls.Add(this.btnLv2);
            this.pnlGame.Controls.Add(this.btnLv1);
            this.pnlGame.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGame.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.pnlGame.Location = new System.Drawing.Point(0, 0);
            this.pnlGame.Margin = new System.Windows.Forms.Padding(4);
            this.pnlGame.Name = "pnlGame";
            this.pnlGame.Size = new System.Drawing.Size(543, 612);
            this.pnlGame.TabIndex = 0;
            // 
            // lbls
            // 
            this.lbls.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbls.AutoSize = true;
            this.lbls.Location = new System.Drawing.Point(474, 46);
            this.lbls.Name = "lbls";
            this.lbls.Size = new System.Drawing.Size(29, 16);
            this.lbls.TabIndex = 6;
            this.lbls.Text = "--秒";
            this.lbls.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblRemaining
            // 
            this.lblRemaining.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblRemaining.AutoSize = true;
            this.lblRemaining.Location = new System.Drawing.Point(430, 20);
            this.lblRemaining.Name = "lblRemaining";
            this.lblRemaining.Size = new System.Drawing.Size(98, 16);
            this.lblRemaining.TabIndex = 5;
            this.lblRemaining.Text = "剩餘未配對: -- 對";
            // 
            // timeBar
            // 
            this.timeBar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.timeBar.ForeColor = System.Drawing.Color.PaleGoldenrod;
            this.timeBar.Location = new System.Drawing.Point(98, 49);
            this.timeBar.Name = "timeBar";
            this.timeBar.Size = new System.Drawing.Size(369, 10);
            this.timeBar.TabIndex = 4;
            // 
            // lblTime
            // 
            this.lblTime.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new System.Drawing.Point(13, 46);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(81, 16);
            this.lblTime.TabIndex = 3;
            this.lblTime.Text = "⏰剩餘時間 : ";
            // 
            // btnLv3
            // 
            this.btnLv3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnLv3.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnLv3.ForeColor = System.Drawing.SystemColors.Window;
            this.btnLv3.Location = new System.Drawing.Point(321, 11);
            this.btnLv3.Margin = new System.Windows.Forms.Padding(4);
            this.btnLv3.Name = "btnLv3";
            this.btnLv3.Size = new System.Drawing.Size(100, 31);
            this.btnLv3.TabIndex = 2;
            this.btnLv3.Text = "🚩第三關 8x8";
            this.btnLv3.UseVisualStyleBackColor = false;
            // 
            // btnLv2
            // 
            this.btnLv2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnLv2.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnLv2.ForeColor = System.Drawing.SystemColors.Window;
            this.btnLv2.Location = new System.Drawing.Point(210, 11);
            this.btnLv2.Margin = new System.Windows.Forms.Padding(4);
            this.btnLv2.Name = "btnLv2";
            this.btnLv2.Size = new System.Drawing.Size(100, 31);
            this.btnLv2.TabIndex = 1;
            this.btnLv2.Text = "🚩第二關 6x6";
            this.btnLv2.UseVisualStyleBackColor = false;
            // 
            // btnLv1
            // 
            this.btnLv1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnLv1.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnLv1.ForeColor = System.Drawing.SystemColors.Window;
            this.btnLv1.Location = new System.Drawing.Point(99, 11);
            this.btnLv1.Margin = new System.Windows.Forms.Padding(4);
            this.btnLv1.Name = "btnLv1";
            this.btnLv1.Size = new System.Drawing.Size(100, 31);
            this.btnLv1.TabIndex = 0;
            this.btnLv1.Text = "🚩第一關 4x4";
            this.btnLv1.UseVisualStyleBackColor = false;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 1000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // gamePanel
            // 
            this.gamePanel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.gamePanel.ColumnCount = 2;
            this.gamePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.gamePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.gamePanel.Location = new System.Drawing.Point(16, 64);
            this.gamePanel.MinimumSize = new System.Drawing.Size(500, 500);
            this.gamePanel.Name = "gamePanel";
            this.gamePanel.RowCount = 2;
            this.gamePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.gamePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.gamePanel.Size = new System.Drawing.Size(510, 510);
            this.gamePanel.TabIndex = 7;
            // 
            // btnRestart
            // 
            this.btnRestart.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnRestart.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnRestart.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnRestart.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnRestart.Location = new System.Drawing.Point(221, 574);
            this.btnRestart.Margin = new System.Windows.Forms.Padding(4);
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size(100, 31);
            this.btnRestart.TabIndex = 8;
            this.btnRestart.Text = "重新開始";
            this.btnRestart.UseVisualStyleBackColor = false;
            this.btnRestart.Click += new System.EventHandler(this.btnRestart_Click);
            // 
            // pnlWelcome
            // 
            this.pnlWelcome.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.pnlWelcome.Controls.Add(this.btnStartGame);
            this.pnlWelcome.Controls.Add(this.lblRule2);
            this.pnlWelcome.Controls.Add(this.lblRule1);
            this.pnlWelcome.Controls.Add(this.lblWelcome);
            this.pnlWelcome.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlWelcome.Location = new System.Drawing.Point(0, 0);
            this.pnlWelcome.Name = "pnlWelcome";
            this.pnlWelcome.Size = new System.Drawing.Size(543, 612);
            this.pnlWelcome.TabIndex = 9;
            // 
            // lblWelcome
            // 
            this.lblWelcome.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("微軟正黑體", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblWelcome.ForeColor = System.Drawing.SystemColors.Window;
            this.lblWelcome.Location = new System.Drawing.Point(90, 123);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(371, 47);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "歡迎來到記憶大挑戰!";
            // 
            // lblRule1
            // 
            this.lblRule1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblRule1.AutoSize = true;
            this.lblRule1.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblRule1.ForeColor = System.Drawing.SystemColors.Window;
            this.lblRule1.Location = new System.Drawing.Point(100, 206);
            this.lblRule1.Name = "lblRule1";
            this.lblRule1.Size = new System.Drawing.Size(101, 26);
            this.lblRule1.TabIndex = 1;
            this.lblRule1.Text = "遊戲規則:";
            // 
            // lblRule2
            // 
            this.lblRule2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblRule2.AutoSize = true;
            this.lblRule2.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblRule2.ForeColor = System.Drawing.SystemColors.Window;
            this.lblRule2.Location = new System.Drawing.Point(102, 243);
            this.lblRule2.Name = "lblRule2";
            this.lblRule2.Size = new System.Drawing.Size(348, 126);
            this.lblRule2.TabIndex = 2;
            this.lblRule2.Text = "1. 遊戲採通關制，需照順序挑戰。\r\n2. 每關開始前提供1秒的記憶時間。\r\n3. 若當前關卡挑戰失敗會從當前關卡重新開始，\r\n     若要重第一關開始請按遊戲" +
    "下方按鈕；\r\n     若要結束遊戲請按右上角的 X。\r\n4. 第三關遊戲用時可能影響遊戲結局喔 !";
            // 
            // btnStartGame
            // 
            this.btnStartGame.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnStartGame.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnStartGame.ForeColor = System.Drawing.Color.DarkSeaGreen;
            this.btnStartGame.Location = new System.Drawing.Point(186, 419);
            this.btnStartGame.Name = "btnStartGame";
            this.btnStartGame.Size = new System.Drawing.Size(163, 55);
            this.btnStartGame.TabIndex = 3;
            this.btnStartGame.Text = "開始遊戲";
            this.btnStartGame.UseVisualStyleBackColor = true;
            this.btnStartGame.Click += new System.EventHandler(this.btnStartGame_Click);
            // 
            // pnlGameOver
            // 
            this.pnlGameOver.BackColor = System.Drawing.Color.LightBlue;
            this.pnlGameOver.Controls.Add(this.btnOverSecret);
            this.pnlGameOver.Controls.Add(this.btnOverRetry);
            this.pnlGameOver.Controls.Add(this.btnOverExit);
            this.pnlGameOver.Controls.Add(this.lblOverResult);
            this.pnlGameOver.Controls.Add(this.lblOverTitle);
            this.pnlGameOver.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGameOver.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.pnlGameOver.Location = new System.Drawing.Point(0, 0);
            this.pnlGameOver.Name = "pnlGameOver";
            this.pnlGameOver.Size = new System.Drawing.Size(543, 612);
            this.pnlGameOver.TabIndex = 1;
            this.pnlGameOver.Visible = false;
            // 
            // lblOverTitle
            // 
            this.lblOverTitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblOverTitle.Font = new System.Drawing.Font("微軟正黑體", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblOverTitle.ForeColor = System.Drawing.SystemColors.Window;
            this.lblOverTitle.Location = new System.Drawing.Point(29, 47);
            this.lblOverTitle.Name = "lblOverTitle";
            this.lblOverTitle.Size = new System.Drawing.Size(484, 114);
            this.lblOverTitle.TabIndex = 0;
            this.lblOverTitle.Text = "恭喜通關";
            this.lblOverTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblOverResult
            // 
            this.lblOverResult.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblOverResult.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblOverResult.ForeColor = System.Drawing.SystemColors.Window;
            this.lblOverResult.Location = new System.Drawing.Point(29, 172);
            this.lblOverResult.Name = "lblOverResult";
            this.lblOverResult.Size = new System.Drawing.Size(484, 174);
            this.lblOverResult.TabIndex = 1;
            this.lblOverResult.Text = "恭喜通關";
            this.lblOverResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnOverExit
            // 
            this.btnOverExit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnOverExit.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnOverExit.ForeColor = System.Drawing.Color.LightBlue;
            this.btnOverExit.Location = new System.Drawing.Point(198, 381);
            this.btnOverExit.Name = "btnOverExit";
            this.btnOverExit.Size = new System.Drawing.Size(146, 52);
            this.btnOverExit.TabIndex = 2;
            this.btnOverExit.Text = "結束遊戲";
            this.btnOverExit.UseVisualStyleBackColor = true;
            this.btnOverExit.Click += new System.EventHandler(this.btnOverExit_Click);
            // 
            // btnOverRetry
            // 
            this.btnOverRetry.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnOverRetry.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnOverRetry.ForeColor = System.Drawing.Color.LightBlue;
            this.btnOverRetry.Location = new System.Drawing.Point(198, 439);
            this.btnOverRetry.Name = "btnOverRetry";
            this.btnOverRetry.Size = new System.Drawing.Size(146, 52);
            this.btnOverRetry.TabIndex = 3;
            this.btnOverRetry.Text = "重新挑戰";
            this.btnOverRetry.UseVisualStyleBackColor = true;
            this.btnOverRetry.Click += new System.EventHandler(this.btnOverRetry_Click);
            // 
            // btnOverSecret
            // 
            this.btnOverSecret.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnOverSecret.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnOverSecret.ForeColor = System.Drawing.Color.LightBlue;
            this.btnOverSecret.Location = new System.Drawing.Point(198, 497);
            this.btnOverSecret.Name = "btnOverSecret";
            this.btnOverSecret.Size = new System.Drawing.Size(146, 52);
            this.btnOverSecret.TabIndex = 4;
            this.btnOverSecret.Text = "隱藏關卡";
            this.btnOverSecret.UseVisualStyleBackColor = true;
            this.btnOverSecret.Visible = false;
            this.btnOverSecret.Click += new System.EventHandler(this.btnOverSecret_Click);
            // 
            // frmMemoryGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Honeydew;
            this.ClientSize = new System.Drawing.Size(543, 612);
            this.Controls.Add(this.pnlGame);
            this.Controls.Add(this.pnlGameOver);
            this.Controls.Add(this.pnlWelcome);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MinimumSize = new System.Drawing.Size(555, 650);
            this.Name = "frmMemoryGame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "記憶翻牌小遊戲";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMemoryGame_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.pnlGame.ResumeLayout(false);
            this.pnlGame.PerformLayout();
            this.pnlWelcome.ResumeLayout(false);
            this.pnlWelcome.PerformLayout();
            this.pnlGameOver.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlGame;
        private System.Windows.Forms.Button btnLv3;
        private System.Windows.Forms.Button btnLv2;
        private System.Windows.Forms.Button btnLv1;
        private System.Windows.Forms.ProgressBar timeBar;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblRemaining;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Label lbls;
        private System.Windows.Forms.Button btnRestart;
        private System.Windows.Forms.TableLayoutPanel gamePanel;
        private System.Windows.Forms.Panel pnlWelcome;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblRule2;
        private System.Windows.Forms.Label lblRule1;
        private System.Windows.Forms.Button btnStartGame;
        private System.Windows.Forms.Panel pnlGameOver;
        private System.Windows.Forms.Label lblOverTitle;
        private System.Windows.Forms.Label lblOverResult;
        private System.Windows.Forms.Button btnOverExit;
        private System.Windows.Forms.Button btnOverSecret;
        private System.Windows.Forms.Button btnOverRetry;
    }
}

