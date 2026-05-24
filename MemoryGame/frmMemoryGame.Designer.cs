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
            this.pnlTop = new System.Windows.Forms.Panel();
            this.pnlButtom = new System.Windows.Forms.Panel();
            this.btnLv1 = new System.Windows.Forms.Button();
            this.btnLv2 = new System.Windows.Forms.Button();
            this.btnLv3 = new System.Windows.Forms.Button();
            this.lblTime = new System.Windows.Forms.Label();
            this.timeBar = new System.Windows.Forms.ProgressBar();
            this.lblRemaining = new System.Windows.Forms.Label();
            this.btnRestart = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.gamePanel = new System.Windows.Forms.TableLayoutPanel();
            this.lbls = new System.Windows.Forms.Label();
            this.pnlTop.SuspendLayout();
            this.pnlButtom.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.lbls);
            this.pnlTop.Controls.Add(this.lblRemaining);
            this.pnlTop.Controls.Add(this.timeBar);
            this.pnlTop.Controls.Add(this.lblTime);
            this.pnlTop.Controls.Add(this.btnLv3);
            this.pnlTop.Controls.Add(this.btnLv2);
            this.pnlTop.Controls.Add(this.btnLv1);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(543, 66);
            this.pnlTop.TabIndex = 0;
            // 
            // pnlButtom
            // 
            this.pnlButtom.Controls.Add(this.btnRestart);
            this.pnlButtom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButtom.Location = new System.Drawing.Point(0, 574);
            this.pnlButtom.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlButtom.Name = "pnlButtom";
            this.pnlButtom.Size = new System.Drawing.Size(543, 39);
            this.pnlButtom.TabIndex = 2;
            // 
            // btnLv1
            // 
            this.btnLv1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnLv1.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnLv1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnLv1.Location = new System.Drawing.Point(100, 11);
            this.btnLv1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnLv1.Name = "btnLv1";
            this.btnLv1.Size = new System.Drawing.Size(100, 31);
            this.btnLv1.TabIndex = 0;
            this.btnLv1.Text = "🚩第一關 4x4";
            this.btnLv1.UseVisualStyleBackColor = false;
            // 
            // btnLv2
            // 
            this.btnLv2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnLv2.BackColor = System.Drawing.SystemColors.Control;
            this.btnLv2.Location = new System.Drawing.Point(208, 11);
            this.btnLv2.Margin = new System.Windows.Forms.Padding(4);
            this.btnLv2.Name = "btnLv2";
            this.btnLv2.Size = new System.Drawing.Size(100, 31);
            this.btnLv2.TabIndex = 1;
            this.btnLv2.Text = "🚩第二關 6x6";
            this.btnLv2.UseVisualStyleBackColor = false;
            // 
            // btnLv3
            // 
            this.btnLv3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnLv3.BackColor = System.Drawing.SystemColors.Control;
            this.btnLv3.Location = new System.Drawing.Point(316, 11);
            this.btnLv3.Margin = new System.Windows.Forms.Padding(4);
            this.btnLv3.Name = "btnLv3";
            this.btnLv3.Size = new System.Drawing.Size(100, 31);
            this.btnLv3.TabIndex = 2;
            this.btnLv3.Text = "🚩第三關 8x8";
            this.btnLv3.UseVisualStyleBackColor = false;
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
            // timeBar
            // 
            this.timeBar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.timeBar.ForeColor = System.Drawing.Color.PaleGoldenrod;
            this.timeBar.Location = new System.Drawing.Point(98, 49);
            this.timeBar.Name = "timeBar";
            this.timeBar.Size = new System.Drawing.Size(369, 10);
            this.timeBar.TabIndex = 4;
            // 
            // lblRemaining
            // 
            this.lblRemaining.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblRemaining.AutoSize = true;
            this.lblRemaining.Location = new System.Drawing.Point(423, 20);
            this.lblRemaining.Name = "lblRemaining";
            this.lblRemaining.Size = new System.Drawing.Size(98, 16);
            this.lblRemaining.TabIndex = 5;
            this.lblRemaining.Text = "剩餘未配對: -- 對";
            // 
            // btnRestart
            // 
            this.btnRestart.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnRestart.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnRestart.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnRestart.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnRestart.Location = new System.Drawing.Point(221, 2);
            this.btnRestart.Margin = new System.Windows.Forms.Padding(4);
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size(100, 31);
            this.btnRestart.TabIndex = 2;
            this.btnRestart.Text = "重新開始";
            this.btnRestart.UseVisualStyleBackColor = false;
            this.btnRestart.Click += new System.EventHandler(this.btnRestart_Click);
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
            this.gamePanel.Location = new System.Drawing.Point(16, 65);
            this.gamePanel.MinimumSize = new System.Drawing.Size(500, 500);
            this.gamePanel.Name = "gamePanel";
            this.gamePanel.RowCount = 2;
            this.gamePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.gamePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.gamePanel.Size = new System.Drawing.Size(510, 510);
            this.gamePanel.TabIndex = 3;
            // 
            // lbls
            // 
            this.lbls.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbls.AutoSize = true;
            this.lbls.Location = new System.Drawing.Point(473, 46);
            this.lbls.Name = "lbls";
            this.lbls.Size = new System.Drawing.Size(29, 16);
            this.lbls.TabIndex = 6;
            this.lbls.Text = "--秒";
            this.lbls.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // frmMemoryGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MintCream;
            this.ClientSize = new System.Drawing.Size(543, 613);
            this.Controls.Add(this.gamePanel);
            this.Controls.Add(this.pnlButtom);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "frmMemoryGame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "記憶翻牌小遊戲";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMemoryGame_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlButtom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Panel pnlButtom;
        private System.Windows.Forms.Button btnLv3;
        private System.Windows.Forms.Button btnLv2;
        private System.Windows.Forms.Button btnLv1;
        private System.Windows.Forms.ProgressBar timeBar;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblRemaining;
        private System.Windows.Forms.Button btnRestart;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.TableLayoutPanel gamePanel;
        private System.Windows.Forms.Label lbls;
    }
}

