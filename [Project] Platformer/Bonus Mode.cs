using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Resources;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _Project__Platformer
{
    public partial class Bonus_Mode : Form
    {
        public Bonus_Mode()
        {
            InitializeComponent();

            // don't let the user change form's size
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            //this.BringToFront();
        }

        // coins
        public int GlobalCoins = 10;
        
        // Getter & setter for level completion detection
        public string BLC { get; set; }

        private void btn_Back_Click(object sender, EventArgs e)
        {
            this.Close();
            FormProvider.CGT_Form.Show();
        }

        public int intLevel;
        private void btn_BonusLevels_Click(object sender, EventArgs e)
        {
            if (sender == btn_BL1)
            {
                intLevel = 11;
                StartGame(intLevel);
            }
            
            if (sender == btn_BL2)
            {
                intLevel = 12;
                StartGame(intLevel);
            }
            
            if (sender == btn_BL3)
            {
                intLevel = 13;
                StartGame(intLevel);
            }
        }

        private void StartGame(int intLevel)
        {
            // After if statements are done...
            // ...open 'TheGame' form
            TheGame GameForm = new TheGame();

            // ...route the value from 'StoryModeLevels' as a level detector
            GameForm.LevelDetermine(intLevel);

            // ...hide 'MainMenu' form
            FormProvider.MainMenu_Form.Visible = false;

            // if the music player from main menu has music assigned in it
            // & user enabled the music in settings
            if (FormProvider.MainMenu_Form.m_MusicPlayer == null && FormProvider.SETT_Form.CB_Music.Checked)
            {
                // get music player from main menu and assign music into it
                FormProvider.MainMenu_Form.str_Music = Properties.Resources.MusicMix;
                FormProvider.MainMenu_Form.m_MusicPlayer = new System.Media.SoundPlayer(FormProvider.MainMenu_Form.str_Music);
                FormProvider.MainMenu_Form.m_MusicPlayer.PlayLooping();
            }

            GameForm.intCoins = GlobalCoins;

            GameForm.ParentForm = this;
            this.Hide();
            GameForm.Show();
        }

        // after certain level has been completed
        public void LevelCompleted(string BLC)
        {
            var b_filetext = Properties.Resources.BonusSave;

            if (BLC == "1")
            {
                if (b_filetext.Contains("LOne = 0"))
                {
                    var completed = b_filetext.Replace("LOne = 0", "LOne = 1");
                    File.WriteAllText(@"BonusSave.txt", completed);
                    
                }

                // disable the music if it was turned on
                if (FormProvider.MainMenu_Form.m_MusicPlayer != null)
                {
                    FormProvider.MainMenu_Form.m_MusicPlayer.Stop();
                    FormProvider.MainMenu_Form.m_MusicPlayer = null;
                }

                FormProvider.MainMenu_Form.Show();
            }
            
            if (BLC == "2")
            {
                if (b_filetext.Contains("LTwo = 0"))
                {
                    var completed = b_filetext.Replace("LTwo = 0", "LTwo = 1");
                    File.WriteAllText(@"BonusSave.txt", completed);
                }

                // disable the music if it was turned on
                if (FormProvider.MainMenu_Form.m_MusicPlayer != null)
                {
                    FormProvider.MainMenu_Form.m_MusicPlayer.Stop();
                    FormProvider.MainMenu_Form.m_MusicPlayer = null;
                }

                FormProvider.MainMenu_Form.Show();
            }
            
            if (BLC == "3")
            {
                if (b_filetext.Contains("LThree = 0"))
                {
                    var completed = b_filetext.Replace("LThree = 0", "LThree = 1");
                    File.WriteAllText(@"BonusSave.txt", completed);
                }

                // check achievement, if bonus mode was completed just now
                if (File.Exists("AchievementFile.txt"))
                {
                    var a_fileTexT = File.ReadAllText("AchievementFile.txt");

                    if (a_fileTexT.Contains("AchievementFour = 0"))
                    {
                        // replace unobtained achievement with obtained
                        string replacedachvText = a_fileTexT.Replace("AchievementFour = 0", "AchievementFour = 1");
                        File.WriteAllText(@"AchievementFile.txt", replacedachvText);
                    }
                }

                // disable the music if it was turned on
                if (FormProvider.MainMenu_Form.m_MusicPlayer != null)
                {
                    FormProvider.MainMenu_Form.m_MusicPlayer.Stop();
                    FormProvider.MainMenu_Form.m_MusicPlayer = null;
                }

                FormProvider.MainMenu_Form.Show();
            }
        }

            private void SavedLevels()
        {
            var b_filetext = Properties.Resources.BonusSave;

            if (b_filetext.Contains("LOne = 1"))
            {
                btn_BL2.Enabled = true;
            }
            if (b_filetext.Contains("LTwo = 1"))
            {
                btn_BL2.Enabled = true;
                btn_BL3.Enabled = true;
            }
        }

        private void Bonus_Mode_Load(object sender, EventArgs e)
        {
            SavedLevels();
        }

        private void Bonus_Mode_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }
    }
}
