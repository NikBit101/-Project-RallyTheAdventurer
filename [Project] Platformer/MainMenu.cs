using _Project__Platformer.Properties;
using System;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace _Project__Platformer
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();

            // don't let the user change form's size
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            PictureBox backgroundGif = new PictureBox();
            Controls.Add(backgroundGif);
            backgroundGif.Image = Resources.GGFlow;
            backgroundGif.Dock = DockStyle.Fill;

        }

        // music player
        public Stream str_Music;
        public System.Media.SoundPlayer m_MusicPlayer = null;

        // start the game
        private void btn_Start_Click(object sender, EventArgs e)
        {
            //ChooseGameType GameTypeForm = new ChooseGameType();
            // [DELETE] GameTypeForm.MainMenuRef = this;
            //this.Visible = false;
            FormProvider.CGT_Form.Show();
        }

        // check stats of the game
        private void btn_Highscore_Click(object sender, EventArgs e)
        {
            /*Stats StatForm = new Stats();
            StatForm.StatFormRef = this;*/
            FormProvider.Stats_Form.Show();
        }

        // button 'Instructions' is clicked
        private void btn_ISForm_Click(object sender, EventArgs e)
        {
            InstructionsForm IF = new InstructionsForm();
            IF.Show();
        }

        // settings
        private void btn_Settings_Click(object sender, EventArgs e)
        {
            FormProvider.SETT_Form.Show();
            /*
            Settings SettingsForm = new Settings();
            SettingsForm.SettingsFormRef = this;
            this.Visible = false;
            SettingsForm.Show();*/
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            // prompt user with exit choice
            DialogResult exit = MessageBox.Show("Are you sure?", "Exit?", MessageBoxButtons.YesNo);

            switch (exit)
            {
                case DialogResult.Yes:
                    this.Close();
                    break;
                case DialogResult.No:
                    break;
            }
        }

        private void btn_Achievements_Click(object sender, EventArgs e)
        {
            AchievementsForm AF = new AchievementsForm();
            AF.Show();
        }

        private void btn_name_confirm_Click(object sender, EventArgs e)
        {

        }
    }
}
