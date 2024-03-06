namespace _Project__Platformer
{
    partial class TheGame
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_Lives = new System.Windows.Forms.Label();
            this.lbl_GuideText = new System.Windows.Forms.Label();
            this.FPS_Timer = new System.Windows.Forms.Timer(this.components);
            this.PIC_Player = new System.Windows.Forms.PictureBox();
            this.lbl_time_min = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Stopwatch_Secs = new System.Windows.Forms.Timer(this.components);
            this.lbl_time_secs = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PIC_Player)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 22.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 55);
            this.label1.TabIndex = 0;
            this.label1.Text = "Lives:";
            // 
            // lbl_Lives
            // 
            this.lbl_Lives.AutoSize = true;
            this.lbl_Lives.BackColor = System.Drawing.Color.Black;
            this.lbl_Lives.Font = new System.Drawing.Font("Comic Sans MS", 22.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_Lives.ForeColor = System.Drawing.Color.White;
            this.lbl_Lives.Location = new System.Drawing.Point(137, 9);
            this.lbl_Lives.Name = "lbl_Lives";
            this.lbl_Lives.Size = new System.Drawing.Size(47, 55);
            this.lbl_Lives.TabIndex = 1;
            this.lbl_Lives.Text = "5";
            // 
            // lbl_GuideText
            // 
            this.lbl_GuideText.AutoSize = true;
            this.lbl_GuideText.BackColor = System.Drawing.Color.Transparent;
            this.lbl_GuideText.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_GuideText.Location = new System.Drawing.Point(353, 169);
            this.lbl_GuideText.Name = "lbl_GuideText";
            this.lbl_GuideText.Size = new System.Drawing.Size(336, 32);
            this.lbl_GuideText.TabIndex = 5;
            this.lbl_GuideText.Text = "Press arrow keys to move";
            this.lbl_GuideText.Visible = false;
            // 
            // FPS_Timer
            // 
            this.FPS_Timer.Interval = 30;
            this.FPS_Timer.Tick += new System.EventHandler(this.FPS_Timer_Tick);
            // 
            // PIC_Player
            // 
            this.PIC_Player.BackColor = System.Drawing.Color.Transparent;
            this.PIC_Player.Image = global::_Project__Platformer.Properties.Resources.RallyTheBoy;
            this.PIC_Player.Location = new System.Drawing.Point(49, 545);
            this.PIC_Player.Name = "PIC_Player";
            this.PIC_Player.Size = new System.Drawing.Size(40, 65);
            this.PIC_Player.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PIC_Player.TabIndex = 2;
            this.PIC_Player.TabStop = false;
            // 
            // lbl_time_min
            // 
            this.lbl_time_min.AutoSize = true;
            this.lbl_time_min.BackColor = System.Drawing.Color.Black;
            this.lbl_time_min.Font = new System.Drawing.Font("Comic Sans MS", 22.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_time_min.ForeColor = System.Drawing.Color.White;
            this.lbl_time_min.Location = new System.Drawing.Point(550, 9);
            this.lbl_time_min.Name = "lbl_time_min";
            this.lbl_time_min.Size = new System.Drawing.Size(86, 55);
            this.lbl_time_min.TabIndex = 7;
            this.lbl_time_min.Text = "00:";
            this.lbl_time_min.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Black;
            this.label3.Font = new System.Drawing.Font("Comic Sans MS", 22.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(431, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 55);
            this.label3.TabIndex = 6;
            this.label3.Text = "Time:";
            // 
            // Stopwatch_Secs
            // 
            this.Stopwatch_Secs.Enabled = true;
            this.Stopwatch_Secs.Interval = 1000;
            this.Stopwatch_Secs.Tick += new System.EventHandler(this.Stopwatch_Secs_Tick);
            // 
            // lbl_time_secs
            // 
            this.lbl_time_secs.AutoSize = true;
            this.lbl_time_secs.BackColor = System.Drawing.Color.Black;
            this.lbl_time_secs.Font = new System.Drawing.Font("Comic Sans MS", 22.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_time_secs.ForeColor = System.Drawing.Color.White;
            this.lbl_time_secs.Location = new System.Drawing.Point(628, 9);
            this.lbl_time_secs.Name = "lbl_time_secs";
            this.lbl_time_secs.Size = new System.Drawing.Size(70, 55);
            this.lbl_time_secs.TabIndex = 8;
            this.lbl_time_secs.Text = "00";
            this.lbl_time_secs.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TheGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1082, 638);
            this.Controls.Add(this.lbl_time_secs);
            this.Controls.Add(this.lbl_time_min);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbl_GuideText);
            this.Controls.Add(this.PIC_Player);
            this.Controls.Add(this.lbl_Lives);
            this.Controls.Add(this.label1);
            this.Name = "TheGame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "The Game";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TheGame_FormClosing);
            this.Load += new System.EventHandler(this.TheGame_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TheGame_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TheGame_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.PIC_Player)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_Lives;
        private System.Windows.Forms.PictureBox PIC_Player;
        private System.Windows.Forms.Label lbl_GuideText;
        private System.Windows.Forms.Timer FPS_Timer;
        private System.Windows.Forms.Label lbl_time_min;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer Stopwatch_Secs;
        private System.Windows.Forms.Label lbl_time_secs;
    }
}