namespace _Project__Platformer
{
    partial class Bonus_Mode
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
            this.btn_BL1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_BL2 = new System.Windows.Forms.Button();
            this.btn_BL3 = new System.Windows.Forms.Button();
            this.btn_Back = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_BL1
            // 
            this.btn_BL1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_BL1.Location = new System.Drawing.Point(46, 87);
            this.btn_BL1.Name = "btn_BL1";
            this.btn_BL1.Size = new System.Drawing.Size(80, 67);
            this.btn_BL1.TabIndex = 0;
            this.btn_BL1.Text = "1";
            this.btn_BL1.UseVisualStyleBackColor = true;
            this.btn_BL1.Click += new System.EventHandler(this.btn_BonusLevels_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(99, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(399, 69);
            this.label1.TabIndex = 1;
            this.label1.Text = "Bonus Levels";
            // 
            // btn_BL2
            // 
            this.btn_BL2.Enabled = false;
            this.btn_BL2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_BL2.Location = new System.Drawing.Point(264, 87);
            this.btn_BL2.Name = "btn_BL2";
            this.btn_BL2.Size = new System.Drawing.Size(80, 67);
            this.btn_BL2.TabIndex = 2;
            this.btn_BL2.Text = "2";
            this.btn_BL2.UseVisualStyleBackColor = true;
            this.btn_BL2.Click += new System.EventHandler(this.btn_BonusLevels_Click);
            // 
            // btn_BL3
            // 
            this.btn_BL3.Enabled = false;
            this.btn_BL3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_BL3.Location = new System.Drawing.Point(482, 87);
            this.btn_BL3.Name = "btn_BL3";
            this.btn_BL3.Size = new System.Drawing.Size(80, 67);
            this.btn_BL3.TabIndex = 3;
            this.btn_BL3.Text = "3";
            this.btn_BL3.UseVisualStyleBackColor = true;
            this.btn_BL3.Click += new System.EventHandler(this.btn_BonusLevels_Click);
            // 
            // btn_Back
            // 
            this.btn_Back.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_Back.Location = new System.Drawing.Point(184, 236);
            this.btn_Back.Name = "btn_Back";
            this.btn_Back.Size = new System.Drawing.Size(236, 52);
            this.btn_Back.TabIndex = 4;
            this.btn_Back.Text = "Go Back";
            this.btn_Back.UseVisualStyleBackColor = true;
            this.btn_Back.Click += new System.EventHandler(this.btn_Back_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Comic Sans MS", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(12, 171);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(155, 39);
            this.label2.TabIndex = 5;
            this.label2.Text = "DoorMania";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Comic Sans MS", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(235, 171);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(137, 39);
            this.label3.TabIndex = 6;
            this.label3.Text = "Levitator";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Comic Sans MS", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(473, 157);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(122, 78);
            this.label4.TabIndex = 7;
            this.label4.Text = "Pushing \r\n Force";
            // 
            // Bonus_Mode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(591, 300);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_Back);
            this.Controls.Add(this.btn_BL3);
            this.Controls.Add(this.btn_BL2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_BL1);
            this.Name = "Bonus_Mode";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bonus_Mode";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Bonus_Mode_FormClosing);
            this.Load += new System.EventHandler(this.Bonus_Mode_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_BL1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_BL2;
        private System.Windows.Forms.Button btn_BL3;
        private System.Windows.Forms.Button btn_Back;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}