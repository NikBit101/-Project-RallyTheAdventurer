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
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
//using System.Web.Script.Serialization;
//using Microsoft.VisualBasic;

namespace _Project__Platformer
{
    public partial class NormalModeLevels : Form
    {
        public NormalModeLevels()
        {
            InitializeComponent();

            // don't let the user change form's size
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            this.BringToFront();
        }

        // create a new instance of the game form but don't do anything until all code is done here
        //public TheGame GameForm = new TheGame();

        // call in a serialization class / create its new instance
        public List<SaveLoadSerial_Coins> SaveLoadSerial = new List<SaveLoadSerial_Coins>();


        // tutorial file
        public string res_Tut_filepath = "TutEnabled.txt";
        string t_filetext;

        // saved levels file
        public string res_lvl_filepath = "SaveFile.txt";
        string s_fileText;

        // achievement file
        public string res_Achs_filepath = "AchievementFile.txt";
        string a_fileTexT;

        // coins
        public int GlobalCoins;
        public bool isDefaultCoin;

        // time
        public int loadtime;

        // Getter & setter to uncover the existing 'MainMenu' form
        public Form SMLMainMenuRef { get; set; }

        // Getter & setter for level completion detection
        public string LC { get; set; }

        public int intLevel;
        public void btn_LevelChoice_Click(object sender, EventArgs e)
        {
            // if button 'Tutorial' was pressed
            if (sender == btn_TutorialLevel)
            {
                intLevel = 0;
                StartGame(intLevel);
            }

            // if button '1' was pressed
            if (sender == btn_LevelOne)
            {
                // read contents from the file
                t_filetext = File.ReadAllText(res_Tut_filepath);

                // if tutorial is not completed
                if (t_filetext.Contains("0"))
                {
                    DialogResult choice = MessageBox.Show("Are you sure you don't want to learn basics of this game?", "Start level one immediately?", MessageBoxButtons.YesNo);
                    switch (choice)
                    {
                        // if user wants to avoid tutorial
                        case DialogResult.Yes:

                            // assume that user knows the game process and complete the tutorial
                            string replacedText = t_filetext.Replace("0", "1");
                            File.WriteAllText(res_Tut_filepath, replacedText);
                            FormProvider.SETT_Form.CB_Guider.Checked = false;
                            intLevel = 1;
                            StartGame(intLevel);
                            break;
                    }
                }

                // if tutorial is completed
                else
                {
                    intLevel = 1;
                    StartGame(intLevel);
                }
            }

            // if button '2' was pressed
            if (sender == btn_LevelTwo)
            {
                intLevel = 2;
                StartGame(intLevel);
            }
            
            // if button '3' was pressed
            if (sender == btn_LevelThree)
            {
                intLevel = 3;
                StartGame(intLevel);
            }
            
            // if button '4' was pressed
            if (sender == btn_LevelFour)
            {
                intLevel = 4;
                StartGame(intLevel);
            }
            
            // if button '5' was pressed
            if (sender == btn_LevelFive)
            {
                intLevel = 5;
                StartGame(intLevel);
            }
            
            // if button '6' was pressed
            if (sender == btn_LevelSix)
            {
                intLevel = 6;
                StartGame(intLevel);
            }
            
            // if button '7' was pressed
            if (sender == btn_LevelSeven)
            {
                intLevel = 7;
                StartGame(intLevel);
            }
            
            // if button '8' was pressed
            if (sender == btn_LevelEight)
            {
                intLevel = 8;
                StartGame(intLevel);
            }
            
            // if button '9' was pressed
            if (sender == btn_LevelNine)
            {
                intLevel = 9;
                StartGame(intLevel);
            }
            
            // if button '10' was pressed
            if (sender == btn_LevelTen)
            {
                intLevel = 10;
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

            // ...route the value from 'MainMenu' form to the final destination
            GameForm.SMLMainMenuRef_INGameForm = this.SMLMainMenuRef;

            // if the music player from main menu has music assigned in it
            // & user enabled the music in settings
            if (FormProvider.MainMenu_Form.m_MusicPlayer == null && FormProvider.SETT_Form.CB_Music.Checked)
            {
                // get music player from main menu and assign music into it
                FormProvider.MainMenu_Form.str_Music = Properties.Resources.MusicMix;
                FormProvider.MainMenu_Form.m_MusicPlayer = new System.Media.SoundPlayer(FormProvider.MainMenu_Form.str_Music);
                FormProvider.MainMenu_Form.m_MusicPlayer.PlayLooping();
            }

            // check tutorial file
            if (intLevel == 0)
            {
                // read contents from the file
                t_filetext = File.ReadAllText(res_Tut_filepath);

                if (t_filetext.Contains("0"))
                {
                    GameForm.isDefaultT = true;
                }
                else
                {
                    GameForm.isDefaultT = false;
                }
            }

            GameForm.intCoins = GlobalCoins;
            GameForm.VarTimeLoad = loadtime;

            GameForm.ParentForm = this;
            this.Hide();
            GameForm.Show();
        }

        // if 'Go Back' button was pressed
        private void btn_Back_Click(object sender, EventArgs e)
        {
            this.Close();
            FormProvider.CGT_Form.Show();
        }

        // if the red cross was pressed
        private void StoryModeLevels_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
            // show hidden form
            //FormProvider.CGT_Form.Show();

        }

        // load up levels that were possibly completed before
        private void SavedLevels()
        {
            // read all levels
            s_fileText = File.ReadAllText(res_lvl_filepath);

            // --- 
            // detect if certain levels were completed
            
            // level 1 completed
            if (s_fileText.Contains("LevelOne = 1"))
            {
                btn_LevelTwo.Enabled = true;
            }

            // level 2 completed
            if (s_fileText.Contains("LevelTwo = 1"))
            {
                btn_LevelTwo.Enabled = true;
                btn_LevelThree.Enabled = true;
            }
            
            // level 3 completed
            if (s_fileText.Contains("LevelThree = 1"))
            {
                btn_LevelTwo.Enabled = true;
                btn_LevelThree.Enabled = true;
                btn_LevelFour.Enabled = true;
            }
            
            // level 4 completed
            if (s_fileText.Contains("LevelFour = 1"))
            {
                btn_LevelTwo.Enabled = true;
                btn_LevelThree.Enabled = true;
                btn_LevelFour.Enabled = true;
                btn_LevelFive.Enabled = true;
            }
            
            // level 5 completed
            if (s_fileText.Contains("LevelFive = 1"))
            {
                btn_LevelTwo.Enabled = true;
                btn_LevelThree.Enabled = true;
                btn_LevelFour.Enabled = true;
                btn_LevelFive.Enabled = true;
                btn_LevelSix.Enabled = true;
            }
            
            // level 6 completed
            if (s_fileText.Contains("LevelSix = 1"))
            {
                btn_LevelTwo.Enabled = true;
                btn_LevelThree.Enabled = true;
                btn_LevelFour.Enabled = true;
                btn_LevelFive.Enabled = true;
                btn_LevelSix.Enabled = true;
                btn_LevelSeven.Enabled = true;
            }
            
            // level 7 completed
            if (s_fileText.Contains("LevelSeven = 1"))
            {
                btn_LevelTwo.Enabled = true;
                btn_LevelThree.Enabled = true;
                btn_LevelFour.Enabled = true;
                btn_LevelFive.Enabled = true;
                btn_LevelSix.Enabled = true;
                btn_LevelSeven.Enabled = true;
                btn_LevelEight.Enabled = true;
            }
            
            // level 8 completed
            if (s_fileText.Contains("LevelEight = 1"))
            {
                btn_LevelTwo.Enabled = true;
                btn_LevelThree.Enabled = true;
                btn_LevelFour.Enabled = true;
                btn_LevelFive.Enabled = true;
                btn_LevelSix.Enabled = true;
                btn_LevelSeven.Enabled = true;
                btn_LevelEight.Enabled = true;
                btn_LevelNine.Enabled = true;
            }
            
            // level 9 completed
            if (s_fileText.Contains("LevelNine = 1"))
            {
                btn_LevelTwo.Enabled = true;
                btn_LevelThree.Enabled = true;
                btn_LevelFour.Enabled = true;
                btn_LevelFive.Enabled = true;
                btn_LevelSix.Enabled = true;
                btn_LevelSeven.Enabled = true;
                btn_LevelEight.Enabled = true;
                btn_LevelNine.Enabled = true;
                btn_LevelTen.Enabled = true;
            }
            
            // level 10 completed
            if (s_fileText.Contains("LevelTen = 1"))
            {
                btn_LevelTwo.Enabled = true;
                btn_LevelThree.Enabled = true;
                btn_LevelFour.Enabled = true;
                btn_LevelFive.Enabled = true;
                btn_LevelSix.Enabled = true;
                btn_LevelSeven.Enabled = true;
                btn_LevelEight.Enabled = true;
                btn_LevelNine.Enabled = true;
                btn_LevelTen.Enabled = true;
            }

            // ---
        }

        public void SavedAchievements(bool lvlAch_obtained, int isLevel)
        {
            // if achievement from the tutorial was obtained
            if (lvlAch_obtained && isLevel == 0)
            {
                // read the 'achievements' text file
                string fileTexT = File.ReadAllText(res_Achs_filepath);

                // check the first achievement
                if (fileTexT.Contains("AchievementOne = 0"))
                {
                    string replacedTxT = fileTexT.Replace("AchievementOne = 0", "AchievementOne = 1");
                    File.WriteAllText(res_Achs_filepath, replacedTxT);

                }
            }

            // if achievement from the level two was obtained
            if (lvlAch_obtained && isLevel == 2)
            {
                // read the 'achievements' text file
                string fileTexT = File.ReadAllText(res_Achs_filepath);

                // check the second achievement
                if (fileTexT.Contains("AchievementTwo = 0"))
                {
                    string replacedTxT = fileTexT.Replace("AchievementTwo = 0", "AchievementTwo = 1");
                    File.WriteAllText(res_Achs_filepath, replacedTxT);

                }
            }
        }

        // load up coins into current player's bank
        public void CoinLoad()
        {
            // call in a serial class as well as a load method for loading player's bank
            List<SaveLoadSerial_Coins> saveloadSerial_Coins = LoadPlayerData();

            // go through each item in bank
            foreach (var item in saveloadSerial_Coins)
            {
                // declare coins from data as variable coins here
                GlobalCoins = item.Coins;

            }

            /*
            // read contents from a file
            c_filetext = File.ReadAllText(res_Coin_filepath);

            // if coins are default
            if (c_filetext.Contains("isDefault = 1"))
            {
                string replacedtxt = c_filetext.Replace("isDefault = 1", "isDefault = 0");
                File.WriteAllText(res_Coin_filepath, replacedtxt);


                isDefaultCoin = true;
                //FormProvider.TheGame_Form.intCoins = 1;
            }
            // otherwise
            else
            {
                isDefaultCoin = false;

                if (c_filetext.Contains("Coins = ") && GlobalCoins == 0)
                {
                    FormProvider.TheGame_Form.intCoins = 0;
                }
                else if (c_filetext.Contains("Coins = ") && GlobalCoins > 1)
                {
                    FormProvider.TheGame_Form.intCoins = GlobalCoins;
                }



                File.WriteAllText(res_Coin_filepath, "Coins = " + GlobalCoins + "\nisDefault = 0");

            }

            //File.WriteAllText(res_Coin_filepath, "Coins = " + intCoins);
            */
        }

        // the game stores current coins into the file
        public void CoinSave(int intCoins)
        {
            // read the file
            var filepath = "playerCoins_Data.txt";
            string jsonReader = File.ReadAllText(filepath);

            // deserialize using json
            var jsonD = JsonConvert.DeserializeObject<List<SaveLoadSerial_Coins>>(jsonReader);
            jsonD.Clear();
            jsonD.Add(new SaveLoadSerial_Coins(intCoins));

            var jsonS = JsonConvert.SerializeObject(jsonD);


            File.WriteAllText(filepath, jsonS);

            // add the coins to serialization constructor
            //SaveLoadSerial.Add(new SaveLoadSerial_Coins(intCoins));

            //SavePlayerCoins(json, jsonReader);

            // save coins to a file
            //SavePlayerCoins(SaveLoadSerial);
        }

        // saving coins to a file
        private static void SavePlayerCoins(List<SaveLoadSerial_Coins> SaveLoadSerial_json)
        {
            //File.WriteAllText(jR, JsonConvert.SerializeObject(SaveLoadSerial_json));

            //File.WriteAllText("playerCoins_Data.txt", ;//new JavaScriptSerializer().Serialize(SaveLoadSerial));
        }

        // loading player data
        private static List<SaveLoadSerial_Coins> LoadPlayerData()
        {

            if (File.Exists("playerCoins_Data.txt"))
            {
                // read the file
                var json = File.ReadAllText("playerCoins_Data.txt");

                // if coins (JSON) file is empty
                if (json == "")
                {
                    File.WriteAllText("playerCoins_Data.txt", "[{\"Coins\":0}]");
                    json = File.ReadAllText("playerCoins_Data.txt");
                }

                // read each content through JSON
                var jsonLoad = JsonConvert.DeserializeObject<List<SaveLoadSerial_Coins>>(json);

                // foreach content
                foreach (var jL in jsonLoad)
                {
                    // store the content as integer once found appropriate integer
                    int i = jL.Coins;
                }
                
                return jsonLoad;

                // store file contents within the program
                //var filecontents = File.ReadAllText("playerCoins_Data.txt");



                /*
                // split every string from the file
                int intValue = 1;
                string[] values = filecontents.Split();

                // loop through the splitted strings
                foreach (var value in values) 
                {
                    MessageBox.Show(value);

                    // if the string is detected as a number
                    if (Int32.TryParse(value.Trim(), out intValue))
                    {
                        MessageBox.Show(Convert.ToString(value));
                    }
                }
                */

                //return new result;
            }
            else return new List<SaveLoadSerial_Coins>();
        }


        // saving achievement trophies to a file
        private static void SavePlayerTrophies(List<SaveLoadSerial_Trophies> SaveLoadSerial)
        {
            //File.WriteAllText("playerCoins_Data.txt", new JavaScriptSerializer().Serialize(SaveLoadSerial));
        }

        public void StoreTime(int timeload)
        {
            loadtime = timeload;
        }

        // after certain level has been completed
        public void LevelCompleted(string LC, DialogResult endlvl)
        {
            // Tutorial
            if (LC == "0")
            {

                // if tutorial text file exists
                if (File.Exists(res_Tut_filepath))
                {
                    // read contents from that specific file
                    t_filetext = System.IO.File.ReadAllText(res_Tut_filepath);

                    // if 0 exists
                    if (t_filetext.Contains("0"))
                    {
                        // replace 0 with 1
                        string replacedText = t_filetext.Replace("0", "1");
                        File.WriteAllText(res_Tut_filepath, replacedText);
                    }
                }
                
                // if achievements text file exists
                if (File.Exists(res_Achs_filepath))
                {
                    if (FormProvider.TheGame_Form.AchievementOne_Obtained)
                    {
                        a_fileTexT = File.ReadAllText(res_Achs_filepath);

                        if (a_fileTexT.Contains("AchievementOne = 0"))
                        {
                            string replacedText = a_fileTexT.Replace("0", "1");
                            File.WriteAllText(res_Achs_filepath, replacedText);
                        }

                    }
                    
                    if (FormProvider.TheGame_Form.AchievementTwo_Obtained)
                    {
                        a_fileTexT = File.ReadAllText(res_Achs_filepath);

                        if (a_fileTexT.Contains("AchievementTwo = 0"))
                        {
                            string replacedText = a_fileTexT.Replace("0", "1");
                            File.WriteAllText(res_Achs_filepath, replacedText);
                        }

                    }
                }

                // if user decided to automatically move to next level
                if (endlvl == DialogResult.Yes)
                {
                    intLevel = 1;
                    CoinLoad();
                    StartGame(intLevel);

                    this.Hide();
                }
                
                // otherwise, return this form
                else 
                {
                    // disable the music if it was turned on
                    if (FormProvider.MainMenu_Form.m_MusicPlayer != null)
                    {
                        FormProvider.MainMenu_Form.m_MusicPlayer.Stop();
                        FormProvider.MainMenu_Form.m_MusicPlayer = null;
                    }

                    FormProvider.MainMenu_Form.Show();
                }

            }

            // level One
            if (LC == "1")
            {

                // if level file exists
                if (File.Exists(res_lvl_filepath))
                {
                    // read that text file containing all levels
                    s_fileText = System.IO.File.ReadAllText(res_lvl_filepath);

                    // if that file contains level ONE that is not completed
                    if (s_fileText.Contains("LevelOne = 0"))
                    {
                        // replace uncompleted level with completed
                        string replacedlvlText = s_fileText.Replace("LevelOne = 0", "LevelOne = 1");
                        File.WriteAllText(res_lvl_filepath, replacedlvlText);

                        // enable next level
                        btn_LevelTwo.Enabled = true;
                    }
                }

                
                // if user decided to automatically move to next level
                if (endlvl == DialogResult.Yes)
                {

                    intLevel = 2;
                    CoinLoad();
                    StartGame(intLevel);

                    this.Hide();
                }

                // otherwise, return this form
                else
                {

                    if (FormProvider.MainMenu_Form.m_MusicPlayer != null)
                    {
                        FormProvider.MainMenu_Form.m_MusicPlayer.Stop();
                        FormProvider.MainMenu_Form.m_MusicPlayer = null;
                    }
                    FormProvider.MainMenu_Form.Show();
                }
            }

            // level Two
            if (LC == "2")
            {
                // if that file contains level TWO that is not completed
                if (s_fileText.Contains("LevelTwo = 0"))
                {
                    // replace uncompleted level with completed
                    string replacedlvlText = s_fileText.Replace("LevelTwo = 0", "LevelTwo = 1");
                    File.WriteAllText(res_lvl_filepath, replacedlvlText);

                    // enable next level
                    btn_LevelThree.Enabled = true;

                }

                // if user decided to automatically move to next level
                if (endlvl == DialogResult.Yes)
                {
                    intLevel = 3;
                    CoinLoad();
                    StartGame(intLevel);

                    this.Hide();
                }

                // otherwise, return this form
                else
                {
                    if (FormProvider.MainMenu_Form.m_MusicPlayer != null)
                    {
                        FormProvider.MainMenu_Form.m_MusicPlayer.Stop();
                        FormProvider.MainMenu_Form.m_MusicPlayer = null;
                    }
                    FormProvider.MainMenu_Form.Show();
                }
            }
            
            // level Three
            if (LC == "3")
            {
                // if that file contains level THREE that is not completed
                if (s_fileText.Contains("LevelThree = 0"))
                {
                    // replace uncompleted level with completed
                    string replacedlvlText = s_fileText.Replace("LevelThree = 0", "LevelThree = 1");
                    File.WriteAllText(res_lvl_filepath, replacedlvlText);

                    // enable next level
                    btn_LevelFour.Enabled = true;
                }

                // if user decided to automatically move to next level
                if (endlvl == DialogResult.Yes)
                {
                    intLevel = 4;
                    CoinLoad();
                    StartGame(intLevel);

                    this.Hide();
                }

                // otherwise, return this form
                else
                {
                    if (FormProvider.MainMenu_Form.m_MusicPlayer != null)
                    {
                        FormProvider.MainMenu_Form.m_MusicPlayer.Stop();
                        FormProvider.MainMenu_Form.m_MusicPlayer = null;
                    }
                    FormProvider.MainMenu_Form.Show();
                }
            }
            
            // level Four
            if (LC == "4")
            {
                // if that file contains level FOUR that is not completed
                if (s_fileText.Contains("LevelFour = 0"))
                {
                    // replace uncompleted level with completed
                    string replacedlvlText = s_fileText.Replace("LevelFour = 0", "LevelFour = 1");
                    File.WriteAllText(res_lvl_filepath, replacedlvlText);

                    // enable next level
                    btn_LevelFive.Enabled = true;
                }

                // if user decided to automatically move to next level
                if (endlvl == DialogResult.Yes)
                {
                    intLevel = 5;
                    CoinLoad();
                    StartGame(intLevel);

                    this.Hide();
                }

                // otherwise, return this form
                else
                {
                    if (FormProvider.MainMenu_Form.m_MusicPlayer != null)
                    {
                        FormProvider.MainMenu_Form.m_MusicPlayer.Stop();
                        FormProvider.MainMenu_Form.m_MusicPlayer = null;
                    }
                    FormProvider.MainMenu_Form.Show();
                }
            }

            // level five
            if (LC == "5")
            {
                // if that file contains level FIVE that is not completed
                if (s_fileText.Contains("LevelFive = 0"))
                {
                    // replace uncompleted level with completed
                    string replacedlvlText = s_fileText.Replace("LevelFive = 0", "LevelFive = 1");
                    File.WriteAllText(res_lvl_filepath, replacedlvlText);

                    // enable next level
                    btn_LevelSix.Enabled = true;
                }

                // if user decided to automatically move to next level
                if (endlvl == DialogResult.Yes)
                {
                    intLevel = 6;
                    CoinLoad();
                    StartGame(intLevel);

                    this.Hide();
                }

                // otherwise, return this form
                else
                {
                    if (FormProvider.MainMenu_Form.m_MusicPlayer != null)
                    {
                        FormProvider.MainMenu_Form.m_MusicPlayer.Stop();
                        FormProvider.MainMenu_Form.m_MusicPlayer = null;
                    }
                    FormProvider.MainMenu_Form.Show();
                }
            }
            
            // level six
            if (LC == "6")
            {
                // if that file contains level SIX that is not completed
                if (s_fileText.Contains("LevelSix = 0"))
                {
                    // replace uncompleted level with completed
                    string replacedlvlText = s_fileText.Replace("LevelSix = 0", "LevelSix = 1");
                    File.WriteAllText(res_lvl_filepath, replacedlvlText);

                    // enable next level
                    btn_LevelSeven.Enabled = true;
                }

                // if user decided to automatically move to next level
                if (endlvl == DialogResult.Yes)
                {
                    intLevel = 7;
                    CoinLoad();
                    StartGame(intLevel);

                    this.Hide();
                }

                // otherwise, return this form
                else
                {
                    if (FormProvider.MainMenu_Form.m_MusicPlayer != null)
                    {
                        FormProvider.MainMenu_Form.m_MusicPlayer.Stop();
                        FormProvider.MainMenu_Form.m_MusicPlayer = null;
                    }
                    FormProvider.MainMenu_Form.Show();
                }
            }
            
            // level seven
            if (LC == "7")
            {
                // if that file contains level SEVEN that is not completed
                if (s_fileText.Contains("LevelSeven = 0"))
                {
                    // replace uncompleted level with completed
                    string replacedlvlText = s_fileText.Replace("LevelSeven = 0", "LevelSeven = 1");
                    File.WriteAllText(res_lvl_filepath, replacedlvlText);

                    // enable next level
                    btn_LevelEight.Enabled = true;
                }

                // if user decided to automatically move to next level
                if (endlvl == DialogResult.Yes)
                {
                    intLevel = 8;
                    CoinLoad();
                    StartGame(intLevel);

                    this.Hide();
                }

                // otherwise, return this form
                else
                {
                    if (FormProvider.MainMenu_Form.m_MusicPlayer != null)
                    {
                        FormProvider.MainMenu_Form.m_MusicPlayer.Stop();
                        FormProvider.MainMenu_Form.m_MusicPlayer = null;
                    }
                    FormProvider.MainMenu_Form.Show();
                }
            }
            
            // level eight
            if (LC == "8")
            {
                // if that file contains level EIGHT that is not completed
                if (s_fileText.Contains("LevelEight = 0"))
                {
                    // replace uncompleted level with completed
                    string replacedlvlText = s_fileText.Replace("LevelEight = 0", "LevelEight = 1");
                    File.WriteAllText(res_lvl_filepath, replacedlvlText);

                    // enable next level
                    btn_LevelNine.Enabled = true;
                }

                // if user decided to automatically move to next level
                if (endlvl == DialogResult.Yes)
                {
                    intLevel = 9;
                    CoinLoad();
                    StartGame(intLevel);

                    this.Hide();
                }

                // otherwise, return this form
                else
                {
                    if (FormProvider.MainMenu_Form.m_MusicPlayer != null)
                    {
                        FormProvider.MainMenu_Form.m_MusicPlayer.Stop();
                        FormProvider.MainMenu_Form.m_MusicPlayer = null;
                    }
                    FormProvider.MainMenu_Form.Show();
                }
            }
            
            // level nine
            if (LC == "9")
            {
                // if that file contains level NINE that is not completed
                if (s_fileText.Contains("LevelNine = 0"))
                {
                    // replace uncompleted level with completed
                    string replacedlvlText = s_fileText.Replace("LevelNine = 0", "LevelNine = 1");
                    File.WriteAllText(res_lvl_filepath, replacedlvlText);

                    // enable next level
                    btn_LevelTen.Enabled = true;
                }

                // if user decided to automatically move to next level
                if (endlvl == DialogResult.Yes)
                {
                    intLevel = 10;
                    StartGame(intLevel);

                    this.Hide();
                }

                // otherwise, return this form
                else
                {
                    if (FormProvider.MainMenu_Form.m_MusicPlayer != null)
                    {
                        FormProvider.MainMenu_Form.m_MusicPlayer.Stop();
                        FormProvider.MainMenu_Form.m_MusicPlayer = null;
                    }
                    FormProvider.MainMenu_Form.Show();
                }
            }

            // level ten
            if (LC == "10")
            {
                // if that file contains level NINE that is not completed
                if (s_fileText.Contains("LevelTen = 0"))
                {
                    // replace uncompleted level with completed
                    string replacedlvlText = s_fileText.Replace("LevelTen = 0", "LevelTen = 1");
                    File.WriteAllText(res_lvl_filepath, replacedlvlText);
                }

                // check achievement, if normal mode was completed just now
                if (File.Exists(res_Achs_filepath))
                {
                    a_fileTexT = File.ReadAllText(res_Achs_filepath);

                    if (a_fileTexT.Contains("AchievementThree = 0"))
                    {
                        // replace unobtained achievement with obtained
                        string replacedachvText = a_fileTexT.Replace("AchievementThree = 0", "AchievementThree = 1");
                        File.WriteAllText(res_Achs_filepath, replacedachvText);
                    }
                }

                FormProvider.CGT_Form.ReadFile();

                // otherwise, return this form
                if (FormProvider.MainMenu_Form.m_MusicPlayer != null)
                {
                    FormProvider.MainMenu_Form.m_MusicPlayer.Stop();
                    FormProvider.MainMenu_Form.m_MusicPlayer = null;
                }
               
                FormProvider.MainMenu_Form.Show();

            }
        }

        public void StoryModeLevels_Load(object sender, EventArgs e)
        {

            // load up potentially saved levels
            SavedLevels();

            CoinLoad();
        }
    }
}
