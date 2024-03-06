namespace _Project__Platformer
{
    partial class MainMenu
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_Start = new System.Windows.Forms.Button();
            this.btn_Settings = new System.Windows.Forms.Button();
            this.btn_Exit = new System.Windows.Forms.Button();
            this.btn_Highscore = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_Achievements = new System.Windows.Forms.Button();
            this.btn_ISForm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_Start
            // 
            this.btn_Start.Font = new System.Drawing.Font("Cambria", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_Start.Location = new System.Drawing.Point(237, 269);
            this.btn_Start.Name = "btn_Start";
            this.btn_Start.Size = new System.Drawing.Size(272, 77);
            this.btn_Start.TabIndex = 0;
            this.btn_Start.Text = "Start";
            this.btn_Start.UseVisualStyleBackColor = true;
            this.btn_Start.Click += new System.EventHandler(this.btn_Start_Click);
            // 
            // btn_Settings
            // 
            this.btn_Settings.Font = new System.Drawing.Font("Cambria", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_Settings.Location = new System.Drawing.Point(237, 457);
            this.btn_Settings.Name = "btn_Settings";
            this.btn_Settings.Size = new System.Drawing.Size(272, 77);
            this.btn_Settings.TabIndex = 1;
            this.btn_Settings.Text = "Settings";
            this.btn_Settings.UseVisualStyleBackColor = true;
            this.btn_Settings.Click += new System.EventHandler(this.btn_Settings_Click);
            // 
            // btn_Exit
            // 
            this.btn_Exit.Font = new System.Drawing.Font("Cambria", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_Exit.Location = new System.Drawing.Point(237, 556);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(272, 77);
            this.btn_Exit.TabIndex = 2;
            this.btn_Exit.Tag = "123";
            this.btn_Exit.Text = "Exit";
            this.btn_Exit.UseVisualStyleBackColor = true;
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // btn_Highscore
            // 
            this.btn_Highscore.Font = new System.Drawing.Font("Cambria", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_Highscore.Location = new System.Drawing.Point(237, 361);
            this.btn_Highscore.Name = "btn_Highscore";
            this.btn_Highscore.Size = new System.Drawing.Size(272, 77);
            this.btn_Highscore.TabIndex = 3;
            this.btn_Highscore.Text = "Statistics";
            this.btn_Highscore.UseVisualStyleBackColor = true;
            this.btn_Highscore.Click += new System.EventHandler(this.btn_Highscore_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(53, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(609, 69);
            this.label1.TabIndex = 4;
            this.label1.Text = "Rally The Adventurer";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 615);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "version:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(77, 616);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "1.5.4";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(525, 615);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Programmer:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(611, 615);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "Nikita Cernenko";
            // 
            // btn_Achievements
            // 
            this.btn_Achievements.Font = new System.Drawing.Font("Cambria", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_Achievements.Location = new System.Drawing.Point(517, 466);
            this.btn_Achievements.Name = "btn_Achievements";
            this.btn_Achievements.Size = new System.Drawing.Size(217, 61);
            this.btn_Achievements.TabIndex = 9;
            this.btn_Achievements.Text = "Achievements";
            this.btn_Achievements.UseVisualStyleBackColor = true;
            this.btn_Achievements.Click += new System.EventHandler(this.btn_Achievements_Click);
            // 
            // btn_ISForm
            // 
            this.btn_ISForm.Font = new System.Drawing.Font("Cambria", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_ISForm.Location = new System.Drawing.Point(3, 466);
            this.btn_ISForm.Name = "btn_ISForm";
            this.btn_ISForm.Size = new System.Drawing.Size(217, 61);
            this.btn_ISForm.TabIndex = 10;
            this.btn_ISForm.Text = "Instructions";
            this.btn_ISForm.UseVisualStyleBackColor = true;
            this.btn_ISForm.Click += new System.EventHandler(this.btn_ISForm_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(742, 645);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_ISForm);
            this.Controls.Add(this.btn_Achievements);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_Highscore);
            this.Controls.Add(this.btn_Exit);
            this.Controls.Add(this.btn_Settings);
            this.Controls.Add(this.btn_Start);
            this.Name = "MainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main Menu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Start;
        private System.Windows.Forms.Button btn_Settings;
        private System.Windows.Forms.Button btn_Exit;
        private System.Windows.Forms.Button btn_Highscore;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_Achievements;
        private System.Windows.Forms.Button btn_ISForm;
    }
}

