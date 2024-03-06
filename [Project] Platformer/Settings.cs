using _Project__Platformer.Properties;
using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _Project__Platformer
{
    public partial class Settings : Form
    {
        // saved levels file
        public string res_lvl_filepath = "SaveFile.txt";
        string s_fileText;

        // achievement file
        public string res_Achs_filepath = "AchievementFile.txt";
        string a_fileTexT;

        // Getter & setter to uncover the existing 'MainMenu' form
        public Form SettingsFormRef { get; set; }
        
        // booleans used for indicating if audio & music are turned on or off (by default it's yes)
        public bool isAudio = true;
        public bool isMusic = true;

        // in case of resetting progress, reset levels
        string newlvltxt = "LevelOne = 0\nLevelTwo = 0\nLevelThree = 0\nLevelFour = 0\nLevelFive = 0\nLevelSix = 0\nLevelSeven = 0\nLevelEight = 0\nLevelNine = 0\nLevelTen = 0";

        // in case of resetting progress, reset achievements
        string newachstxt = "AchievementOne = 0\nAchievementTwo = 0\nAchievementThree = 0\nAchievementFour = 0\nAchievementFive = 0\nAchievementSix = 0\nAchievementSeven = 0";

        //
        string newbonustxt = "LOne = 0\nLTwo = 0\nLThree = 0";

        int ProgressNum;


        public Settings()
        {
            InitializeComponent();

            // check the tutorial file first before checkboxes
            TutFile TF = new TutFile();
            TF.Tut_filecheck();
            CheckboxCheck(TF.TisComplete);

            ReadLevels();
            
            ReadAchievements();

            ReadBonus();

            PB_SoundONOFF.Image = Resources.UnMutedSound;
            PB_MusicONOFF.Image = Resources.MusicON;

        }
        
        private void ReadAchievements()
        {
            // read all achievements
            a_fileTexT = File.ReadAllText(res_Achs_filepath);

            if (a_fileTexT.Contains("AchievementOne = 1")) 
            {
                ProgressNum += 5;
            }
            if (a_fileTexT.Contains("AchievementTwo = 1")) 
            {
                ProgressNum += 5;
            }
            
            if (a_fileTexT.Contains("AchievementThree = 1")) 
            {
                ProgressNum += 5;
            }

            if (a_fileTexT.Contains("AchievementFour = 1")) 
            {
                ProgressNum += 5;
            }
            
            if (a_fileTexT.Contains("AchievementFive = 1"))
            {
                ProgressNum += 5;
            }
            
            if (a_fileTexT.Contains("AchievementSix = 1"))
            {
                ProgressNum += 5;
            }
            
            if (a_fileTexT.Contains("AchievementSeven = 1"))
            {
                ProgressNum += 5;
            }

            lbl_GP.Text = Convert.ToString(ProgressNum) + "%";
        }

        private void ReadLevels()
        {
            FormProvider.SML_Form.Show();
            FormProvider.SML_Form.Hide();
            
            if (FormProvider.SML_Form.btn_LevelTwo.Enabled)
            {
                ProgressNum += 5;
            }
            
            if (FormProvider.SML_Form.btn_LevelThree.Enabled)
            {
                ProgressNum += 5;
            }
            
            if (FormProvider.SML_Form.btn_LevelFour.Enabled)
            {
                ProgressNum += 5;
            }
            
            if (FormProvider.SML_Form.btn_LevelFive.Enabled)
            {
                ProgressNum += 5;
            }
            
            if (FormProvider.SML_Form.btn_LevelSix.Enabled)
            {
                ProgressNum += 5;
            }
            
            if (FormProvider.SML_Form.btn_LevelSeven.Enabled)
            {
                ProgressNum += 5;
            }
            
            if (FormProvider.SML_Form.btn_LevelEight.Enabled)
            {
                ProgressNum += 5;
            }
            
            if (FormProvider.SML_Form.btn_LevelNine.Enabled)
            {
                ProgressNum += 5;
            }
            
            if (FormProvider.SML_Form.btn_LevelTen.Enabled)
            {
                ProgressNum += 5;
            }

            // read all levels
            /*s_fileText = File.ReadAllText(res_lvl_filepath);

            if (s_fileText.Contains("LevelOne = 1"))
            {
                ProgressNum += 5;
            }
            
            if (s_fileText.Contains("LevelTwo = 1"))
            {
                ProgressNum += 5;
            }
            
            if (s_fileText.Contains("LevelThree = 1"))
            {
                ProgressNum += 5;
            }
            
            if (s_fileText.Contains("LevelFour = 1"))
            {
                ProgressNum += 5;
            }
            
            if (s_fileText.Contains("LevelFive = 1"))
            {
                ProgressNum += 5;
            }
            
            if (s_fileText.Contains("LevelSix = 1"))
            {
                ProgressNum += 5;
            }
            
            if (s_fileText.Contains("LevelSeven = 1"))
            {
                ProgressNum += 5;
            }
            
            if (s_fileText.Contains("LevelEight = 1"))
            {
                ProgressNum += 5;
            }
            
            if (s_fileText.Contains("LevelNine = 1"))
            {
                ProgressNum += 5;
            }
            
            if (s_fileText.Contains("LevelTen = 1"))
            {
                ProgressNum += 15;
            }
            */
            lbl_GP.Text = Convert.ToString(ProgressNum) + "%";
        }

        private void ReadBonus()
        {
            // read all bonus levels
            var b_fileText = Properties.Resources.BonusSave;

            if (b_fileText.Contains("LOne = 1"))
            {
                ProgressNum += 5;
            }
            
            if (b_fileText.Contains("LTwo = 1"))
            {
                ProgressNum += 5;
            }
            
            if (b_fileText.Contains("LThree = 1"))
            {
                ProgressNum += 5;
            }

            lbl_GP.Text = Convert.ToString(ProgressNum) + "%";
        }

        // uncover 'MainMenu' form
        private void Settings_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormProvider.MainMenu_Form.Show();
        }
        
        // audio control
        public void CB_Audio_CheckedChanged(object sender, EventArgs e)
        {
            // turn on the audio
            if (CB_Audio.Checked)
            {
                lbl_AudioONOFF.Text = "ON";
                lbl_AudioONOFF.ForeColor = Color.Green;
                PB_SoundONOFF.Image = Resources.UnMutedSound;
            }
            // turn off the audio
            else 
            {
                lbl_AudioONOFF.Text = "OFF";
                lbl_AudioONOFF.ForeColor = Color.Red;
                PB_SoundONOFF.Image = Resources.MutedSound;
            }
        }

        // music control
        private void CB_Music_CheckedChanged(object sender, EventArgs e)
        {
            // turn on the music
            if (CB_Music.Checked)
            {
                lbl_MusicONOFF.Text = "ON";
                lbl_MusicONOFF.ForeColor = Color.Green;
                PB_MusicONOFF.Image = Resources.MusicON;
            }
            // turn off the music
            else
            {
                lbl_MusicONOFF.Text = "OFF";
                lbl_MusicONOFF.ForeColor = Color.Red;
                PB_MusicONOFF.Image = Resources.MusicOFF;
            }
        }

       

        // 'restart progress' button 
        private void btn_ResetProgress_Click(object sender, EventArgs e)
        {
            DialogResult ResetProgress = MessageBox.Show("Warning! You're about to delete your whole gaming process.\nThat includes: level completions, score, save files and achievements.\n\nThis operation is unreturnable.\nDo you want to restart whole game progress?","Are you sure?", MessageBoxButtons.YesNoCancel);
        
            switch (ResetProgress)
            {
                // delete whole game progress
                case DialogResult.Yes:
                    
                    // Delete levels
                    DeleteLevelsData();

                    // Delete coins
                    DeleteCoinsData();
                    
                    // Delete achievements
                    DeleteAchsData();

                    // Delete tutorial trigger
                    DeleteTut();

                    // Delete Bonus save
                    DeleteBonus();

                    // Delete stats
                    DeleteStats();
                    
                    // Delete Time score
                    DeleteScore();

                    // restart game progress text
                    double GameProgressNum = 0;
                    lbl_GP.Text = GameProgressNum + "%";

                    // reset audio, music & guider options
                    lbl_AudioONOFF.Text = "ON";
                    lbl_AudioONOFF.ForeColor = Color.Green;
                    CB_Audio.Checked = true;
                    lbl_MusicONOFF.Text = "ON";
                    lbl_MusicONOFF.ForeColor = Color.Green;
                    CB_Music.Checked = true;
                    lbl_GuiderONOFF.Text = "ON";
                    lbl_GuiderONOFF.ForeColor = Color.Green;
                    CB_Guider.Checked = true;

                    MessageBox.Show("Game progress has been successfuly removed.");

                    FormProvider.Stats_Form.Dispose();
                    FormProvider.MainMenu_Form.Dispose();
                    Application.Restart();

                    break;
            }
        }

        // reset tutorial trigger
        private void DeleteTut()
        {
            if (File.Exists("TutEnabled.txt"))
            {
                File.Delete("TutEnabled.txt");

                string path = "TutEnabled.txt";
                using (StreamWriter fs = new StreamWriter(path))
                {
                    fs.Write("Complete = 0");
                    fs.Close();
                }
            }
        }

        // making the completed levels incompleted
        private void DeleteLevelsData()
        {
            if (File.Exists("SaveFile.txt"))
            {
                File.Delete("SaveFile.txt");

                string path = "SaveFile.txt";
                using (StreamWriter fs = new StreamWriter(path))
                {
                    fs.Write(newlvltxt);
                    fs.Close();
                }
            }
        }
        
        // making the obtained achievements unobtained
        private void DeleteAchsData()
        {
            if (File.Exists("AchievementFile.txt"))
            {
                File.Delete("AchievementFile.txt");

                string path = "AchievementFile.txt";
                using (StreamWriter fs = new StreamWriter(path))
                {
                    fs.Write(newachstxt);
                    fs.Close();
                }
            }
        }

        // deleting coins from the file
        private void DeleteCoinsData()
        {
            if (File.Exists("playerCoins_Data.txt"))
            {
                File.Delete("playerCoins_Data.txt");
                File.Create("playerCoins_Data.txt");
            }
        }

        // deleting score from file
        private void DeleteScore()
        {
            if (File.Exists("TimeScore.txt"))
            {
                string json = Properties.Resources.TimeScore;
                dynamic jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
                jsonObj["Time"] = 0;
                string output = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObj, Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText(@"TimeScore.txt", output);
            }
        }
        
        // deleting stats from file
        private void DeleteStats()
        {
            if (File.Exists("HScores.txt"))
            {
                File.Delete("HScores.txt");
                File.Create("HScores.txt");
            }
        }


        // deleting bonus save from file
        private void DeleteBonus()
        {
            if (File.Exists("BonusSave.txt"))
            {
                File.Delete("BonusSave.txt");

                string path = "BonusSave.txt";
                using (StreamWriter sw = new StreamWriter(path))
                {
                    sw.Write(newbonustxt);
                    sw.Close();
                }
            }
        }

        // close settings form
        private void btn_Exit_Click(object sender, EventArgs e)
        {
            //this.SettingsFormRef.Show();
            this.Hide();
        }

        // button 'Guider' is clicked
        private void CB_Guider_CheckedChanged(object sender, EventArgs e)
        {

            if (CB_Guider.Checked)
            {
                lbl_GuiderONOFF.Text = "ON";
                lbl_GuiderONOFF.ForeColor = Color.Green;
            }
            else
            {
                lbl_GuiderONOFF.Text = "OFF";
                lbl_GuiderONOFF.ForeColor = Color.Red;
            }

        }

        private void CheckboxCheck(bool Tutbool)
        {
            // if tutorial file reveals completed tutorial
            if (Tutbool)
            {
                CB_Guider.Checked = false;
                CB_Guider.Enabled = false;
            }
            else
            {
                CB_Guider.Checked = true;
                CB_Guider.Enabled = true;
            }
        }

        private void Settings_Load(object sender, EventArgs e)
        {

        }
    }
}
