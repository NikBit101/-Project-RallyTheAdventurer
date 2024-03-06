namespace _Project__Platformer
{
    partial class ChooseGameType
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
            this.btn_NormalMode = new System.Windows.Forms.Button();
            this.btn_BonusMode = new System.Windows.Forms.Button();
            this.btn_Back = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Franklin Gothic Medium", 24F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(127, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(339, 47);
            this.label1.TabIndex = 0;
            this.label1.Text = "Choose your game";
            // 
            // btn_NormalMode
            // 
            this.btn_NormalMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_NormalMode.Location = new System.Drawing.Point(12, 83);
            this.btn_NormalMode.Name = "btn_NormalMode";
            this.btn_NormalMode.Size = new System.Drawing.Size(276, 69);
            this.btn_NormalMode.TabIndex = 1;
            this.btn_NormalMode.Text = "Normal mode";
            this.btn_NormalMode.UseVisualStyleBackColor = true;
            this.btn_NormalMode.Click += new System.EventHandler(this.btn_NormalMode_Click);
            // 
            // btn_BonusMode
            // 
            this.btn_BonusMode.Enabled = false;
            this.btn_BonusMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_BonusMode.Location = new System.Drawing.Point(294, 83);
            this.btn_BonusMode.Name = "btn_BonusMode";
            this.btn_BonusMode.Size = new System.Drawing.Size(276, 69);
            this.btn_BonusMode.TabIndex = 2;
            this.btn_BonusMode.Text = "Bonus mode";
            this.btn_BonusMode.UseVisualStyleBackColor = true;
            this.btn_BonusMode.Click += new System.EventHandler(this.btn_BonusMode_Click);
            // 
            // btn_Back
            // 
            this.btn_Back.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_Back.Location = new System.Drawing.Point(216, 168);
            this.btn_Back.Name = "btn_Back";
            this.btn_Back.Size = new System.Drawing.Size(155, 52);
            this.btn_Back.TabIndex = 4;
            this.btn_Back.Text = "Go Back";
            this.btn_Back.UseVisualStyleBackColor = true;
            this.btn_Back.Click += new System.EventHandler(this.btn_Back_Click);
            // 
            // ChooseGameType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 232);
            this.Controls.Add(this.btn_Back);
            this.Controls.Add(this.btn_BonusMode);
            this.Controls.Add(this.btn_NormalMode);
            this.Controls.Add(this.label1);
            this.Name = "ChooseGameType";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Game Mode";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ChooseGameType_FormClosing);
            this.Load += new System.EventHandler(this.ChooseGameType_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_NormalMode;
        private System.Windows.Forms.Button btn_Back;
        public System.Windows.Forms.Button btn_BonusMode;
    }
}