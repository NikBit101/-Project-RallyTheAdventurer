namespace _Project__Platformer
{
    partial class Settings
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
            this.label1 = new System.Windows.Forms.Label();
            this.CB_Audio = new System.Windows.Forms.CheckBox();
            this.lbl_AudioONOFF = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl_GP = new System.Windows.Forms.Label();
            this.btn_ResetProgress = new System.Windows.Forms.Button();
            this.CB_Music = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lbl_MusicONOFF = new System.Windows.Forms.Label();
            this.btn_Exit = new System.Windows.Forms.Button();
            this.PB_SoundONOFF = new System.Windows.Forms.PictureBox();
            this.PB_MusicONOFF = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.CB_Guider = new System.Windows.Forms.CheckBox();
            this.lbl_GuiderONOFF = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PB_SoundONOFF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_MusicONOFF)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(32, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 38);
            this.label1.TabIndex = 0;
            this.label1.Text = "Audio:";
            // 
            // CB_Audio
            // 
            this.CB_Audio.AutoSize = true;
            this.CB_Audio.Checked = true;
            this.CB_Audio.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CB_Audio.Location = new System.Drawing.Point(80, 61);
            this.CB_Audio.Name = "CB_Audio";
            this.CB_Audio.Size = new System.Drawing.Size(18, 17);
            this.CB_Audio.TabIndex = 1;
            this.CB_Audio.UseVisualStyleBackColor = true;
            this.CB_Audio.CheckedChanged += new System.EventHandler(this.CB_Audio_CheckedChanged);
            // 
            // lbl_AudioONOFF
            // 
            this.lbl_AudioONOFF.AutoSize = true;
            this.lbl_AudioONOFF.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_AudioONOFF.ForeColor = System.Drawing.Color.Green;
            this.lbl_AudioONOFF.Location = new System.Drawing.Point(269, 15);
            this.lbl_AudioONOFF.Name = "lbl_AudioONOFF";
            this.lbl_AudioONOFF.Size = new System.Drawing.Size(57, 32);
            this.lbl_AudioONOFF.TabIndex = 2;
            this.lbl_AudioONOFF.Text = "ON";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(12, 362);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(167, 38);
            this.label3.TabIndex = 6;
            this.label3.Text = "Progress:";
            // 
            // lbl_GP
            // 
            this.lbl_GP.AutoSize = true;
            this.lbl_GP.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_GP.ForeColor = System.Drawing.Color.Black;
            this.lbl_GP.Location = new System.Drawing.Point(269, 368);
            this.lbl_GP.Name = "lbl_GP";
            this.lbl_GP.Size = new System.Drawing.Size(56, 32);
            this.lbl_GP.TabIndex = 7;
            this.lbl_GP.Text = "0%";
            // 
            // btn_ResetProgress
            // 
            this.btn_ResetProgress.BackColor = System.Drawing.Color.Red;
            this.btn_ResetProgress.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ResetProgress.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_ResetProgress.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_ResetProgress.Location = new System.Drawing.Point(12, 416);
            this.btn_ResetProgress.Name = "btn_ResetProgress";
            this.btn_ResetProgress.Size = new System.Drawing.Size(257, 91);
            this.btn_ResetProgress.TabIndex = 8;
            this.btn_ResetProgress.Text = "Reset progress";
            this.btn_ResetProgress.UseVisualStyleBackColor = false;
            this.btn_ResetProgress.Click += new System.EventHandler(this.btn_ResetProgress_Click);
            // 
            // CB_Music
            // 
            this.CB_Music.AutoSize = true;
            this.CB_Music.Location = new System.Drawing.Point(80, 182);
            this.CB_Music.Name = "CB_Music";
            this.CB_Music.Size = new System.Drawing.Size(18, 17);
            this.CB_Music.TabIndex = 10;
            this.CB_Music.UseVisualStyleBackColor = true;
            this.CB_Music.CheckedChanged += new System.EventHandler(this.CB_Music_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(32, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 38);
            this.label4.TabIndex = 9;
            this.label4.Text = "Music:";
            // 
            // lbl_MusicONOFF
            // 
            this.lbl_MusicONOFF.AutoSize = true;
            this.lbl_MusicONOFF.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_MusicONOFF.ForeColor = System.Drawing.Color.Green;
            this.lbl_MusicONOFF.Location = new System.Drawing.Point(269, 136);
            this.lbl_MusicONOFF.Name = "lbl_MusicONOFF";
            this.lbl_MusicONOFF.Size = new System.Drawing.Size(57, 32);
            this.lbl_MusicONOFF.TabIndex = 11;
            this.lbl_MusicONOFF.Text = "ON";
            // 
            // btn_Exit
            // 
            this.btn_Exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_Exit.Location = new System.Drawing.Point(344, 416);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(239, 91);
            this.btn_Exit.TabIndex = 16;
            this.btn_Exit.Text = "Exit";
            this.btn_Exit.UseVisualStyleBackColor = true;
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // PB_SoundONOFF
            // 
            this.PB_SoundONOFF.Image = global::_Project__Platformer.Properties.Resources.UnMutedSound;
            this.PB_SoundONOFF.Location = new System.Drawing.Point(455, 9);
            this.PB_SoundONOFF.Name = "PB_SoundONOFF";
            this.PB_SoundONOFF.Size = new System.Drawing.Size(63, 56);
            this.PB_SoundONOFF.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PB_SoundONOFF.TabIndex = 17;
            this.PB_SoundONOFF.TabStop = false;
            // 
            // PB_MusicONOFF
            // 
            this.PB_MusicONOFF.Image = global::_Project__Platformer.Properties.Resources.MusicON;
            this.PB_MusicONOFF.Location = new System.Drawing.Point(455, 130);
            this.PB_MusicONOFF.Name = "PB_MusicONOFF";
            this.PB_MusicONOFF.Size = new System.Drawing.Size(63, 56);
            this.PB_MusicONOFF.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PB_MusicONOFF.TabIndex = 18;
            this.PB_MusicONOFF.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(19, 229);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(131, 38);
            this.label5.TabIndex = 19;
            this.label5.Text = "Guider:";
            // 
            // CB_Guider
            // 
            this.CB_Guider.AutoSize = true;
            this.CB_Guider.Checked = true;
            this.CB_Guider.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CB_Guider.Location = new System.Drawing.Point(80, 285);
            this.CB_Guider.Name = "CB_Guider";
            this.CB_Guider.Size = new System.Drawing.Size(18, 17);
            this.CB_Guider.TabIndex = 20;
            this.CB_Guider.UseVisualStyleBackColor = true;
            this.CB_Guider.CheckedChanged += new System.EventHandler(this.CB_Guider_CheckedChanged);
            // 
            // lbl_GuiderONOFF
            // 
            this.lbl_GuiderONOFF.AutoSize = true;
            this.lbl_GuiderONOFF.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_GuiderONOFF.ForeColor = System.Drawing.Color.Green;
            this.lbl_GuiderONOFF.Location = new System.Drawing.Point(269, 235);
            this.lbl_GuiderONOFF.Name = "lbl_GuiderONOFF";
            this.lbl_GuiderONOFF.Size = new System.Drawing.Size(57, 32);
            this.lbl_GuiderONOFF.TabIndex = 21;
            this.lbl_GuiderONOFF.Text = "ON";
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(595, 514);
            this.Controls.Add(this.lbl_GuiderONOFF);
            this.Controls.Add(this.CB_Guider);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.PB_MusicONOFF);
            this.Controls.Add(this.PB_SoundONOFF);
            this.Controls.Add(this.btn_Exit);
            this.Controls.Add(this.CB_Music);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lbl_MusicONOFF);
            this.Controls.Add(this.btn_ResetProgress);
            this.Controls.Add(this.lbl_GP);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.CB_Audio);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbl_AudioONOFF);
            this.Name = "Settings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Settings_FormClosing);
            this.Load += new System.EventHandler(this.Settings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PB_SoundONOFF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_MusicONOFF)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_AudioONOFF;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbl_GP;
        private System.Windows.Forms.Button btn_ResetProgress;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbl_MusicONOFF;
        private System.Windows.Forms.Button btn_Exit;
        private System.Windows.Forms.PictureBox PB_SoundONOFF;
        private System.Windows.Forms.PictureBox PB_MusicONOFF;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbl_GuiderONOFF;
        public System.Windows.Forms.CheckBox CB_Audio;
        public System.Windows.Forms.CheckBox CB_Music;
        public System.Windows.Forms.CheckBox CB_Guider;
    }
}