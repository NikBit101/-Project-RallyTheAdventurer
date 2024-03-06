using _Project__Platformer.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace _Project__Platformer
{
    public partial class TheGame : Form
    {
        // Getter & setter to uncover the existing 'MainMenu' form
        public Form SMLMainMenuRef_INGameForm { get; set; }
        public Form ParentForm { get; set; }

        // call in a class that'll store name and time
        private _Project__Platformer.StatsLoad newScore;

        public TheGame()
        {
            InitializeComponent();

            // don't let the user change form's size
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
        }

        //
        public int VarTimeLoad;

        // set music ON or OFF through this code
        public int musicCode = 1;

        // booleans for no key repeat bugs
        private bool blnKeyLeft = false;
        private bool blnKeyRight = false;
        private bool blnKeyUp = false;
        private bool blnKeyDown = false;

        // boolean for interaction button
        private bool blnInteractKey = false;

        // platforms array
        PictureBox[] array_pbPlatforms = new PictureBox[30];
        
        // platforms as walls array
        PictureBox[] array_pbPlatformWalls = new PictureBox[10];

        public Control ctrl = new Control();

        enum CodedObjects
        {
            // enemy units
            Tag_Enemy = 0,
            Tag_Enemy2 = 1,
            Tag_Enemy3 = 2,
            Tag_Enemy4 = 3,
            Tag_Enemy5 = 4,
            Tag_Enemy6 = 5,
            
            // key
            Tag_Key = 6,
            // ladders
            Tag_Ladder = 7,
            // exit door
            Tag_Exit = 8,
            // text to indicate key being obtained
            Tag_KeyText = 9,
            // shop for player to interact with
            Tag_Shop = 10,
            // coin for a player to collect
            Tag_Coin = 11,
            // achievement unit
            Tag_Achievement = 12,
            // platform in which achievement would be obtained
            Tag_AchPlat = 13,

            // floating platform
            Tag_MovePlat = 14,
            Tag_MovePlat2 = 15,
            Tag_MovePlat3 = 16,
            Tag_MovePlat4 = 17,
            Tag_MovePlat5 = 18,
            Tag_MovePlat6 = 19

        }

        // player lives
        int intLives = 5;

        // indicate a life being lost for certain events (avoid some bugs associated with losing life)
        bool livelost;
        bool isDoor = false;

        // Coordinates and velocity
        double xVel = 0;
        double yVel = 0;
        double yVel_Enemy = 0;
        double yVel_Enemy2 = 0;

        // player's bank (by default one coin)
        public bool isDefaultT;
        public int intCoins;

        // Double Jump feature
        public bool isDouble;
        public bool DoubleInitiated;

        // amount of jumps and available jumps (avoid multiple jump bugs)
        int intPlayerJump = 0;
        int intMaxJump = 1;

        // which level is it?
        public int isLevel;

        // pause menu
        public bool blnInPause = false;

        // enemy movement
        int Xvel_enemy = -2;
        int Xvel_enemy2 = -1;
        int Xvel_enemy3 = -1;
        int Xvel_enemy4 = -1;

        // platform floating X
        int Xvel_platform = -2;
        int Xvel_platform2 = -2;
        int Xvel_platform3 = -2;
        
        // platform floating Y
        int Yvel_platform = -2;
        int Yvel_platform2 = -2;
        int Yvel_platform3 = -2;
        int Yvel_platform4 = -2;
        int Yvel_platform5 = -2;


        // level completed?
        public bool isCompleted;

        // achievement detectors
        public bool A1_Obtained;
        public bool AchievementOne_Obtained;
        public bool A2_Obtained;
        public bool AchievementTwo_Obtained;

        public bool AchievementObtained;

        // Determine the level from 'intLevel' value from 'StoryModeLevels' chosen buttons
        public void LevelDetermine(int intLevel)
        {
            // ---
            // [TUTORIAL] if tutorial level is chosen
            if (intLevel == 0)
            {

                isLevel = 0;

                // create an animated background image
                PictureBox pb_BackgroundGif = new PictureBox();
                Controls.Add(pb_BackgroundGif);
                pb_BackgroundGif.Image = Resources.gifBackground;
                pb_BackgroundGif.Dock = DockStyle.Fill;
                pb_BackgroundGif.SendToBack();

                // player (already existing)
                PIC_Player.Location = new Point(22, 425);
                PIC_Player.Parent = pb_BackgroundGif;
                PIC_Player.BringToFront();

                // creating platform 1
                PictureBox pic_Platform1_Ground = new PictureBox();
                Controls.Add(pic_Platform1_Ground);
                pic_Platform1_Ground.BackColor = Color.Lime;
                pic_Platform1_Ground.Location = new Point(0, 507);
                pic_Platform1_Ground.Size = new Size(220, 10);
                pic_Platform1_Ground.BringToFront();

                // creating platform 2
                PictureBox pic_Platform2_Ground = new PictureBox();
                Controls.Add(pic_Platform2_Ground);
                pic_Platform2_Ground.BackColor = Color.Lime;
                pic_Platform2_Ground.Location = new Point(300, 507);
                pic_Platform2_Ground.Size = new Size(515, 10);
                pic_Platform2_Ground.BringToFront();

                // creating platform 3
                PictureBox pic_Platform3_Right = new PictureBox();
                Controls.Add(pic_Platform3_Right);
                pic_Platform3_Right.BackColor = Color.Lime;
                pic_Platform3_Right.Location = new Point(735, 430);
                pic_Platform3_Right.Size = new Size(80, 10);
                pic_Platform3_Right.BringToFront();

                // creating platform 4
                PictureBox pic_Platform4 = new PictureBox();
                Controls.Add(pic_Platform4);
                pic_Platform4.BackColor = Color.Lime;
                pic_Platform4.Location = new Point(270, 320);
                pic_Platform4.Size = new Size(70, 10);
                pic_Platform4.BringToFront();

                // creating platform 5
                PictureBox pic_Platform5 = new PictureBox();
                Controls.Add(pic_Platform5);
                pic_Platform5.BackColor = Color.Lime;
                pic_Platform5.Location = new Point(380, 410);
                pic_Platform5.Size = new Size(50, 10);
                pic_Platform5.BringToFront();

                // creating platform 6
                PictureBox pic_Platform6 = new PictureBox();
                Controls.Add(pic_Platform6);
                pic_Platform6.BackColor = Color.Lime;
                pic_Platform6.Location = new Point(735, 270);
                pic_Platform6.Size = new Size(80, 10);
                pic_Platform6.BringToFront();

                // creating platform 7
                PictureBox pic_Platform7 = new PictureBox();
                Controls.Add(pic_Platform7);
                pic_Platform7.BackColor = Color.Lime;
                pic_Platform7.Location = new Point(590, 350);
                pic_Platform7.Size = new Size(75, 10);
                pic_Platform7.BringToFront();

                // creating platform 8
                PictureBox pic_Platform8 = new PictureBox();
                Controls.Add(pic_Platform8);
                pic_Platform8.BackColor = Color.Lime;
                pic_Platform8.Location = new Point(590, 200);
                pic_Platform8.Size = new Size(75, 10);
                pic_Platform8.BringToFront();

                // creating platform 9 (achievement)
                PictureBox pic_AchPlatform = new PictureBox();
                Controls.Add(pic_AchPlatform);
                pic_AchPlatform.BackColor = Color.Green;
                pic_AchPlatform.Enabled = false;
                pic_AchPlatform.Location = new Point(780, 100);
                pic_AchPlatform.Size = new Size(40, 10);
                pic_AchPlatform.BringToFront();
                pic_AchPlatform.Tag = CodedObjects.Tag_AchPlat;

                // creating platform 10
                PictureBox pic_Platform10 = new PictureBox();
                Controls.Add(pic_Platform10);
                pic_Platform10.BackColor = Color.Lime;
                pic_Platform10.Location = new Point(300, 130);
                pic_Platform10.Size = new Size(210, 10);
                pic_Platform10.BringToFront();

                // creating platform 11
                PictureBox pic_Platform11 = new PictureBox();
                Controls.Add(pic_Platform11);
                pic_Platform11.BackColor = Color.Lime;
                pic_Platform11.Location = new Point(170, 130);
                pic_Platform11.Size = new Size(70, 10);
                pic_Platform11.BringToFront();

                // creating platform 12
                PictureBox pic_Platform12 = new PictureBox();
                Controls.Add(pic_Platform12);
                pic_Platform12.BackColor = Color.Lime;
                pic_Platform12.Location = new Point(170, 0);
                pic_Platform12.Size = new Size(10, 130);
                pic_Platform12.BringToFront();


                // creating a ladder
                PictureBox pic_Ladder = new PictureBox();
                Controls.Add(pic_Ladder);
                pic_Ladder.Image = Resources.ladder;
                pic_Ladder.SizeMode = PictureBoxSizeMode.StretchImage;
                pic_Ladder.Size = new Size(15, 380);
                pic_Ladder.BackColor = Color.Transparent;
                pic_Ladder.Location = new Point(5, 120);
                pic_Ladder.BringToFront();
                pic_Ladder.Tag = CodedObjects.Tag_Ladder;

                // creating a key
                PictureBox pic_Key = new PictureBox();
                Controls.Add(pic_Key);
                pic_Key.Image = Resources.A_Key;
                pic_Key.BackColor = Color.Transparent;
                pic_Key.SizeMode = PictureBoxSizeMode.StretchImage;
                pic_Key.Size = new Size(50, 30);
                pic_Key.Location = new Point(190, 80);
                pic_Key.BringToFront();
                pic_Key.Tag = CodedObjects.Tag_Key;

                // creating notification about obtaining a key
                Label lbl_KeyObtained = new Label();
                Controls.Add(lbl_KeyObtained);
                lbl_KeyObtained.Location = new Point(0, 450);
                lbl_KeyObtained.Size = new Size(120, 50);
                lbl_KeyObtained.Font = new Font("Comic Sans MS", 22, FontStyle.Bold);
                lbl_KeyObtained.ForeColor = Color.Yellow;
                lbl_KeyObtained.BackColor = Color.Black;
                lbl_KeyObtained.BringToFront();
                lbl_KeyObtained.Text = "1 Key";
                lbl_KeyObtained.Visible = false;
                lbl_KeyObtained.Tag = CodedObjects.Tag_KeyText;

                // creating an exit door
                PictureBox pic_Exit = new PictureBox();
                Controls.Add(pic_Exit);
                pic_Exit.Size = new Size(40, 50);
                pic_Exit.SizeMode = PictureBoxSizeMode.StretchImage;
                pic_Exit.Location = new Point(0, 70);
                pic_Exit.Image = Resources.Door_Closed;
                pic_Exit.BringToFront();
                pic_Exit.Tag = CodedObjects.Tag_Exit;

                // create an enemy unit
                PictureBox pic_Enemy = new PictureBox();
                Controls.Add(pic_Enemy);
                pic_Enemy.Image = Resources.EnemyMONSTER_org;
                pic_Enemy.Size = new Size(40, 30);
                pic_Enemy.Location = new Point(300, 100);
                pic_Enemy.SizeMode = PictureBoxSizeMode.StretchImage;
                pic_Enemy.BringToFront();
                pic_Enemy.Tag = CodedObjects.Tag_Enemy;

                // create a shop
                PictureBox pic_Shop = new PictureBox();
                Controls.Add(pic_Shop);
                pic_Shop.Image = Resources.shop2D;
                pic_Shop.Location = new Point(275, 270);
                pic_Shop.Size = new Size(60, 50);
                pic_Shop.SizeMode = PictureBoxSizeMode.StretchImage;
                pic_Shop.BringToFront();
                pic_Shop.Tag = CodedObjects.Tag_Shop;

                // coin
                PictureBox pic_Coin = new PictureBox();
                Controls.Add(pic_Coin);
                pic_Coin.Image = Resources._2dcoin;
                pic_Coin.Location = new Point(390, 190);
                pic_Coin.Size = new Size(25, 25);
                pic_Coin.SizeMode = PictureBoxSizeMode.StretchImage;
                pic_Coin.BringToFront();
                pic_Coin.Tag = CodedObjects.Tag_Coin;

                // create a achievement object to be obtained
                PictureBox pbAchievement = new PictureBox();
                Controls.Add(pbAchievement);
                pbAchievement.Image = Resources.Atrophy1;
                pbAchievement.Location = new Point(770, 10);
                pbAchievement.Size = new Size(40, 40);
                pbAchievement.SizeMode = PictureBoxSizeMode.StretchImage;
                pbAchievement.BringToFront();
                pbAchievement.Enabled = false;
                pbAchievement.Visible = false;
                pbAchievement.Tag = CodedObjects.Tag_Achievement;

                // [SETTINGS] 
                // if guider is set ON
                if (FormProvider.SETT_Form.CB_Guider.Checked)
                {
                    GuiderDoTeach();
                }

                // store 16 platforms into this array
                array_pbPlatforms[0] = pic_Platform1_Ground;
                array_pbPlatforms[1] = pic_Platform2_Ground;
                array_pbPlatforms[2] = pic_Platform3_Right;
                array_pbPlatforms[3] = pic_Platform4;
                array_pbPlatforms[4] = pic_Platform5;
                array_pbPlatforms[5] = pic_Platform6;
                array_pbPlatforms[6] = pic_Platform7;

                array_pbPlatforms[7] = pic_Platform8;
                array_pbPlatforms[8] = pic_Platform10;
                array_pbPlatforms[9] = pic_Platform11;

                // store a wall into its array
                array_pbPlatformWalls[0] = pic_Platform12;
            }

            // ---
            // [LEVEL ONE] if level one is chosen
            if (intLevel == 1)
            {
                // it IS a first level
                isLevel = 1;

                // set player's location
                PIC_Player.Location = new Point(22, 430);

                // create an animated background image
                PictureBox pb_BackgroundGif = new PictureBox();
                Controls.Add(pb_BackgroundGif);
                pb_BackgroundGif.Image = Resources.gifBackground;
                pb_BackgroundGif.Dock = DockStyle.Fill;
                pb_BackgroundGif.SendToBack();
                PIC_Player.Parent = pb_BackgroundGif;

                // creating platform 1
                PictureBox pb_platform1_Left = new PictureBox();
                Controls.Add(pb_platform1_Left);
                pb_platform1_Left.Size = new Size(60, 10);
                pb_platform1_Left.Location = new Point(0, 490);
                pb_platform1_Left.BackColor = Color.Lime;
                pb_platform1_Left.BringToFront();

                // creating platform 2
                PictureBox pb_platform2_Left = new PictureBox();
                Controls.Add(pb_platform2_Left);
                pb_platform2_Left.Size = new Size(60, 10);
                pb_platform2_Left.Location = new Point(140, 430);
                pb_platform2_Left.BackColor = Color.Lime;
                pb_platform2_Left.BringToFront();

                // creating platform 3
                PictureBox pb_platform3_Left = new PictureBox();
                Controls.Add(pb_platform3_Left);
                pb_platform3_Left.Size = new Size(60, 10);
                pb_platform3_Left.Location = new Point(0, 360);
                pb_platform3_Left.BackColor = Color.Lime;
                pb_platform3_Left.BringToFront();

                // coin
                PictureBox pic_Coin = new PictureBox();
                Controls.Add(pic_Coin);
                pic_Coin.Image = Resources._2dcoin;
                pic_Coin.Location = new Point(260, 100);
                pic_Coin.BackColor = Color.Black;
                pic_Coin.Size = new Size(25, 25);
                pic_Coin.SizeMode = PictureBoxSizeMode.StretchImage;
                pic_Coin.BringToFront();
                pic_Coin.Tag = CodedObjects.Tag_Coin;

                // create a shop
                PictureBox pic_Shop = new PictureBox();
                Controls.Add(pic_Shop);
                pic_Shop.Image = Resources.shop2D;
                pic_Shop.Location = new Point(5, 320);
                pic_Shop.Size = new Size(50, 40);
                pic_Shop.SizeMode = PictureBoxSizeMode.StretchImage;
                pic_Shop.BringToFront();
                pic_Shop.Tag = CodedObjects.Tag_Shop;

                // creating platform 4
                PictureBox pb_platform4_Left = new PictureBox();
                Controls.Add(pb_platform4_Left);
                pb_platform4_Left.Size = new Size(60, 10);
                pb_platform4_Left.Location = new Point(140, 300);
                pb_platform4_Left.BackColor = Color.Lime;
                pb_platform4_Left.BringToFront();

                // creating platform 5
                PictureBox pb_platform5_Center = new PictureBox();
                Controls.Add(pb_platform5_Center);
                pb_platform5_Center.Size = new Size(160, 10);
                pb_platform5_Center.Location = new Point(280, 350);
                pb_platform5_Center.BackColor = Color.Lime;
                pb_platform5_Center.BringToFront();

                // creating platform 6
                PictureBox pb_platform6_Center = new PictureBox();
                Controls.Add(pb_platform6_Center);
                pb_platform6_Center.Size = new Size(60, 10);
                pb_platform6_Center.Location = new Point(520, 290);
                pb_platform6_Center.BackColor = Color.Lime;
                pb_platform6_Center.BringToFront();

                // creating platform 7
                PictureBox pb_platform7_Right = new PictureBox();
                Controls.Add(pb_platform7_Right);
                pb_platform7_Right.Size = new Size(80, 10);
                pb_platform7_Right.Location = new Point(610, 370);
                pb_platform7_Right.BackColor = Color.Lime;
                pb_platform7_Right.BringToFront();

                // creating platform 8
                PictureBox pb_platform8_Left = new PictureBox();
                Controls.Add(pb_platform8_Left);
                pb_platform8_Left.Size = new Size(60, 10);
                pb_platform8_Left.Location = new Point(0, 230);
                pb_platform8_Left.BackColor = Color.Lime;
                pb_platform8_Left.BringToFront();

                // creating platform 9
                PictureBox pb_platform9_Right = new PictureBox();
                Controls.Add(pb_platform9_Right);
                pb_platform9_Right.Size = new Size(60, 10);
                pb_platform9_Right.Location = new Point(750, 450);
                pb_platform9_Right.BackColor = Color.Lime;
                pb_platform9_Right.BringToFront();

                // creating platform 10 (where exit door is)
                PictureBox pb_platform10_Left = new PictureBox();
                Controls.Add(pb_platform10_Left);
                pb_platform10_Left.Size = new Size(60, 10);
                pb_platform10_Left.Location = new Point(120, 170);
                pb_platform10_Left.BackColor = Color.Lime;
                pb_platform10_Left.BringToFront();

                // create an enemy unit
                PictureBox pic_Enemy = new PictureBox();
                Controls.Add(pic_Enemy);
                pic_Enemy.Image = Resources.EnemyMONSTER_org;
                pic_Enemy.Size = new Size(40, 30);
                pic_Enemy.Location = new Point(280, 320);
                pic_Enemy.SizeMode = PictureBoxSizeMode.StretchImage;
                pic_Enemy.BringToFront();
                pic_Enemy.Tag = CodedObjects.Tag_Enemy;

                // create a second enemy unit
                PictureBox pic_Enemy2 = new PictureBox();
                Controls.Add(pic_Enemy2);
                pic_Enemy2.Image = Resources.EnemyMONSTER_org;
                pic_Enemy2.Size = new Size(40, 30);
                pic_Enemy2.Location = new Point(610, 340);
                pic_Enemy2.SizeMode = PictureBoxSizeMode.StretchImage;
                pic_Enemy2.BringToFront();
                pic_Enemy2.Tag = CodedObjects.Tag_Enemy2;

                // creating a key
                PictureBox pic_Key = new PictureBox();
                Controls.Add(pic_Key);
                pic_Key.Image = Resources.A_Key;
                pic_Key.BackColor = Color.Transparent;
                pic_Key.SizeMode = PictureBoxSizeMode.StretchImage;
                pic_Key.Size = new Size(50, 30);
                pic_Key.Location = new Point(750, 420);
                pic_Key.BringToFront();
                pic_Key.Tag = CodedObjects.Tag_Key;

                // creating an exit door
                PictureBox pic_Exit = new PictureBox();
                Controls.Add(pic_Exit);
                pic_Exit.Size = new Size(40, 50);
                pic_Exit.SizeMode = PictureBoxSizeMode.StretchImage;
                pic_Exit.Location = new Point(130, 120);
                pic_Exit.Image = Resources.Door_Closed;
                pic_Exit.BringToFront();
                pic_Exit.Tag = CodedObjects.Tag_Exit;

                // creating notification about obtaining a key
                Label lbl_KeyObtained = new Label();
                Controls.Add(lbl_KeyObtained);
                lbl_KeyObtained.Location = new Point(0, 450);
                lbl_KeyObtained.Size = new Size(120, 50);
                lbl_KeyObtained.Font = new Font("Comic Sans MS", 22, FontStyle.Bold);
                lbl_KeyObtained.ForeColor = Color.Yellow;
                lbl_KeyObtained.BackColor = Color.Black;
                lbl_KeyObtained.BringToFront();
                lbl_KeyObtained.Text = "1 Key";
                lbl_KeyObtained.Visible = false;
                lbl_KeyObtained.Tag = CodedObjects.Tag_KeyText;

                // store 10 platforms into their array
                array_pbPlatforms[0] = pb_platform1_Left;
                array_pbPlatforms[1] = pb_platform2_Left;
                array_pbPlatforms[2] = pb_platform3_Left;
                array_pbPlatforms[3] = pb_platform4_Left;
                array_pbPlatforms[4] = pb_platform5_Center;
                array_pbPlatforms[5] = pb_platform6_Center;
                array_pbPlatforms[6] = pb_platform7_Right;
                array_pbPlatforms[7] = pb_platform8_Left;
                array_pbPlatforms[8] = pb_platform9_Right;
                array_pbPlatforms[9] = pb_platform10_Left;
            }
            // ---

            // ---
            // [LEVEL TWO] if level two is chosen
            if (intLevel == 2)
            {
                // it IS a second level
                isLevel = 2;

                // set player's location
                PIC_Player.Location = new Point(22, 430);

                // create an animated background image
                PictureBox pb_BackgroundGif = new PictureBox();
                Controls.Add(pb_BackgroundGif);
                pb_BackgroundGif.Image = Resources.gifBackground;
                pb_BackgroundGif.Dock = DockStyle.Fill;
                pb_BackgroundGif.SendToBack();
                PIC_Player.Parent = pb_BackgroundGif;

                // creating platform 1
                PictureBox pb_platform1_Left = new PictureBox();
                Controls.Add(pb_platform1_Left);
                pb_platform1_Left.Size = new Size(60, 10);
                pb_platform1_Left.Location = new Point(0, 490);
                pb_platform1_Left.BackColor = Color.Lime;
                pb_platform1_Left.BringToFront();

                // creating platform 2
                PictureBox pb_platform2_Center = new PictureBox();
                Controls.Add(pb_platform2_Center);
                pb_platform2_Center.Size = new Size(110, 10);
                pb_platform2_Center.Location = new Point(160, 430);
                pb_platform2_Center.BackColor = Color.Lime;
                pb_platform2_Center.BringToFront();

                // creating platform 3
                PictureBox pb_platform3_Center = new PictureBox();
                Controls.Add(pb_platform3_Center);
                pb_platform3_Center.Size = new Size(50, 10);
                pb_platform3_Center.Location = new Point(370, 490);
                pb_platform3_Center.BackColor = Color.Lime;
                pb_platform3_Center.BringToFront();

                // creating platform 4
                PictureBox pb_platform4_Center = new PictureBox();
                Controls.Add(pb_platform4_Center);
                pb_platform4_Center.Size = new Size(60, 10);
                pb_platform4_Center.Location = new Point(340, 270);
                pb_platform4_Center.BackColor = Color.Lime;
                pb_platform4_Center.BringToFront();

                // creating platform 5
                PictureBox pb_platform5_Center = new PictureBox();
                Controls.Add(pb_platform5_Center);
                pb_platform5_Center.Size = new Size(90, 10);
                pb_platform5_Center.Location = new Point(520, 420);
                pb_platform5_Center.BackColor = Color.Lime;
                pb_platform5_Center.BringToFront();

                // creating platform 6
                PictureBox pb_platform6_Right = new PictureBox();
                Controls.Add(pb_platform6_Right);
                pb_platform6_Right.Size = new Size(170, 10);
                pb_platform6_Right.Location = new Point(640, 500);
                pb_platform6_Right.BackColor = Color.Lime;
                pb_platform6_Right.BringToFront();

                // creating platform 7
                PictureBox pb_platform7_Right = new PictureBox();
                Controls.Add(pb_platform7_Right);
                pb_platform7_Right.Size = new Size(60, 10);
                pb_platform7_Right.Location = new Point(730, 350);
                pb_platform7_Right.BackColor = Color.Lime;
                pb_platform7_Right.BringToFront();

                // creating platform 8
                PictureBox pb_platform8_Right = new PictureBox();
                Controls.Add(pb_platform8_Right);
                pb_platform8_Right.Size = new Size(60, 10);
                pb_platform8_Right.Location = new Point(600, 270);
                pb_platform8_Right.BackColor = Color.Lime;
                pb_platform8_Right.BringToFront();

                // creating platform 9 (where exit door is)
                PictureBox pb_platform9_Center = new PictureBox();
                Controls.Add(pb_platform9_Center);
                pb_platform9_Center.Size = new Size(60, 10);
                pb_platform9_Center.Location = new Point(470, 210);
                pb_platform9_Center.BackColor = Color.Lime;
                pb_platform9_Center.BringToFront();

                // creating platform 10
                PictureBox pb_platform10_Left = new PictureBox();
                Controls.Add(pb_platform10_Left);
                pb_platform10_Left.Size = new Size(70, 10);
                pb_platform10_Left.Location = new Point(140, 250);
                pb_platform10_Left.BackColor = Color.Lime;
                pb_platform10_Left.BringToFront();

                // creating platform 11
                PictureBox pb_platform11_Left = new PictureBox();
                Controls.Add(pb_platform11_Left);
                pb_platform11_Left.Size = new Size(70, 10);
                pb_platform11_Left.Location = new Point(0, 250);
                pb_platform11_Left.BackColor = Color.Lime;
                pb_platform11_Left.BringToFront();

                // creating platform 12
                PictureBox pb_platform12_Left = new PictureBox();
                Controls.Add(pb_platform12_Left);
                pb_platform12_Left.Size = new Size(60, 10);
                pb_platform12_Left.Location = new Point(50, 340);
                pb_platform12_Left.BackColor = Color.Lime;
                pb_platform12_Left.BringToFront();

                // create an enemy unit
                PictureBox pic_Enemy = new PictureBox();
                Controls.Add(pic_Enemy);
                pic_Enemy.Image = Resources.EnemyMONSTER_org;
                pic_Enemy.Size = new Size(40, 30);
                pic_Enemy.Location = new Point(140, 400);
                pic_Enemy.SizeMode = PictureBoxSizeMode.StretchImage;
                pic_Enemy.BringToFront();
                pic_Enemy.Tag = CodedObjects.Tag_Enemy;

                // create a second enemy unit
                PictureBox pic_Enemy2 = new PictureBox();
                Controls.Add(pic_Enemy2);
                pic_Enemy2.Image = Resources.EnemyMONSTER_org;
                pic_Enemy2.Size = new Size(40, 30);
                pic_Enemy2.Location = new Point(740, 470);
                pic_Enemy2.SizeMode = PictureBoxSizeMode.StretchImage;
                pic_Enemy2.BringToFront();
                pic_Enemy2.Tag = CodedObjects.Tag_Enemy2;

                // create the new enemy in achievement area
                // create an enemy unit 3
                PictureBox pic_Enemy3 = new PictureBox();
                Controls.Add(pic_Enemy3);
                pic_Enemy3.Image = Resources.EnemyMONSTER_org;
                pic_Enemy3.Size = new Size(40, 30);
                pic_Enemy3.Location = new Point(120, 220);
                pic_Enemy3.SizeMode = PictureBoxSizeMode.StretchImage;
                pic_Enemy3.BringToFront();
                pic_Enemy3.Tag = CodedObjects.Tag_Enemy3;

                // create the new enemy in achievement area
                // create an enemy unit 4
                PictureBox pic_Enemy4 = new PictureBox();
                Controls.Add(pic_Enemy4);
                pic_Enemy4.Image = Resources.EnemyMONSTER_org;
                pic_Enemy4.Size = new Size(40, 30);
                pic_Enemy4.Location = new Point(0, 220);
                pic_Enemy4.SizeMode = PictureBoxSizeMode.StretchImage;
                pic_Enemy4.BringToFront();
                pic_Enemy4.Tag = CodedObjects.Tag_Enemy4;

                // coin
                PictureBox pic_Coin = new PictureBox();
                Controls.Add(pic_Coin);
                pic_Coin.Image = Resources._2dcoin;
                pic_Coin.Location = new Point(15, 320);
                pic_Coin.BackColor = Color.Black;
                pic_Coin.Size = new Size(25, 25);
                pic_Coin.SizeMode = PictureBoxSizeMode.StretchImage;
                pic_Coin.BringToFront();
                pic_Coin.Tag = CodedObjects.Tag_Coin;

                // create a shop
                PictureBox pic_Shop = new PictureBox();
                Controls.Add(pic_Shop);
                pic_Shop.Image = Resources.shop2D;
                pic_Shop.Location = new Point(375, 450);
                pic_Shop.Size = new Size(40, 40);
                pic_Shop.SizeMode = PictureBoxSizeMode.StretchImage;
                pic_Shop.BringToFront();
                pic_Shop.Tag = CodedObjects.Tag_Shop;

                // creating a key
                PictureBox pic_Key = new PictureBox();
                Controls.Add(pic_Key);
                pic_Key.Image = Resources.A_Key;
                pic_Key.BackColor = Color.Transparent;
                pic_Key.SizeMode = PictureBoxSizeMode.StretchImage;
                pic_Key.Size = new Size(50, 30);
                pic_Key.Location = new Point(750, 440);
                pic_Key.BringToFront();
                pic_Key.Tag = CodedObjects.Tag_Key;

                // creating an exit door
                PictureBox pic_Exit = new PictureBox();
                Controls.Add(pic_Exit);
                pic_Exit.Size = new Size(40, 50);
                pic_Exit.SizeMode = PictureBoxSizeMode.StretchImage;
                pic_Exit.Location = new Point(480, 160);
                pic_Exit.Image = Resources.Door_Closed;
                pic_Exit.BringToFront();
                pic_Exit.Tag = CodedObjects.Tag_Exit;

                // creating a ladder
                PictureBox pic_Ladder = new PictureBox();
                Controls.Add(pic_Ladder);
                pic_Ladder.Image = Resources.ladder;
                pic_Ladder.SizeMode = PictureBoxSizeMode.StretchImage;
                pic_Ladder.Size = new Size(30, 60);
                pic_Ladder.BackColor = Color.Transparent;
                pic_Ladder.Location = new Point(80, 280);
                pic_Ladder.BringToFront();
                pic_Ladder.Tag = CodedObjects.Tag_Ladder;

                // creating notification about obtaining a key
                Label lbl_KeyObtained = new Label();
                Controls.Add(lbl_KeyObtained);
                lbl_KeyObtained.Location = new Point(0, 450);
                lbl_KeyObtained.Size = new Size(120, 50);
                lbl_KeyObtained.Font = new Font("Comic Sans MS", 22, FontStyle.Bold);
                lbl_KeyObtained.ForeColor = Color.Yellow;
                lbl_KeyObtained.BackColor = Color.Black;
                lbl_KeyObtained.BringToFront();
                lbl_KeyObtained.Text = "1 Key";
                lbl_KeyObtained.Visible = false;
                lbl_KeyObtained.Tag = CodedObjects.Tag_KeyText;

                // create a achievement object to be obtained
                PictureBox pbAchievement = new PictureBox();
                Controls.Add(pbAchievement);
                pbAchievement.Enabled = false;
                pbAchievement.Visible = false;
                pbAchievement.Image = Resources.Atrophy2;
                pbAchievement.Location = new Point(0, 150);
                pbAchievement.Size = new Size(40, 40);
                pbAchievement.SizeMode = PictureBoxSizeMode.StretchImage;
                pbAchievement.BringToFront();
                pbAchievement.Tag = CodedObjects.Tag_Achievement;

                // store 9 platforms into their array
                //(to make them physically interactable with a player)
                array_pbPlatforms[0] = pb_platform1_Left;
                array_pbPlatforms[1] = pb_platform2_Center;
                array_pbPlatforms[2] = pb_platform3_Center;
                array_pbPlatforms[3] = pb_platform4_Center;
                array_pbPlatforms[4] = pb_platform5_Center;
                array_pbPlatforms[5] = pb_platform6_Right;
                array_pbPlatforms[6] = pb_platform7_Right;
                array_pbPlatforms[7] = pb_platform8_Right;
                array_pbPlatforms[8] = pb_platform9_Center;
                array_pbPlatforms[9] = pb_platform10_Left;
                array_pbPlatforms[10] = pb_platform11_Left;
                array_pbPlatforms[11] = pb_platform12_Left;

            }
            // ---

            // ---
            // [LEVEL THREE] if level three is chosen
            if (intLevel == 3)
            {
                // it IS a third level
                isLevel = 3;

                // set player's location
                PIC_Player.Location = new Point(22, 420);

                // create an animated background image
                PictureBox pb_BackgroundGif = new PictureBox();
                Controls.Add(pb_BackgroundGif);
                pb_BackgroundGif.Image = Resources.gifBackground;
                pb_BackgroundGif.Dock = DockStyle.Fill;
                pb_BackgroundGif.SendToBack();
                PIC_Player.Parent = pb_BackgroundGif;

                // creating platform 1
                PictureBox pb_platform1_Left = new PictureBox();
                Controls.Add(pb_platform1_Left);
                pb_platform1_Left.Size = new Size(60, 10);
                pb_platform1_Left.Location = new Point(22, 450);
                pb_platform1_Left.BackColor = Color.Lime;
                pb_platform1_Left.BringToFront();

                // creating platform 2
                PictureBox pb_platform2_Left = new PictureBox();
                Controls.Add(pb_platform2_Left);
                pb_platform2_Left.Size = new Size(60, 10);
                pb_platform2_Left.Location = new Point(110, 370);
                pb_platform2_Left.BackColor = Color.Lime;
                pb_platform2_Left.BringToFront();

                // creating platform 3
                PictureBox pb_platform3_Left = new PictureBox();
                Controls.Add(pb_platform3_Left);
                pb_platform3_Left.Size = new Size(30, 10);
                pb_platform3_Left.Location = new Point(270, 450);
                pb_platform3_Left.BackColor = Color.Lime;
                pb_platform3_Left.BringToFront();

                // creating platform 4
                PictureBox pb_platform4_Middle = new PictureBox();
                Controls.Add(pb_platform4_Middle);
                pb_platform4_Middle.Size = new Size(100, 10);
                pb_platform4_Middle.Location = new Point(370, 370);
                pb_platform4_Middle.BackColor = Color.Lime;
                pb_platform4_Middle.BringToFront();

                // creating platform 5
                PictureBox pb_platform5_Middle = new PictureBox();
                Controls.Add(pb_platform5_Middle);
                pb_platform5_Middle.Size = new Size(30, 10);
                pb_platform5_Middle.Location = new Point(580, 450);
                pb_platform5_Middle.BackColor = Color.Lime;
                pb_platform5_Middle.BringToFront();

                // creating platform 6
                PictureBox pb_platform6_Middle = new PictureBox();
                Controls.Add(pb_platform6_Middle);
                pb_platform6_Middle.Size = new Size(30, 10);
                pb_platform6_Middle.Location = new Point(690, 450);
                pb_platform6_Middle.BackColor = Color.Lime;
                pb_platform6_Middle.BringToFront();

                // creating platform 7
                PictureBox pb_platform7_Middle = new PictureBox();
                Controls.Add(pb_platform7_Middle);
                pb_platform7_Middle.Size = new Size(150, 10);
                pb_platform7_Middle.Location = new Point(360, 220);
                pb_platform7_Middle.BackColor = Color.Lime;
                pb_platform7_Middle.BringToFront();

                // creating platform 8
                PictureBox pb_platform8_Middle = new PictureBox();
                Controls.Add(pb_platform8_Middle);
                pb_platform8_Middle.Size = new Size(30, 10);
                pb_platform8_Middle.Location = new Point(280, 290);
                pb_platform8_Middle.BackColor = Color.Lime;
                pb_platform8_Middle.BringToFront();

                // create an enemy unit
                PictureBox pic_Enemy = new PictureBox();
                Controls.Add(pic_Enemy);
                pic_Enemy.Image = Resources.EnemyMONSTER_org;
                pic_Enemy.Size = new Size(40, 30);
                pic_Enemy.Location = new Point(370, 340);
                pic_Enemy.SizeMode = PictureBoxSizeMode.StretchImage;
                pic_Enemy.BringToFront();
                pic_Enemy.Tag = CodedObjects.Tag_Enemy;

                // create a second enemy unit
                PictureBox pic_Enemy2 = new PictureBox();
                Controls.Add(pic_Enemy2);
                pic_Enemy2.Image = Resources.EnemyMONSTER_org;
                pic_Enemy2.Size = new Size(40, 30);
                pic_Enemy2.Location = new Point(360, 190);
                pic_Enemy2.SizeMode = PictureBoxSizeMode.StretchImage;
                pic_Enemy2.BringToFront();
                pic_Enemy2.Tag = CodedObjects.Tag_Enemy2;

                // coin
                PictureBox pic_Coin = new PictureBox();
                Controls.Add(pic_Coin);
                pic_Coin.Image = Resources._2dcoin;
                pic_Coin.Location = new Point(180, 180);
                pic_Coin.BackColor = Color.Black;
                pic_Coin.Size = new Size(25, 25);
                pic_Coin.SizeMode = PictureBoxSizeMode.StretchImage;
                pic_Coin.BringToFront();
                pic_Coin.Tag = CodedObjects.Tag_Coin;

                // create a shop
                PictureBox pic_Shop = new PictureBox();
                Controls.Add(pic_Shop);
                pic_Shop.Image = Resources.shop2D;
                pic_Shop.Location = new Point(115, 330);
                pic_Shop.Size = new Size(50, 40);
                pic_Shop.SizeMode = PictureBoxSizeMode.StretchImage;
                pic_Shop.BringToFront();
                pic_Shop.Tag = CodedObjects.Tag_Shop;

                // creating a key
                PictureBox pic_Key = new PictureBox();
                Controls.Add(pic_Key);
                pic_Key.Image = Resources.A_Key;
                pic_Key.BackColor = Color.Transparent;
                pic_Key.SizeMode = PictureBoxSizeMode.StretchImage;
                pic_Key.Size = new Size(50, 30);
                pic_Key.Location = new Point(730, 350);
                pic_Key.BringToFront();
                pic_Key.Tag = CodedObjects.Tag_Key;

                // creating notification about obtaining a key
                Label lbl_KeyObtained = new Label();
                Controls.Add(lbl_KeyObtained);
                lbl_KeyObtained.Location = new Point(0, 450);
                lbl_KeyObtained.Size = new Size(120, 50);
                lbl_KeyObtained.Font = new Font("Comic Sans MS", 22, FontStyle.Bold);
                lbl_KeyObtained.ForeColor = Color.Yellow;
                lbl_KeyObtained.BackColor = Color.Black;
                lbl_KeyObtained.BringToFront();
                lbl_KeyObtained.Text = "1 Key";
                lbl_KeyObtained.Visible = false;
                lbl_KeyObtained.Tag = CodedObjects.Tag_KeyText;

                // creating an exit door
                PictureBox pic_Exit = new PictureBox();
                Controls.Add(pic_Exit);
                pic_Exit.Size = new Size(40, 50);
                pic_Exit.SizeMode = PictureBoxSizeMode.StretchImage;
                pic_Exit.Location = new Point(470, 170);
                pic_Exit.Image = Resources.Door_Closed;
                pic_Exit.BringToFront();
                pic_Exit.Tag = CodedObjects.Tag_Exit;

                array_pbPlatforms[0] = pb_platform1_Left;
                array_pbPlatforms[1] = pb_platform2_Left;
                array_pbPlatforms[2] = pb_platform3_Left;
                array_pbPlatforms[3] = pb_platform4_Middle;
                array_pbPlatforms[4] = pb_platform5_Middle;
                array_pbPlatforms[5] = pb_platform6_Middle;
                array_pbPlatforms[6] = pb_platform7_Middle;
                array_pbPlatforms[7] = pb_platform8_Middle;
            }
            // ---

            // ---
            // [LEVEL FOUR] if level four is chosen
            if (intLevel == 4)
            {
                // it IS a fourth level
                isLevel = 4;

                // set player's location
                PIC_Player.Location = new Point(22, 420);

                // create an animated background image
                PictureBox pb_BackgroundGif = new PictureBox();
                Controls.Add(pb_BackgroundGif);
                pb_BackgroundGif.Image = Resources.gifBackground;
                pb_BackgroundGif.Dock = DockStyle.Fill;
                pb_BackgroundGif.SendToBack();
                PIC_Player.Parent = pb_BackgroundGif;

                // creating platform 1
                PictureBox pb_platform1_Left = new PictureBox();
                Controls.Add(pb_platform1_Left);
                pb_platform1_Left.Size = new Size(60, 10);
                pb_platform1_Left.Location = new Point(0, 490);
                pb_platform1_Left.BackColor = Color.Lime;
                pb_platform1_Left.BringToFront();

                // creating platform 2
                PictureBox pb_platform2_Left = new PictureBox();
                Controls.Add(pb_platform2_Left);
                pb_platform2_Left.Size = new Size(60, 10);
                pb_platform2_Left.Location = new Point(120, 410);
                pb_platform2_Left.BackColor = Color.Lime;
                pb_platform2_Left.BringToFront();

                // creating platform 3
                PictureBox pb_platform3_Middle = new PictureBox();
                Controls.Add(pb_platform3_Middle);
                pb_platform3_Middle.Size = new Size(60, 10);
                pb_platform3_Middle.Location = new Point(270, 460);
                pb_platform3_Middle.BackColor = Color.Lime;
                pb_platform3_Middle.BringToFront();

                // creating platform 4 (moving X)
                PictureBox pb_platform4_Middle = new PictureBox();
                Controls.Add(pb_platform4_Middle);
                pb_platform4_Middle.Size = new Size(60, 10);
                pb_platform4_Middle.Location = new Point(400, 400);
                pb_platform4_Middle.BackColor = Color.Lime;
                pb_platform4_Middle.BringToFront();
                pb_platform4_Middle.Tag = CodedObjects.Tag_MovePlat;

                // creating platform 5 (moving X)
                PictureBox pb_platform5_Middle = new PictureBox();
                Controls.Add(pb_platform5_Middle);
                pb_platform5_Middle.Size = new Size(60, 10);
                pb_platform5_Middle.Location = new Point(580, 300);
                pb_platform5_Middle.BackColor = Color.Lime;
                pb_platform5_Middle.BringToFront();
                pb_platform5_Middle.Tag = CodedObjects.Tag_MovePlat2;

                // creating platform 6
                PictureBox pb_platform6_Middle = new PictureBox();
                Controls.Add(pb_platform6_Middle);
                pb_platform6_Middle.Size = new Size(60, 10);
                pb_platform6_Middle.Location = new Point(200, 220);
                pb_platform6_Middle.BackColor = Color.Lime;
                pb_platform6_Middle.BringToFront();

                // create an enemy unit
                PictureBox pic_Enemy = new PictureBox();
                Controls.Add(pic_Enemy);
                pic_Enemy.Image = Resources.EnemyMONSTER_org;
                pic_Enemy.Size = new Size(40, 30);
                pic_Enemy.Location = new Point(100, 380);
                pic_Enemy.SizeMode = PictureBoxSizeMode.StretchImage;
                pic_Enemy.BringToFront();
                pic_Enemy.Tag = CodedObjects.Tag_Enemy;

                // creating notification about obtaining a key
                Label lbl_KeyObtained = new Label();
                Controls.Add(lbl_KeyObtained);
                lbl_KeyObtained.Location = new Point(0, 450);
                lbl_KeyObtained.Size = new Size(120, 50);
                lbl_KeyObtained.Font = new Font("Comic Sans MS", 22, FontStyle.Bold);
                lbl_KeyObtained.ForeColor = Color.Yellow;
                lbl_KeyObtained.BackColor = Color.Black;
                lbl_KeyObtained.BringToFront();
                lbl_KeyObtained.Text = "1 Key";
                lbl_KeyObtained.Visible = false;
                lbl_KeyObtained.Tag = CodedObjects.Tag_KeyText;

                // create a shop
                PictureBox pic_Shop = new PictureBox();
                Controls.Add(pic_Shop);
                pic_Shop.Image = Resources.shop2D;
                pic_Shop.Location = new Point(280, 420);
                pic_Shop.Size = new Size(40, 40);
                pic_Shop.SizeMode = PictureBoxSizeMode.StretchImage;
                pic_Shop.BringToFront();
                pic_Shop.Tag = CodedObjects.Tag_Shop;

                // coin
                PictureBox pic_Coin = new PictureBox();
                Controls.Add(pic_Coin);
                pic_Coin.Image = Resources._2dcoin;
                pic_Coin.Location = new Point(570, 360);
                pic_Coin.BackColor = Color.Black;
                pic_Coin.Size = new Size(25, 25);
                pic_Coin.SizeMode = PictureBoxSizeMode.StretchImage;
                pic_Coin.BringToFront();
                pic_Coin.Tag = CodedObjects.Tag_Coin;

                // creating a key
                PictureBox pic_Key = new PictureBox();
                Controls.Add(pic_Key);
                pic_Key.Image = Resources.A_Key;
                pic_Key.BackColor = Color.Transparent;
                pic_Key.SizeMode = PictureBoxSizeMode.StretchImage;
                pic_Key.Size = new Size(50, 30);
                pic_Key.Location = new Point(730, 150);
                pic_Key.BringToFront();
                pic_Key.Tag = CodedObjects.Tag_Key;

                // creating an exit door
                PictureBox pic_Exit = new PictureBox();
                Controls.Add(pic_Exit);
                pic_Exit.Size = new Size(40, 50);
                pic_Exit.SizeMode = PictureBoxSizeMode.StretchImage;
                pic_Exit.Location = new Point(210, 170);
                pic_Exit.Image = Resources.Door_Closed;
                pic_Exit.BringToFront();
                pic_Exit.Tag = CodedObjects.Tag_Exit;

                // store 6 platforms into their array
                array_pbPlatforms[0] = pb_platform1_Left;
                array_pbPlatforms[1] = pb_platform2_Left;
                array_pbPlatforms[2] = pb_platform3_Middle;
                array_pbPlatforms[3] = pb_platform4_Middle;
                array_pbPlatforms[4] = pb_platform5_Middle;
                array_pbPlatforms[5] = pb_platform6_Middle;
            }
            // ---

            // ---
            // [LEVEL FIVE] if level five is chosen
            if (intLevel == 5)
            {
                // it IS a fifth level
                isLevel = 5;

                Xvel_enemy = -1;

                // set player's location
                PIC_Player.Location = new Point(22, 420);

                // create an animated background image
                PictureBox pb_BackgroundGif = new PictureBox();
                Controls.Add(pb_BackgroundGif);
                pb_BackgroundGif.Image = Resources.gifBackground;
                pb_BackgroundGif.Dock = DockStyle.Fill;
                pb_BackgroundGif.SendToBack();
                PIC_Player.Parent = pb_BackgroundGif;

                // creating platform 1
                PictureBox pb_platform1_Left = new PictureBox();
                Controls.Add(pb_platform1_Left);
                pb_platform1_Left.Size = new Size(150, 10);
                pb_platform1_Left.Location = new Point(0, 490);
                pb_platform1_Left.BackColor = Color.Lime;
                pb_platform1_Left.BringToFront();

                // creating platform 2
                PictureBox pb_platform2_Left = new PictureBox();
                Controls.Add(pb_platform2_Left);
                pb_platform2_Left.Size = new Size(120, 10);
                pb_platform2_Left.Location = new Point(180, 200);
                pb_platform2_Left.BackColor = Color.Lime;
                pb_platform2_Left.BringToFront();

                // creating platform 3
                PictureBox pb_platform3_Left = new PictureBox();
                Controls.Add(pb_platform3_Left);
                pb_platform3_Left.Size = new Size(70, 10);
                pb_platform3_Left.Location = new Point(200, 420);
                pb_platform3_Left.BackColor = Color.Lime;
                pb_platform3_Left.BringToFront();

                // creating platform 4
                PictureBox pb_platform4_Left = new PictureBox();
                Controls.Add(pb_platform4_Left);
                pb_platform4_Left.Size = new Size(70, 10);
                pb_platform4_Left.Location = new Point(90, 100);
                pb_platform4_Left.BackColor = Color.Lime;
                pb_platform4_Left.BringToFront();

                // creating platform 5 (moving Y)
                PictureBox pb_platform5_Middle = new PictureBox();
                Controls.Add(pb_platform5_Middle);
                pb_platform5_Middle.Size = new Size(70, 10);
                pb_platform5_Middle.Location = new Point(380, 400);
                pb_platform5_Middle.BackColor = Color.Lime;
                pb_platform5_Middle.BringToFront();
                pb_platform5_Middle.Tag = CodedObjects.Tag_MovePlat3;

                // creating platform 6
                PictureBox pb_platform6_Right = new PictureBox();
                Controls.Add(pb_platform6_Right);
                pb_platform6_Right.Size = new Size(40, 10);
                pb_platform6_Right.Location = new Point(580, 250);
                pb_platform6_Right.BackColor = Color.Lime;
                pb_platform6_Right.BringToFront();

                // creating platform 7
                PictureBox pb_platform7_Right = new PictureBox();
                Controls.Add(pb_platform7_Right);
                pb_platform7_Right.Size = new Size(40, 10);
                pb_platform7_Right.Location = new Point(700, 250);
                pb_platform7_Right.BackColor = Color.Lime;
                pb_platform7_Right.BringToFront();

                // creating a key
                PictureBox pic_Key = new PictureBox();
                Controls.Add(pic_Key);
                pic_Key.Image = Resources.A_Key;
                pic_Key.BackColor = Color.Transparent;
                pic_Key.SizeMode = PictureBoxSizeMode.StretchImage;
                pic_Key.Size = new Size(50, 30);
                pic_Key.Location = new Point(100, 60);
                pic_Key.BringToFront();
                pic_Key.Tag = CodedObjects.Tag_Key;

                // create an enemy unit
                PictureBox pic_Enemy = new PictureBox();
                Controls.Add(pic_Enemy);
                pic_Enemy.Image = Resources.EnemyMONSTER2_reverse;
                pic_Enemy.Size = new Size(40, 30);
                pic_Enemy.Location = new Point(140, 460);
                pic_Enemy.SizeMode = PictureBoxSizeMode.StretchImage;
                pic_Enemy.BringToFront();
                pic_Enemy.Tag = CodedObjects.Tag_Enemy;

                // create an enemy unit 2
                PictureBox pic_Enemy2 = new PictureBox();
                Controls.Add(pic_Enemy2);
                pic_Enemy2.Image = Resources.EnemyMONSTER2_reverse;
                pic_Enemy2.Size = new Size(40, 30);
                pic_Enemy2.Location = new Point(200, 180);
                pic_Enemy2.SizeMode = PictureBoxSizeMode.StretchImage;
                pic_Enemy2.BringToFront();
                pic_Enemy2.Tag = CodedObjects.Tag_Enemy2;

                // creating a ladder   
                PictureBox pic_Ladder = new PictureBox();
                Controls.Add(pic_Ladder);
                pic_Ladder.Image = Resources.ladder;
                pic_Ladder.SizeMode = PictureBoxSizeMode.StretchImage;
                pic_Ladder.Size = new Size(15, 300);
                pic_Ladder.BackColor = Color.Transparent;
                pic_Ladder.Location = new Point(140, 200);
                pic_Ladder.BringToFront();
                pic_Ladder.Tag = CodedObjects.Tag_Ladder;

                // creating a second ladder
                PictureBox pic_Ladder2 = new PictureBox();
                Controls.Add(pic_Ladder2);
                pic_Ladder2.Image = Resources.ladder;
                pic_Ladder2.SizeMode = PictureBoxSizeMode.StretchImage;
                pic_Ladder2.Size = new Size(15, 100);
                pic_Ladder2.BackColor = Color.Transparent;
                pic_Ladder2.Location = new Point(650, 200);
                pic_Ladder2.BringToFront();
                pic_Ladder2.Tag = CodedObjects.Tag_Ladder;

                // create a shop
                PictureBox pic_Shop = new PictureBox();
                Controls.Add(pic_Shop);
                pic_Shop.Image = Resources.shop2D;
                pic_Shop.Location = new Point(210, 380);
                pic_Shop.Size = new Size(50, 40);
                pic_Shop.SizeMode = PictureBoxSizeMode.StretchImage;
                pic_Shop.BringToFront();
                pic_Shop.Tag = CodedObjects.Tag_Shop;

                // coin
                PictureBox pic_Coin = new PictureBox();
                Controls.Add(pic_Coin);
                pic_Coin.Image = Resources._2dcoin;
                pic_Coin.Location = new Point(310, 140);
                pic_Coin.BackColor = Color.Black;
                pic_Coin.Size = new Size(25, 25);
                pic_Coin.SizeMode = PictureBoxSizeMode.StretchImage;
                pic_Coin.BringToFront();
                pic_Coin.Tag = CodedObjects.Tag_Coin;

                // creating an exit door
                PictureBox pic_Exit = new PictureBox();
                Controls.Add(pic_Exit);
                pic_Exit.Size = new Size(40, 50);
                pic_Exit.SizeMode = PictureBoxSizeMode.StretchImage;
                pic_Exit.Location = new Point(700, 200);
                pic_Exit.Image = Resources.Door_Closed;
                pic_Exit.BringToFront();
                pic_Exit.Tag = CodedObjects.Tag_Exit;

                // creating notification about obtaining a key
                Label lbl_KeyObtained = new Label();
                Controls.Add(lbl_KeyObtained);
                lbl_KeyObtained.Location = new Point(700, 25);
                lbl_KeyObtained.Size = new Size(120, 50);
                lbl_KeyObtained.Font = new Font("Comic Sans MS", 22, FontStyle.Bold);
                lbl_KeyObtained.ForeColor = Color.Yellow;
                lbl_KeyObtained.BackColor = Color.Black;
                lbl_KeyObtained.BringToFront();
                lbl_KeyObtained.Text = "1 Key";
                lbl_KeyObtained.Visible = false;
                lbl_KeyObtained.Tag = CodedObjects.Tag_KeyText;

                array_pbPlatforms[0] = pb_platform1_Left;
                array_pbPlatforms[1] = pb_platform2_Left;
                array_pbPlatforms[2] = pb_platform3_Left;
                array_pbPlatforms[3] = pb_platform4_Left;
                array_pbPlatforms[4] = pb_platform5_Middle;
                array_pbPlatforms[5] = pb_platform6_Right;
                array_pbPlatforms[6] = pb_platform7_Right;
            }
            // ---

            // ---
            // [LEVEL SIX] if level six is chosen
            if (intLevel == 6)
            {
                // it IS a sixth level
                isLevel = 6;

                Xvel_enemy = -1;

                // set player's location
                PIC_Player.Location = new Point(22, 420);

                // create an animated background image
                PictureBox pb_BackgroundGif = new PictureBox();
                Controls.Add(pb_BackgroundGif);
                pb_BackgroundGif.Image = Resources.gifBackground;
                pb_BackgroundGif.Dock = DockStyle.Fill;
                pb_BackgroundGif.SendToBack();
                PIC_Player.Parent = pb_BackgroundGif;

                // creating platform 1
                PictureBox pb_platform1_Left = new PictureBox();
                Controls.Add(pb_platform1_Left);
                pb_platform1_Left.Size = new Size(150, 10);
                pb_platform1_Left.Location = new Point(0, 490);
                pb_platform1_Left.BackColor = Color.Lime;
                pb_platform1_Left.BringToFront();

                // creating platform 2 (moving X)
                PictureBox pb_platform2_Middle = new PictureBox();
                Controls.Add(pb_platform2_Middle);
                pb_platform2_Middle.Size = new Size(60, 10);
                pb_platform2_Middle.Location = new Point(230, 490);
                pb_platform2_Middle.BackColor = Color.Lime;
                pb_platform2_Middle.BringToFront();
                pb_platform2_Middle.Tag = CodedObjects.Tag_MovePlat;

                // creating platform 3
                PictureBox pb_platform3_Middle = new PictureBox();
                Controls.Add(pb_platform3_Middle);
                pb_platform3_Middle.Size = new Size(60, 10);
                pb_platform3_Middle.Location = new Point(350, 400);
                pb_platform3_Middle.BackColor = Color.Lime;
                pb_platform3_Middle.BringToFront();

                // creating platform 4
                PictureBox pb_platform4_Left = new PictureBox();
                Controls.Add(pb_platform4_Left);
                pb_platform4_Left.Size = new Size(150, 10);
                pb_platform4_Left.Location = new Point(0, 290);
                pb_platform4_Left.BackColor = Color.Lime;
                pb_platform4_Left.BringToFront();

                // creating platform 5 (Moving X)
                PictureBox pb_platform5_Left = new PictureBox();
                Controls.Add(pb_platform5_Left);
                pb_platform5_Left.Size = new Size(60, 10);
                pb_platform5_Left.Location = new Point(230, 330);
                pb_platform5_Left.BackColor = Color.Lime;
                pb_platform5_Left.BringToFront();
                pb_platform5_Left.Tag = CodedObjects.Tag_MovePlat;

                // create an enemy unit
                PictureBox pic_Enemy = new PictureBox();
                Controls.Add(pic_Enemy);
                pic_Enemy.Image = Resources.EnemyMonster2;
                pic_Enemy.Size = new Size(40, 30);
                pic_Enemy.Location = new Point(1, 260);
                pic_Enemy.SizeMode = PictureBoxSizeMode.StretchImage;
                pic_Enemy.BringToFront();
                pic_Enemy.Tag = CodedObjects.Tag_Enemy;

                // create a shop
                PictureBox pic_Shop = new PictureBox();
                Controls.Add(pic_Shop);
                pic_Shop.Image = Resources.shop2D;
                pic_Shop.Location = new Point(80, 450);
                pic_Shop.Size = new Size(50, 40);
                pic_Shop.SizeMode = PictureBoxSizeMode.StretchImage;
                pic_Shop.BringToFront();
                pic_Shop.Tag = CodedObjects.Tag_Shop;

                // coin
                PictureBox pic_Coin = new PictureBox();
                Controls.Add(pic_Coin);
                pic_Coin.Image = Resources._2dcoin;
                pic_Coin.Location = new Point(560, 420);
                pic_Coin.BackColor = Color.Black;
                pic_Coin.Size = new Size(25, 25);
                pic_Coin.SizeMode = PictureBoxSizeMode.StretchImage;
                pic_Coin.BringToFront();
                pic_Coin.Tag = CodedObjects.Tag_Coin;

                // creating a key
                PictureBox pic_Key = new PictureBox();
                Controls.Add(pic_Key);
                pic_Key.Image = Resources.A_Key;
                pic_Key.BackColor = Color.Transparent;
                pic_Key.SizeMode = PictureBoxSizeMode.StretchImage;
                pic_Key.Size = new Size(50, 30);
                pic_Key.Location = new Point(550, 200);
                pic_Key.BringToFront();
                pic_Key.Tag = CodedObjects.Tag_Key;

                // creating an exit door
                PictureBox pic_Exit = new PictureBox();
                Controls.Add(pic_Exit);
                pic_Exit.Size = new Size(40, 50);
                pic_Exit.SizeMode = PictureBoxSizeMode.StretchImage;
                pic_Exit.Location = new Point(10, 240);
                pic_Exit.Image = Resources.Door_Closed;
                pic_Exit.BringToFront();
                pic_Exit.Tag = CodedObjects.Tag_Exit;

                // creating notification about obtaining a key
                Label lbl_KeyObtained = new Label();
                Controls.Add(lbl_KeyObtained);
                lbl_KeyObtained.Location = new Point(700, 25);
                lbl_KeyObtained.Size = new Size(120, 50);
                lbl_KeyObtained.Font = new Font("Comic Sans MS", 22, FontStyle.Bold);
                lbl_KeyObtained.ForeColor = Color.Yellow;
                lbl_KeyObtained.BackColor = Color.Black;
                lbl_KeyObtained.BringToFront();
                lbl_KeyObtained.Text = "1 Key";
                lbl_KeyObtained.Visible = false;
                lbl_KeyObtained.Tag = CodedObjects.Tag_KeyText;

                array_pbPlatforms[0] = pb_platform1_Left;
                array_pbPlatforms[1] = pb_platform2_Middle;
                array_pbPlatforms[2] = pb_platform3_Middle;
                array_pbPlatforms[3] = pb_platform4_Left;
                array_pbPlatforms[4] = pb_platform5_Left;

            }
            // ---

            // ---
            // [LEVEL SEVEN] if level 7 is chosen
            if (intLevel == 7)
            {
                // it IS a seventh level
                isLevel = 7;

                Xvel_enemy = -1;

                // set player's location
                PIC_Player.Location = new Point(22, 420);

                // create an animated background image
                PictureBox pb_BackgroundGif = new PictureBox();
                Controls.Add(pb_BackgroundGif);
                pb_BackgroundGif.Image = Resources.gifBackground;
                pb_BackgroundGif.Dock = DockStyle.Fill;
                pb_BackgroundGif.SendToBack();
                PIC_Player.Parent = pb_BackgroundGif;

                // creating platform 1
                PictureBox pb_platform1_Left = new PictureBox();
                Controls.Add(pb_platform1_Left);
                pb_platform1_Left.Size = new Size(150, 10);
                pb_platform1_Left.Location = new Point(0, 490);
                pb_platform1_Left.BackColor = Color.Lime;
                pb_platform1_Left.BringToFront();

                // creating platform 2
                PictureBox pb_platform2_Left = new PictureBox();
                Controls.Add(pb_platform2_Left);
                pb_platform2_Left.Size = new Size(100, 10);
                pb_platform2_Left.Location = new Point(200, 400);
                pb_platform2_Left.BackColor = Color.Lime;
                pb_platform2_Left.BringToFront();

                // creating platform 3 (moving Y)
                PictureBox pb_platform3_Middle = new PictureBox();
                Controls.Add(pb_platform3_Middle);
                pb_platform3_Middle.Size = new Size(70, 10);
                pb_platform3_Middle.Location = new Point(360, 400);
                pb_platform3_Middle.BackColor = Color.Lime;
                pb_platform3_Middle.BringToFront();
                pb_platform3_Middle.Tag = CodedObjects.Tag_MovePlat3;

                // creating platform 4 (moving X)
                PictureBox pb_platform4_Middle = new PictureBox();
                Controls.Add(pb_platform4_Middle);
                pb_platform4_Middle.Size = new Size(60, 10);
                pb_platform4_Middle.Location = new Point(450, 400);
                pb_platform4_Middle.BackColor = Color.Lime;
                pb_platform4_Middle.BringToFront();
                pb_platform4_Middle.Tag = CodedObjects.Tag_MovePlat;

                // creating platform 5 (moving Y)
                PictureBox pb_platform5_Right = new PictureBox();
                Controls.Add(pb_platform5_Right);
                pb_platform5_Right.Size = new Size(70, 10);
                pb_platform5_Right.Location = new Point(620, 400);
                pb_platform5_Right.BackColor = Color.Lime;
                pb_platform5_Right.BringToFront();
                pb_platform5_Right.Tag = CodedObjects.Tag_MovePlat3;

                // creating platform 6
                PictureBox pb_platform6_Left = new PictureBox();
                Controls.Add(pb_platform6_Left);
                pb_platform6_Left.Size = new Size(150, 10);
                pb_platform6_Left.Location = new Point(0, 300);
                pb_platform6_Left.BackColor = Color.Lime;
                pb_platform6_Left.BringToFront();

                // create an enemy unit
                PictureBox pic_Enemy = new PictureBox();
                Controls.Add(pic_Enemy);
                pic_Enemy.Image = Resources.EnemyMonster2;
                pic_Enemy.Size = new Size(40, 30);
                pic_Enemy.Location = new Point(200, 370);
                pic_Enemy.SizeMode = PictureBoxSizeMode.StretchImage;
                pic_Enemy.BringToFront();
                pic_Enemy.Tag = CodedObjects.Tag_Enemy;

                // create a shop
                PictureBox pic_Shop = new PictureBox();
                Controls.Add(pic_Shop);
                pic_Shop.Image = Resources.shop2D;
                pic_Shop.Location = new Point(70, 450);
                pic_Shop.Size = new Size(50, 40);
                pic_Shop.SizeMode = PictureBoxSizeMode.StretchImage;
                pic_Shop.BringToFront();
                pic_Shop.Tag = CodedObjects.Tag_Shop;

                // creating a key
                PictureBox pic_Key = new PictureBox();
                Controls.Add(pic_Key);
                pic_Key.Image = Resources.A_Key;
                pic_Key.BackColor = Color.Transparent;
                pic_Key.SizeMode = PictureBoxSizeMode.StretchImage;
                pic_Key.Size = new Size(50, 30);
                pic_Key.Location = new Point(700, 150);
                pic_Key.BringToFront();
                pic_Key.Tag = CodedObjects.Tag_Key;

                // creating notification about obtaining a key
                Label lbl_KeyObtained = new Label();
                Controls.Add(lbl_KeyObtained);
                lbl_KeyObtained.Location = new Point(700, 25);
                lbl_KeyObtained.Size = new Size(120, 50);
                lbl_KeyObtained.Font = new Font("Comic Sans MS", 22, FontStyle.Bold);
                lbl_KeyObtained.ForeColor = Color.Yellow;
                lbl_KeyObtained.BackColor = Color.Black;
                lbl_KeyObtained.BringToFront();
                lbl_KeyObtained.Text = "1 Key";
                lbl_KeyObtained.Visible = false;
                lbl_KeyObtained.Tag = CodedObjects.Tag_KeyText;

                // creating an exit door
                PictureBox pic_Exit = new PictureBox();
                Controls.Add(pic_Exit);
                pic_Exit.Size = new Size(40, 50);
                pic_Exit.SizeMode = PictureBoxSizeMode.StretchImage;
                pic_Exit.Location = new Point(10, 250);
                pic_Exit.Image = Resources.Door_Closed;
                pic_Exit.BringToFront();
                pic_Exit.Tag = CodedObjects.Tag_Exit;

                array_pbPlatforms[0] = pb_platform1_Left;
                array_pbPlatforms[1] = pb_platform2_Left;
                array_pbPlatforms[2] = pb_platform3_Middle;
                array_pbPlatforms[3] = pb_platform4_Middle;
                array_pbPlatforms[4] = pb_platform5_Right;
                array_pbPlatforms[5] = pb_platform6_Left;
            }
            // ---

            // ---
            // [LEVEL EIGHT] if level 8 is chosen
            if (intLevel == 8)
            {
                // it IS an eighth level
                isLevel = 8;

                Xvel_enemy = -2;
                Xvel_enemy2 = -1;
                Xvel_platform = -3;
                Yvel_platform = -2;

                // set player's location
                PIC_Player.Location = new Point(22, 420);

                // create an animated background image
                PictureBox pb_BackgroundGif = new PictureBox();
                Controls.Add(pb_BackgroundGif);
                pb_BackgroundGif.Image = Resources.gifBackground;
                pb_BackgroundGif.Dock = DockStyle.Fill;
                pb_BackgroundGif.SendToBack();
                PIC_Player.Parent = pb_BackgroundGif;

                // creating platform 1
                PictureBox pb_platform1_Left = new PictureBox();
                Controls.Add(pb_platform1_Left);
                pb_platform1_Left.Size = new Size(100, 10);
                pb_platform1_Left.Location = new Point(0, 490);
                pb_platform1_Left.BackColor = Color.Lime;
                pb_platform1_Left.BringToFront();

                // creating platform 2 (moving Y)
                PictureBox pb_platform2_Left = new PictureBox();
                Controls.Add(pb_platform2_Left);
                pb_platform2_Left.Size = new Size(70, 10);
                pb_platform2_Left.Location = new Point(150, 400);
                pb_platform2_Left.BackColor = Color.Lime;
                pb_platform2_Left.BringToFront();
                pb_platform2_Left.Tag = CodedObjects.Tag_MovePlat3;

                // creating platform 3
                PictureBox pb_platform3_Middle = new PictureBox();
                Controls.Add(pb_platform3_Middle);
                pb_platform3_Middle.Size = new Size(200, 10);
                pb_platform3_Middle.Location = new Point(280, 150);
                pb_platform3_Middle.BackColor = Color.Lime;
                pb_platform3_Middle.BringToFront();

                // creating platform 4 (moving X)
                PictureBox pb_platform4_Middle = new PictureBox();
                Controls.Add(pb_platform4_Middle);
                pb_platform4_Middle.Size = new Size(60, 10);
                pb_platform4_Middle.Location = new Point(330, 440);
                pb_platform4_Middle.BackColor = Color.Lime;
                pb_platform4_Middle.BringToFront();
                pb_platform4_Middle.Tag = CodedObjects.Tag_MovePlat;

                // creating platform 5
                PictureBox pb_platform5_Right = new PictureBox();
                Controls.Add(pb_platform5_Right);
                pb_platform5_Right.Size = new Size(140, 10);
                pb_platform5_Right.Location = new Point(650, 250);
                pb_platform5_Right.BackColor = Color.Lime;
                pb_platform5_Right.BringToFront();

                // creating platform 6
                PictureBox pb_platform6_Left = new PictureBox();
                Controls.Add(pb_platform6_Left);
                pb_platform6_Left.Size = new Size(70, 10);
                pb_platform6_Left.Location = new Point(0, 130);
                pb_platform6_Left.BackColor = Color.Lime;
                pb_platform6_Left.BringToFront();

                // create an enemy unit
                PictureBox pic_Enemy = new PictureBox();
                Controls.Add(pic_Enemy);
                pic_Enemy.Image = Resources.EnemyMONSTER_reverse;
                pic_Enemy.Size = new Size(40, 30);
                pic_Enemy.Location = new Point(430, 120);
                pic_Enemy.SizeMode = PictureBoxSizeMode.StretchImage;
                pic_Enemy.BringToFront();
                pic_Enemy.Tag = CodedObjects.Tag_Enemy;

                // create an enemy unit 2 (smarter enemy)
                PictureBox pic_Enemy2 = new PictureBox();
                Controls.Add(pic_Enemy2);
                pic_Enemy2.Image = Resources.EnemyMonster2;
                pic_Enemy2.Size = new Size(40, 30);
                pic_Enemy2.Location = new Point(270, 120);
                pic_Enemy2.SizeMode = PictureBoxSizeMode.StretchImage;
                pic_Enemy2.BringToFront();
                pic_Enemy2.Tag = CodedObjects.Tag_Enemy2;

                // creating a key
                PictureBox pic_Key = new PictureBox();
                Controls.Add(pic_Key);
                pic_Key.Image = Resources.A_Key;
                pic_Key.BackColor = Color.Transparent;
                pic_Key.SizeMode = PictureBoxSizeMode.StretchImage;
                pic_Key.Size = new Size(50, 30);
                pic_Key.Location = new Point(730, 160);
                pic_Key.BringToFront();
                pic_Key.Tag = CodedObjects.Tag_Key;

                // creating notification about obtaining a key
                Label lbl_KeyObtained = new Label();
                Controls.Add(lbl_KeyObtained);
                lbl_KeyObtained.Location = new Point(700, 25);
                lbl_KeyObtained.Size = new Size(120, 50);
                lbl_KeyObtained.Font = new Font("Comic Sans MS", 22, FontStyle.Bold);
                lbl_KeyObtained.ForeColor = Color.Yellow;
                lbl_KeyObtained.BackColor = Color.Black;
                lbl_KeyObtained.BringToFront();
                lbl_KeyObtained.Text = "1 Key";
                lbl_KeyObtained.Visible = false;
                lbl_KeyObtained.Tag = CodedObjects.Tag_KeyText;

                // creating an exit door
                PictureBox pic_Exit = new PictureBox();
                Controls.Add(pic_Exit);
                pic_Exit.Size = new Size(40, 50);
                pic_Exit.SizeMode = PictureBoxSizeMode.StretchImage;
                pic_Exit.Location = new Point(15, 80);
                pic_Exit.Image = Resources.Door_Closed;
                pic_Exit.BringToFront();
                pic_Exit.Tag = CodedObjects.Tag_Exit;

                array_pbPlatforms[0] = pb_platform1_Left;
                array_pbPlatforms[1] = pb_platform2_Left;
                array_pbPlatforms[2] = pb_platform3_Middle;
                array_pbPlatforms[3] = pb_platform4_Middle;
                array_pbPlatforms[4] = pb_platform5_Right;
                array_pbPlatforms[5] = pb_platform6_Left;
            }
            // ---

            // ---
            // [LEVEL NINE] if level 9 is chosen
            if (intLevel == 9)
            {
                // it IS a ninth level
                isLevel = 9;

                // platform speed/velocity
                Yvel_platform = 4;
                Yvel_platform2 = 4;
                Xvel_platform = -4;

                // set player's location
                PIC_Player.Location = new Point(22, 420);

                // create an animated background image
                PictureBox pb_BackgroundGif = new PictureBox();
                Controls.Add(pb_BackgroundGif);
                pb_BackgroundGif.Image = Resources.gifBackground;
                pb_BackgroundGif.Dock = DockStyle.Fill;
                pb_BackgroundGif.SendToBack();
                PIC_Player.Parent = pb_BackgroundGif;

                // creating platform 1
                PictureBox pb_platform1_Left = new PictureBox();
                Controls.Add(pb_platform1_Left);
                pb_platform1_Left.Size = new Size(100, 10);
                pb_platform1_Left.Location = new Point(0, 490);
                pb_platform1_Left.BackColor = Color.Lime;
                pb_platform1_Left.BringToFront();

                // creating platform 2 (moving Y)
                PictureBox pb_platform2_Left = new PictureBox();
                Controls.Add(pb_platform2_Left);
                pb_platform2_Left.Size = new Size(70, 10);
                pb_platform2_Left.Location = new Point(170, 399);
                pb_platform2_Left.BackColor = Color.Lime;
                pb_platform2_Left.BringToFront();
                pb_platform2_Left.Tag = CodedObjects.Tag_MovePlat3;

                // creating platform 3 (moving X)
                PictureBox pb_platform3_Middle = new PictureBox();
                Controls.Add(pb_platform3_Middle);
                pb_platform3_Middle.Size = new Size(60, 10);
                pb_platform3_Middle.Location = new Point(330, 180);
                pb_platform3_Middle.BackColor = Color.Lime;
                pb_platform3_Middle.BringToFront();
                pb_platform3_Middle.Tag = CodedObjects.Tag_MovePlat;

                // creating platform 4
                PictureBox pb_platform4_Middle = new PictureBox();
                Controls.Add(pb_platform4_Middle);
                pb_platform4_Middle.Size = new Size(180, 10);
                pb_platform4_Middle.Location = new Point(330, 340);
                pb_platform4_Middle.BackColor = Color.Lime;
                pb_platform4_Middle.BringToFront();

                // creating platform 5 (moving Y)
                PictureBox pb_platform5_Middle = new PictureBox();
                Controls.Add(pb_platform5_Middle);
                pb_platform5_Middle.Size = new Size(60, 10);
                pb_platform5_Middle.Location = new Point(600, 399);
                pb_platform5_Middle.BackColor = Color.Lime;
                pb_platform5_Middle.BringToFront();
                pb_platform5_Middle.Tag = CodedObjects.Tag_MovePlat2;

                // creating platform 1
                PictureBox pb_platform6_Left = new PictureBox();
                Controls.Add(pb_platform6_Left);
                pb_platform6_Left.Size = new Size(100, 10);
                pb_platform6_Left.Location = new Point(0, 220);
                pb_platform6_Left.BackColor = Color.Lime;
                pb_platform6_Left.BringToFront();

                // creating a key
                PictureBox pic_Key = new PictureBox();
                Controls.Add(pic_Key);
                pic_Key.Image = Resources.A_Key;
                pic_Key.BackColor = Color.Transparent;
                pic_Key.SizeMode = PictureBoxSizeMode.StretchImage;
                pic_Key.Size = new Size(50, 30);
                pic_Key.Location = new Point(400, 100);
                pic_Key.BringToFront();
                pic_Key.Tag = CodedObjects.Tag_Key;

                // creating notification about obtaining a key
                Label lbl_KeyObtained = new Label();
                Controls.Add(lbl_KeyObtained);
                lbl_KeyObtained.Location = new Point(700, 25);
                lbl_KeyObtained.Size = new Size(120, 50);
                lbl_KeyObtained.Font = new Font("Comic Sans MS", 22, FontStyle.Bold);
                lbl_KeyObtained.ForeColor = Color.Yellow;
                lbl_KeyObtained.BackColor = Color.Black;
                lbl_KeyObtained.BringToFront();
                lbl_KeyObtained.Text = "1 Key";
                lbl_KeyObtained.Visible = false;
                lbl_KeyObtained.Tag = CodedObjects.Tag_KeyText;

                // creating an exit door
                PictureBox pic_Exit = new PictureBox();
                Controls.Add(pic_Exit);
                pic_Exit.Size = new Size(40, 50);
                pic_Exit.SizeMode = PictureBoxSizeMode.StretchImage;
                pic_Exit.Location = new Point(10, 170);
                pic_Exit.Image = Resources.Door_Closed;
                pic_Exit.BringToFront();
                pic_Exit.Tag = CodedObjects.Tag_Exit;

                // create an enemy unit (smarter enemy)
                PictureBox pic_Enemy = new PictureBox();
                Controls.Add(pic_Enemy);
                pic_Enemy.Image = Resources.EnemyMonster2;
                pic_Enemy.Size = new Size(40, 30);
                pic_Enemy.Location = new Point(340, 310);
                pic_Enemy.SizeMode = PictureBoxSizeMode.StretchImage;
                pic_Enemy.BringToFront();
                pic_Enemy.Tag = CodedObjects.Tag_Enemy;

                // create an enemy unit (bouncy enemy)
                PictureBox pic_Enemy2 = new PictureBox();
                Controls.Add(pic_Enemy2);
                pic_Enemy2.Image = Resources.EnemyMONSTER3;
                pic_Enemy2.Size = new Size(40, 30);
                pic_Enemy2.Location = new Point(10, 190);
                pic_Enemy2.SizeMode = PictureBoxSizeMode.StretchImage;
                pic_Enemy2.BringToFront();
                pic_Enemy2.Tag = CodedObjects.Tag_Enemy2;

                array_pbPlatforms[0] = pb_platform1_Left;
                array_pbPlatforms[1] = pb_platform2_Left;
                array_pbPlatforms[2] = pb_platform3_Middle;
                array_pbPlatforms[3] = pb_platform4_Middle;
                array_pbPlatforms[4] = pb_platform5_Middle;
                array_pbPlatforms[5] = pb_platform6_Left;
            }
            // ---

            // ---
            // [LEVEL TEN] if level 10 is chosen
            if (intLevel == 10)
            {
                // it IS a tenth level
                isLevel = 10;

                // platform speed/velocity
                Yvel_platform = 4;
                Yvel_platform2 = 4;
                Yvel_platform3 = 4;
                Yvel_platform4 = 4;
                Yvel_platform5 = 4;
                Xvel_platform = -4;
                Xvel_platform2 = -4;
                Xvel_platform3 = -4;

                // set player's location
                PIC_Player.Location = new Point(22, 400);

                // create an animated background image
                PictureBox pb_BackgroundGif = new PictureBox();
                Controls.Add(pb_BackgroundGif);
                pb_BackgroundGif.Image = Resources.gifBackground;
                pb_BackgroundGif.Dock = DockStyle.Fill;
                pb_BackgroundGif.SendToBack();
                PIC_Player.Parent = pb_BackgroundGif;

                // creating platform 1 (moving Y)
                PictureBox pb_platform1_Left = new PictureBox();
                Controls.Add(pb_platform1_Left);
                pb_platform1_Left.Size = new Size(70, 10);
                pb_platform1_Left.Location = new Point(10, 450);
                pb_platform1_Left.BackColor = Color.Lime;
                pb_platform1_Left.BringToFront();
                pb_platform1_Left.Tag = CodedObjects.Tag_MovePlat;

                // creating platform 2 (moving X)
                PictureBox pb_platform2_Middle = new PictureBox();
                Controls.Add(pb_platform2_Middle);
                pb_platform2_Middle.Size = new Size(70, 10);
                pb_platform2_Middle.Location = new Point(200, 350);
                pb_platform2_Middle.BackColor = Color.Lime;
                pb_platform2_Middle.BringToFront();
                pb_platform2_Middle.Tag = CodedObjects.Tag_MovePlat2;

                // creating platform 3 (moving X)
                PictureBox pb_platform3_Middle = new PictureBox();
                Controls.Add(pb_platform3_Middle);
                pb_platform3_Middle.Size = new Size(70, 10);
                pb_platform3_Middle.Location = new Point(500, 350);
                pb_platform3_Middle.BackColor = Color.Lime;
                pb_platform3_Middle.BringToFront();
                pb_platform3_Middle.Tag = CodedObjects.Tag_MovePlat3;

                // creating platform 4 (moving Y)
                PictureBox pb_platform4_Middle = new PictureBox();
                Controls.Add(pb_platform4_Middle);
                pb_platform4_Middle.Size = new Size(70, 10);
                pb_platform4_Middle.Location = new Point(350, 250);
                pb_platform4_Middle.BackColor = Color.Lime;
                pb_platform4_Middle.BringToFront();
                pb_platform4_Middle.Tag = CodedObjects.Tag_MovePlat4;

                // creating platform 5 (moving Y)
                PictureBox pb_platform5_Middle = new PictureBox();
                Controls.Add(pb_platform5_Middle);
                pb_platform5_Middle.Size = new Size(70, 10);
                pb_platform5_Middle.Location = new Point(350, 450);
                pb_platform5_Middle.BackColor = Color.Lime;
                pb_platform5_Middle.BringToFront();
                pb_platform5_Middle.Tag = CodedObjects.Tag_MovePlat5;

                // creating platform 6 (moving Y)
                PictureBox pb_platform6_Right = new PictureBox();
                Controls.Add(pb_platform6_Right);
                pb_platform6_Right.Size = new Size(70, 10);
                pb_platform6_Right.Location = new Point(620, 250);
                pb_platform6_Right.BackColor = Color.Lime;
                pb_platform6_Right.BringToFront();
                pb_platform6_Right.Tag = CodedObjects.Tag_MovePlat6;

                // creating an exit door
                PictureBox pic_Exit = new PictureBox();
                Controls.Add(pic_Exit);
                pic_Exit.Size = new Size(40, 50);
                pic_Exit.BackColor = Color.Red;
                pic_Exit.SizeMode = PictureBoxSizeMode.StretchImage;
                pic_Exit.Location = new Point(420, 430);
                pic_Exit.Image = Resources.Door_Closed;
                pic_Exit.BringToFront();

                // creating an exit door 2
                PictureBox pic_Exit2 = new PictureBox();
                Controls.Add(pic_Exit2);
                pic_Exit2.Size = new Size(40, 50);
                pic_Exit2.BackColor = Color.Yellow;
                pic_Exit2.SizeMode = PictureBoxSizeMode.StretchImage;
                pic_Exit2.Location = new Point(720, 220);
                pic_Exit2.Image = Resources.Door_Closed;
                pic_Exit2.BringToFront();

                // decide the correct door
                DoorChoice(pic_Exit, pic_Exit2);

                // creating a key
                PictureBox pic_Key = new PictureBox();
                Controls.Add(pic_Key);
                pic_Key.Image = Resources.A_Key;
                pic_Key.BackColor = Color.Transparent;
                pic_Key.SizeMode = PictureBoxSizeMode.StretchImage;
                pic_Key.Size = new Size(50, 30);
                pic_Key.Location = new Point(250, 100);
                pic_Key.BringToFront();
                pic_Key.Tag = CodedObjects.Tag_Key;


                array_pbPlatforms[0] = pb_platform1_Left;
                array_pbPlatforms[1] = pb_platform2_Middle;
                array_pbPlatforms[2] = pb_platform3_Middle;
                array_pbPlatforms[3] = pb_platform4_Middle;
                array_pbPlatforms[4] = pb_platform5_Middle;
                array_pbPlatforms[5] = pb_platform6_Right;
            }
            // ---


            // ---
            // [BONUS] [LEVEL ONE] if level 1 is chosen
            if (intLevel == 11)
            {
                // it IS a first level
                isLevel = 11;

                // set player's location
                PIC_Player.Location = new Point(22, 470);

                // create an animated background image
                PictureBox pb_BackgroundGif = new PictureBox();
                Controls.Add(pb_BackgroundGif);
                pb_BackgroundGif.Image = Resources.gifBackground;
                pb_BackgroundGif.Dock = DockStyle.Fill;
                pb_BackgroundGif.SendToBack();
                PIC_Player.Parent = pb_BackgroundGif;

                // creating platform 1
                PictureBox pb_platform1_Left = new PictureBox();
                Controls.Add(pb_platform1_Left);
                pb_platform1_Left.Size = new Size(70, 10);
                pb_platform1_Left.Location = new Point(10, 490);
                pb_platform1_Left.BackColor = Color.Lime;
                pb_platform1_Left.BringToFront();

                // creating platform 2
                PictureBox pb_platform2_Left = new PictureBox();
                Controls.Add(pb_platform2_Left);
                pb_platform2_Left.Size = new Size(70, 10);
                pb_platform2_Left.Location = new Point(140, 420);
                pb_platform2_Left.BackColor = Color.Lime;
                pb_platform2_Left.BringToFront();

                // creating platform 3
                PictureBox pb_platform3_Left = new PictureBox();
                Controls.Add(pb_platform3_Left);
                pb_platform3_Left.Size = new Size(70, 10);
                pb_platform3_Left.Location = new Point(140, 270);
                pb_platform3_Left.BackColor = Color.Lime;
                pb_platform3_Left.BringToFront();

                // creating platform 4
                PictureBox pb_platform4_Left = new PictureBox();
                Controls.Add(pb_platform4_Left);
                pb_platform4_Left.Size = new Size(70, 10);
                pb_platform4_Left.Location = new Point(0, 340);
                pb_platform4_Left.BackColor = Color.Lime;
                pb_platform4_Left.BringToFront();

                // creating platform 5
                PictureBox pb_platform5_Middle = new PictureBox();
                Controls.Add(pb_platform5_Middle);
                pb_platform5_Middle.Size = new Size(70, 10);
                pb_platform5_Middle.Location = new Point(310, 420);
                pb_platform5_Middle.BackColor = Color.Lime;
                pb_platform5_Middle.BringToFront();

                // creating platform 6
                PictureBox pb_platform6_Middle = new PictureBox();
                Controls.Add(pb_platform6_Middle);
                pb_platform6_Middle.Size = new Size(70, 10);
                pb_platform6_Middle.Location = new Point(310, 270);
                pb_platform6_Middle.BackColor = Color.Lime;
                pb_platform6_Middle.BringToFront();

                // creating platform 7
                PictureBox pb_platform7_Middle = new PictureBox();
                Controls.Add(pb_platform7_Middle);
                pb_platform7_Middle.Size = new Size(70, 10);
                pb_platform7_Middle.Location = new Point(500, 420);
                pb_platform7_Middle.BackColor = Color.Lime;
                pb_platform7_Middle.BringToFront();

                // creating platform 8
                PictureBox pb_platform8_Middle = new PictureBox();
                Controls.Add(pb_platform8_Middle);
                pb_platform8_Middle.Size = new Size(70, 10);
                pb_platform8_Middle.Location = new Point(500, 270);
                pb_platform8_Middle.BackColor = Color.Lime;
                pb_platform8_Middle.BringToFront();

                // creating an exit door
                PictureBox pic_Exit = new PictureBox();
                Controls.Add(pic_Exit);
                pic_Exit.Size = new Size(40, 50);
                pic_Exit.BackColor = Color.Red;
                pic_Exit.SizeMode = PictureBoxSizeMode.StretchImage;
                pic_Exit.Location = new Point(330, 370);
                pic_Exit.Image = Resources.Door_Closed;
                pic_Exit.BringToFront();

                // creating an exit door 2
                PictureBox pic_Exit2 = new PictureBox();
                Controls.Add(pic_Exit2);
                pic_Exit2.Size = new Size(40, 50);
                pic_Exit2.BackColor = Color.Yellow;
                pic_Exit2.SizeMode = PictureBoxSizeMode.StretchImage;
                pic_Exit2.Location = new Point(520, 220);
                pic_Exit2.Image = Resources.Door_Closed;
                pic_Exit2.BringToFront();

                // creating an exit door 3
                PictureBox pic_Exit3 = new PictureBox();
                Controls.Add(pic_Exit3);
                pic_Exit3.Size = new Size(40, 50);
                pic_Exit3.BackColor = Color.Red;
                pic_Exit3.SizeMode = PictureBoxSizeMode.StretchImage;
                pic_Exit3.Location = new Point(150, 370);
                pic_Exit3.Image = Resources.Door_Closed;
                pic_Exit3.BringToFront();

                // creating an exit door 4
                PictureBox pic_Exit4 = new PictureBox();
                Controls.Add(pic_Exit4);
                pic_Exit4.Size = new Size(40, 50);
                pic_Exit4.BackColor = Color.Yellow;
                pic_Exit4.SizeMode = PictureBoxSizeMode.StretchImage;
                pic_Exit4.Location = new Point(515, 370);
                pic_Exit4.Image = Resources.Door_Closed;
                pic_Exit4.BringToFront();

                // creating an exit door 5
                PictureBox pic_Exit5 = new PictureBox();
                Controls.Add(pic_Exit5);
                pic_Exit5.Size = new Size(40, 50);
                pic_Exit5.BackColor = Color.Red;
                pic_Exit5.SizeMode = PictureBoxSizeMode.StretchImage;
                pic_Exit5.Location = new Point(150, 220);
                pic_Exit5.Image = Resources.Door_Closed;
                pic_Exit5.BringToFront();

                // creating an exit door 4
                PictureBox pic_Exit6 = new PictureBox();
                Controls.Add(pic_Exit6);
                pic_Exit6.Size = new Size(40, 50);
                pic_Exit6.BackColor = Color.Yellow;
                pic_Exit6.SizeMode = PictureBoxSizeMode.StretchImage;
                pic_Exit6.Location = new Point(320, 220);
                pic_Exit6.Image = Resources.Door_Closed;
                pic_Exit6.BringToFront();

                // decide the correct door
                DoorChoice2(pic_Exit, pic_Exit2, pic_Exit3, pic_Exit4, pic_Exit5, pic_Exit6);

                // creating a key
                PictureBox pic_Key = new PictureBox();
                Controls.Add(pic_Key);
                pic_Key.Image = Resources.A_Key;
                pic_Key.BackColor = Color.Transparent;
                pic_Key.SizeMode = PictureBoxSizeMode.StretchImage;
                pic_Key.Size = new Size(50, 30);
                pic_Key.Location = new Point(250, 150);
                pic_Key.BringToFront();
                pic_Key.Tag = CodedObjects.Tag_Key;


                array_pbPlatforms[0] = pb_platform1_Left;
                array_pbPlatforms[1] = pb_platform2_Left;
                array_pbPlatforms[2] = pb_platform3_Left;
                array_pbPlatforms[3] = pb_platform4_Left;
                array_pbPlatforms[4] = pb_platform5_Middle;
                array_pbPlatforms[5] = pb_platform6_Middle;
                array_pbPlatforms[6] = pb_platform7_Middle;
                array_pbPlatforms[7] = pb_platform8_Middle;
            }
            // ---
            
            // ---
            // [BONUS] [LEVEL TWO] if level 2 is chosen
            if (intLevel == 12)
            {
                // it IS a second level
                isLevel = 12;

                // platform speed/velocity
                Yvel_platform = 4;
                Yvel_platform2 = 4;
                Xvel_platform = -4;
                Xvel_platform2 = -4;

                // set player's location
                PIC_Player.Location = new Point(22, 400);

                // create an animated background image
                PictureBox pb_BackgroundGif = new PictureBox();
                Controls.Add(pb_BackgroundGif);
                pb_BackgroundGif.Image = Resources.gifBackground;
                pb_BackgroundGif.Dock = DockStyle.Fill;
                pb_BackgroundGif.SendToBack();
                PIC_Player.Parent = pb_BackgroundGif;

                // creating platform 1 (moving Y)
                PictureBox pb_platform1_Left = new PictureBox();
                Controls.Add(pb_platform1_Left);
                pb_platform1_Left.Size = new Size(70, 10);
                pb_platform1_Left.Location = new Point(10, 450);
                pb_platform1_Left.BackColor = Color.Lime;
                pb_platform1_Left.BringToFront();
                pb_platform1_Left.Tag = CodedObjects.Tag_MovePlat;

                // creating platform 2 (moving Y)
                PictureBox pb_platform2_Middle = new PictureBox();
                Controls.Add(pb_platform2_Middle);
                pb_platform2_Middle.Size = new Size(70, 10);
                pb_platform2_Middle.Location = new Point(110, 300);
                pb_platform2_Middle.BackColor = Color.Lime;
                pb_platform2_Middle.BringToFront();
                pb_platform2_Middle.Tag = CodedObjects.Tag_MovePlat2;

                // creating platform 3 (moving X)
                PictureBox pb_platform3_Middle = new PictureBox();
                Controls.Add(pb_platform3_Middle);
                pb_platform3_Middle.Size = new Size(70, 10);
                pb_platform3_Middle.Location = new Point(250, 230);
                pb_platform3_Middle.BackColor = Color.Lime;
                pb_platform3_Middle.BringToFront();
                pb_platform3_Middle.Tag = CodedObjects.Tag_MovePlat3;
                
                // creating platform 4 (moving Y)
                PictureBox pb_platform4_Right = new PictureBox();
                Controls.Add(pb_platform4_Right);
                pb_platform4_Right.Size = new Size(70, 10);
                pb_platform4_Right.Location = new Point(500, 230);
                pb_platform4_Right.BackColor = Color.Lime;
                pb_platform4_Right.BringToFront();
                pb_platform4_Right.Tag = CodedObjects.Tag_MovePlat4;
                
                // creating platform 5 (moving Y)
                PictureBox pb_platform5_Right = new PictureBox();
                Controls.Add(pb_platform5_Right);
                pb_platform5_Right.Size = new Size(70, 10);
                pb_platform5_Right.Location = new Point(650, 440);
                pb_platform5_Right.BackColor = Color.Lime;
                pb_platform5_Right.BringToFront();
                pb_platform5_Right.Tag = CodedObjects.Tag_MovePlat5;

                // creating an exit door
                PictureBox pic_Exit = new PictureBox();
                Controls.Add(pic_Exit);
                pic_Exit.Size = new Size(40, 50);
                pic_Exit.BackColor = Color.Red;
                pic_Exit.SizeMode = PictureBoxSizeMode.StretchImage;
                pic_Exit.Location = new Point(670, 370);
                pic_Exit.Image = Resources.Door_Closed;
                pic_Exit.Tag = CodedObjects.Tag_Exit;
                pic_Exit.BringToFront();

                // creating a key
                PictureBox pic_Key = new PictureBox();
                Controls.Add(pic_Key);
                pic_Key.Image = Resources.A_Key;
                pic_Key.BackColor = Color.Transparent;
                pic_Key.SizeMode = PictureBoxSizeMode.StretchImage;
                pic_Key.Size = new Size(50, 30);
                pic_Key.Location = new Point(400, 120);
                pic_Key.BringToFront();
                pic_Key.Tag = CodedObjects.Tag_Key;

                array_pbPlatforms[0] = pb_platform1_Left;
                array_pbPlatforms[1] = pb_platform2_Middle;
                array_pbPlatforms[2] = pb_platform3_Middle;
                array_pbPlatforms[3] = pb_platform4_Right;
                array_pbPlatforms[4] = pb_platform5_Right;
            }
            // ---
            
            // ---
            // [BONUS] [LEVEL THREE] if level 3 is chosen
            if (intLevel == 13)
            {
                // it IS a third level
                isLevel = 13;

                Xvel_enemy2 = 2;
                Xvel_enemy3 = 2;
                Xvel_enemy4 = 2;

                // set player's location
                PIC_Player.Location = new Point(22, 300);

                // create an animated background image
                PictureBox pb_BackgroundGif = new PictureBox();
                Controls.Add(pb_BackgroundGif);
                pb_BackgroundGif.Image = Resources.gifBackground;
                pb_BackgroundGif.Dock = DockStyle.Fill;
                pb_BackgroundGif.SendToBack();
                PIC_Player.Parent = pb_BackgroundGif;

                // creating platform 1
                PictureBox pb_platform1_Left = new PictureBox();
                Controls.Add(pb_platform1_Left);
                pb_platform1_Left.Size = new Size(400, 10);
                pb_platform1_Left.Location = new Point(0, 350);
                pb_platform1_Left.BackColor = Color.Lime;
                pb_platform1_Left.BringToFront();
                
                // creating platform 2
                PictureBox pb_platform2_Left = new PictureBox();
                Controls.Add(pb_platform2_Left);
                pb_platform2_Left.Size = new Size(300, 10);
                pb_platform2_Left.Location = new Point(500, 350);
                pb_platform2_Left.BackColor = Color.Lime;
                pb_platform2_Left.BringToFront();

                // create an enemy unit (bouncy enemy)
                PictureBox pic_Enemy = new PictureBox();
                Controls.Add(pic_Enemy);
                pic_Enemy.Image = Resources.EnemyMONSTER3;
                pic_Enemy.Size = new Size(40, 30);
                pic_Enemy.Location = new Point(100, 320);
                pic_Enemy.SizeMode = PictureBoxSizeMode.StretchImage;
                pic_Enemy.BringToFront();
                pic_Enemy.Tag = CodedObjects.Tag_Enemy;

                // create an enemy unit 2 (bouncy enemy)
                PictureBox pic_Enemy2 = new PictureBox();
                Controls.Add(pic_Enemy2);
                pic_Enemy2.Image = Resources.EnemyMONSTER3;
                pic_Enemy2.Size = new Size(40, 30);
                pic_Enemy2.Location = new Point(250, 320);
                pic_Enemy2.SizeMode = PictureBoxSizeMode.StretchImage;
                pic_Enemy2.BringToFront();
                pic_Enemy2.Tag = CodedObjects.Tag_Enemy2;
                
                // create an enemy unit 3 (bouncy enemy)
                PictureBox pic_Enemy3 = new PictureBox();
                Controls.Add(pic_Enemy3);
                pic_Enemy3.Image = Resources.EnemyMONSTER3;
                pic_Enemy3.Size = new Size(40, 30);
                pic_Enemy3.Location = new Point(500, 320);
                pic_Enemy3.SizeMode = PictureBoxSizeMode.StretchImage;
                pic_Enemy3.BringToFront();
                pic_Enemy3.Tag = CodedObjects.Tag_Enemy3;

                // create an enemy unit 4 (bouncy enemy)
                PictureBox pic_Enemy4 = new PictureBox();
                Controls.Add(pic_Enemy4);
                pic_Enemy4.Image = Resources.EnemyMONSTER3;
                pic_Enemy4.Size = new Size(40, 30);
                pic_Enemy4.Location = new Point(650, 320);
                pic_Enemy4.SizeMode = PictureBoxSizeMode.StretchImage;
                pic_Enemy4.BringToFront();
                pic_Enemy4.Tag = CodedObjects.Tag_Enemy4;

                // creating an exit door
                PictureBox pic_Exit = new PictureBox();
                Controls.Add(pic_Exit);
                pic_Exit.Size = new Size(40, 50);
                pic_Exit.BackColor = Color.Red;
                pic_Exit.SizeMode = PictureBoxSizeMode.StretchImage;
                pic_Exit.Location = new Point(720, 300);
                pic_Exit.Image = Resources.Door_Closed;
                pic_Exit.Tag = CodedObjects.Tag_Exit;
                pic_Exit.BringToFront();

                // creating a key
                PictureBox pic_Key = new PictureBox();
                Controls.Add(pic_Key);
                pic_Key.Image = Resources.A_Key;
                pic_Key.BackColor = Color.Transparent;
                pic_Key.SizeMode = PictureBoxSizeMode.StretchImage;
                pic_Key.Size = new Size(50, 30);
                pic_Key.Location = new Point(350, 280);
                pic_Key.BringToFront();
                pic_Key.Tag = CodedObjects.Tag_Key;

                array_pbPlatforms[0] = pb_platform1_Left;
                array_pbPlatforms[1] = pb_platform2_Left;
            }
            // ---


            // turn on FPS timer / Game looper
            FPS_Timer.Enabled = true;
        }

        // if play reaches any screen limit
        private void ScreenSizeLimit()
        {
            // if the player touches left side of screen limit
            if (PIC_Player.Left < 0)
            {
                PIC_Player.Left -= PIC_Player.Left;
            }

            // if the player touches right side of screen limit
            if (PIC_Player.Left > 780)
            {
                PIC_Player.Left -= PIC_Player.Left;
                PIC_Player.Left = 780;
            }

            // if the player touches the top of the screen
            if (PIC_Player.Top <= 1)
            {
                yVel *= -2;
                blnKeyUp = false;
            }
            
            // if the player touches the bottom of the screen
            if (PIC_Player.Top > 570)
            {
                // if there is life left
                if (intLives > 1)
                {
                    // deduct one life value from the player's total
                    intLives -= 1;
                    lbl_Lives.Text = Convert.ToString(intLives);

                    // reset player location
                    PIC_Player.Location = new Point(22, 400);

                    // go through certain level on which the bottom screen was reached in
                    BoundaryReach(isLevel);
                }

                // otherwise, lose
                else
                {
                    lbl_Lives.Text = "0";
                    LoseScenario();

                }
            }

        }

        // if bottom screen boundary is reached
        private void BoundaryReach(int islevel)
        {
            // tutorial
            if (isLevel == 0)
            {
                isObtained = false;
                
                // if achievement trophy was not obtained before
                if (A1_Obtained == false)
                {
                    AchievementOne_Obtained = false;
                }

                // otherwise, it was obtained in past
                else
                {
                    AchievementOne_Obtained = true;
                }

                // creating a key
                PictureBox pic_Key = new PictureBox();
                Controls.Add(pic_Key);
                pic_Key.Image = Resources.A_Key;
                pic_Key.BackColor = Color.Transparent;
                pic_Key.SizeMode = PictureBoxSizeMode.StretchImage;
                pic_Key.Size = new Size(50, 30);
                pic_Key.Location = new Point(190, 80);
                pic_Key.BringToFront();
                pic_Key.Tag = CodedObjects.Tag_Key;

                // create a achievement object to be obtained
                PictureBox pbAchievement = new PictureBox();
                Controls.Add(pbAchievement);
                pbAchievement.Image = Resources.Atrophy1;
                pbAchievement.Location = new Point(770, 10);
                pbAchievement.Size = new Size(40, 40);
                pbAchievement.SizeMode = PictureBoxSizeMode.StretchImage;
                pbAchievement.BringToFront();
                pbAchievement.Enabled = false;
                pbAchievement.Visible = false;
                pbAchievement.Tag = CodedObjects.Tag_Achievement;
            }

            // level 1
            if (isLevel == 1)
            {
                isObtained = false;

                // if achievement trophy 2 was not obtained before
                if (A2_Obtained == false)
                {
                    AchievementTwo_Obtained = false;
                }

                // otherwise, it was obtained in past
                else
                {
                    AchievementTwo_Obtained = true;
                }

                // creating a key
                PictureBox pic_Key = new PictureBox();
                Controls.Add(pic_Key);
                pic_Key.Image = Resources.A_Key;
                pic_Key.BackColor = Color.Transparent;
                pic_Key.SizeMode = PictureBoxSizeMode.StretchImage;
                pic_Key.Size = new Size(50, 30);
                pic_Key.Location = new Point(750, 420);
                pic_Key.BringToFront();
                pic_Key.Tag = CodedObjects.Tag_Key;
            }

            // level 2
            if (isLevel == 2)
            {
                isObtained = false;

                // if achievement trophy 2 was not obtained before
                if (A2_Obtained == false)
                {
                    AchievementTwo_Obtained = false;
                }

                // otherwise, it was obtained in past
                else
                {
                    AchievementTwo_Obtained = true;
                }

                // creating a key
                PictureBox pic_Key = new PictureBox();
                Controls.Add(pic_Key);
                pic_Key.Image = Resources.A_Key;
                pic_Key.BackColor = Color.Transparent;
                pic_Key.SizeMode = PictureBoxSizeMode.StretchImage;
                pic_Key.Size = new Size(50, 30);
                pic_Key.Location = new Point(750, 440);
                pic_Key.BringToFront();
                pic_Key.Tag = CodedObjects.Tag_Key;

                // create a achievement object to be obtained
                PictureBox pbAchievement = new PictureBox();
                Controls.Add(pbAchievement);
                pbAchievement.Enabled = false;
                pbAchievement.Visible = false;
                pbAchievement.Image = Resources.Atrophy2;
                pbAchievement.Location = new Point(0, 150);
                pbAchievement.Size = new Size(40, 40);
                pbAchievement.SizeMode = PictureBoxSizeMode.StretchImage;
                pbAchievement.BringToFront();
                pbAchievement.Tag = CodedObjects.Tag_Achievement;
            }

            // level 3
            if (isLevel == 3)
            {
                isObtained = false;

                // creating a key
                PictureBox pic_Key = new PictureBox();
                Controls.Add(pic_Key);
                pic_Key.Image = Resources.A_Key;
                pic_Key.BackColor = Color.Transparent;
                pic_Key.SizeMode = PictureBoxSizeMode.StretchImage;
                pic_Key.Size = new Size(50, 30);
                pic_Key.Location = new Point(730, 350);
                pic_Key.BringToFront();
                pic_Key.Tag = CodedObjects.Tag_Key;
            }

            // level 4
            if (isLevel == 4)
            {
                isObtained = false;

                // creating a key
                PictureBox pic_Key = new PictureBox();
                Controls.Add(pic_Key);
                pic_Key.Image = Resources.A_Key;
                pic_Key.BackColor = Color.Transparent;
                pic_Key.SizeMode = PictureBoxSizeMode.StretchImage;
                pic_Key.Size = new Size(50, 30);
                pic_Key.Location = new Point(730, 150);
                pic_Key.BringToFront();
                pic_Key.Tag = CodedObjects.Tag_Key;
            }

            // level 5
            if (isLevel == 5)
            {
                isObtained = false;

                // creating a key
                PictureBox pic_Key = new PictureBox();
                Controls.Add(pic_Key);
                pic_Key.Image = Resources.A_Key;
                pic_Key.BackColor = Color.Transparent;
                pic_Key.SizeMode = PictureBoxSizeMode.StretchImage;
                pic_Key.Size = new Size(50, 30);
                pic_Key.Location = new Point(100, 60);
                pic_Key.BringToFront();
                pic_Key.Tag = CodedObjects.Tag_Key;
            }

            // level 6
            if (isLevel == 6)
            {
                isObtained = false;

                // creating a key
                PictureBox pic_Key = new PictureBox();
                Controls.Add(pic_Key);
                pic_Key.Image = Resources.A_Key;
                pic_Key.BackColor = Color.Transparent;
                pic_Key.SizeMode = PictureBoxSizeMode.StretchImage;
                pic_Key.Size = new Size(50, 30);
                pic_Key.Location = new Point(550, 200);
                pic_Key.BringToFront();
                pic_Key.Tag = CodedObjects.Tag_Key;
            }

            // level 7
            if (isLevel == 7)
            {
                isObtained = false;

                // creating a key
                PictureBox pic_Key = new PictureBox();
                Controls.Add(pic_Key);
                pic_Key.Image = Resources.A_Key;
                pic_Key.BackColor = Color.Transparent;
                pic_Key.SizeMode = PictureBoxSizeMode.StretchImage;
                pic_Key.Size = new Size(50, 30);
                pic_Key.Location = new Point(700, 150);
                pic_Key.BringToFront();
                pic_Key.Tag = CodedObjects.Tag_Key;
            }

            // level 8
            if (isLevel == 8)
            {
                isObtained = false;

                // creating a key
                PictureBox pic_Key = new PictureBox();
                Controls.Add(pic_Key);
                pic_Key.Image = Resources.A_Key;
                pic_Key.BackColor = Color.Transparent;
                pic_Key.SizeMode = PictureBoxSizeMode.StretchImage;
                pic_Key.Size = new Size(50, 30);
                pic_Key.Location = new Point(730, 160);
                pic_Key.BringToFront();
                pic_Key.Tag = CodedObjects.Tag_Key;
            }

            // level 9
            if (isLevel == 9)
            {
                isObtained = false;

                // creating a key
                PictureBox pic_Key = new PictureBox();
                Controls.Add(pic_Key);
                pic_Key.Image = Resources.A_Key;
                pic_Key.BackColor = Color.Transparent;
                pic_Key.SizeMode = PictureBoxSizeMode.StretchImage;
                pic_Key.Size = new Size(50, 30);
                pic_Key.Location = new Point(400, 100);
                pic_Key.BringToFront();
                pic_Key.Tag = CodedObjects.Tag_Key;
            }

            // level 10
            if (isLevel == 10)
            {
                // indicate a life was lost
                livelost = true;

                isObtained = false;

                // creating a key
                PictureBox pic_Key = new PictureBox();
                Controls.Add(pic_Key);
                pic_Key.Image = Resources.A_Key;
                pic_Key.BackColor = Color.Transparent;
                pic_Key.SizeMode = PictureBoxSizeMode.StretchImage;
                pic_Key.Size = new Size(50, 30);
                pic_Key.Location = new Point(250, 100);
                pic_Key.BringToFront();
                pic_Key.Tag = CodedObjects.Tag_Key;
            }
            
            // level 11
            if (isLevel == 11)
            {
                // indicate a life was lost
                livelost = true;

                isObtained = false;

                // creating a key
                PictureBox pic_Key = new PictureBox();
                Controls.Add(pic_Key);
                pic_Key.Image = Resources.A_Key;
                pic_Key.BackColor = Color.Transparent;
                pic_Key.SizeMode = PictureBoxSizeMode.StretchImage;
                pic_Key.Size = new Size(50, 30);
                pic_Key.Location = new Point(250, 150);
                pic_Key.BringToFront();
                pic_Key.Tag = CodedObjects.Tag_Key;
            }
            
            // level 12
            if (isLevel == 12)
            {
                // indicate a life was lost
                livelost = true;

                isObtained = false;

                // creating a key
                PictureBox pic_Key = new PictureBox();
                Controls.Add(pic_Key);
                pic_Key.Image = Resources.A_Key;
                pic_Key.BackColor = Color.Transparent;
                pic_Key.SizeMode = PictureBoxSizeMode.StretchImage;
                pic_Key.Size = new Size(50, 30);
                pic_Key.Location = new Point(400, 120);
                pic_Key.BringToFront();
                pic_Key.Tag = CodedObjects.Tag_Key;
            }
            
            // level 13
            if (isLevel == 13)
            {
                // indicate a life was lost
                livelost = true;

                isObtained = false;

                // creating a key
                PictureBox pic_Key = new PictureBox();
                Controls.Add(pic_Key);
                pic_Key.Image = Resources.A_Key;
                pic_Key.BackColor = Color.Transparent;
                pic_Key.SizeMode = PictureBoxSizeMode.StretchImage;
                pic_Key.Size = new Size(50, 30);
                pic_Key.Location = new Point(350, 280);
                pic_Key.BringToFront();
                pic_Key.Tag = CodedObjects.Tag_Key;
            }
        }

        // Decide which door will be real at random
        private void DoorChoice(PictureBox Exit, PictureBox Exit2)
        {
            Random rnd = new Random();
            int rChoice = rnd.Next(0, 6);

            switch (rChoice)
            {
                case 0:
                    Exit.Tag = CodedObjects.Tag_Exit;
                    break;
                case 1:
                    Exit2.Tag = CodedObjects.Tag_Exit;
                    break;
                case 2:
                    Exit.Tag = CodedObjects.Tag_Exit;
                    break;
                case 3:
                    Exit2.Tag = CodedObjects.Tag_Exit;
                    break;
                case 4:
                    Exit.Tag = CodedObjects.Tag_Exit;
                    break;
                case 5:
                    Exit2.Tag = CodedObjects.Tag_Exit;
                    break;
                case 6:
                    Exit.Tag = CodedObjects.Tag_Exit;
                    break;
            }
        }

        // Decide which door will be real at random
        private void DoorChoice2(PictureBox Exit, PictureBox Exit2, PictureBox Exit3, PictureBox Exit4, PictureBox Exit5, PictureBox Exit6)
        {
            Random rnd = new Random();
            int rChoice = rnd.Next(0, 7);

            switch(rChoice)
            {
                case 0:
                    Exit.Tag = CodedObjects.Tag_Exit;
                    break;
                case 1:
                    Exit2.Tag = CodedObjects.Tag_Exit;
                    break;
                case 2:
                    Exit3.Tag = CodedObjects.Tag_Exit;
                    break;
                case 3:
                    Exit4.Tag = CodedObjects.Tag_Exit;
                    break;
                case 4:
                    Exit5.Tag = CodedObjects.Tag_Exit;
                    break;
                case 5:
                    Exit6.Tag = CodedObjects.Tag_Exit;
                    break;
                case 6:
                    Exit.Tag = CodedObjects.Tag_Exit;
                    break;
                case 7:
                    Exit2.Tag = CodedObjects.Tag_Exit;
                    break;
            }
        }

        // NPC Guider
        private void GuiderDoTeach()
        {
            Stopwatch_Secs.Stop();
            
            MessageBox.Show("Welcome to the game, player. This is where the fun begins.", "Guider");
            MessageBox.Show("I'm your guider and I will help you complete this level.", "Guider");
            MessageBox.Show("Don't worry about getting lost.\nYou can always press 'ESC' key to open pause menu and press 'Hint' button and I'll tell you random fact about the game.", "Guider");
            MessageBox.Show("You probably have seen 'Instructions' menu giving you all details about the point of the game, but I'll summarise in fewer words.", "Guider");
            MessageBox.Show(" INSTRUCTIONS \n - Avoid touching enemy units\n - Use arrow keys to move 'Rally' (your player character)\n - To interact, press the 'E' key \n - Use shop features to help you with hard levels if you're stuck\n - Use coins very wisely\n - Obtain the key to unlock exit door\n - Once you interact with unlocked exit - mission completed.", "Guider");
            MessageBox.Show("What are the goals? Well, you name it;\nCompetition with friends, achievement hunt, level completion and even 100% progress if you're a tryhard.", "Guider");
            MessageBox.Show("That's it for me, good luck in your progress and have fun!", "Guider");

            Stopwatch_Secs.Start();
        }

        // automatically control enemy movements
        int iE;
        private void EnemyAI(int isLevel, PictureBox pbEtagged)
        {
            lbl_Lives.Text = Convert.ToString(intLives);

            // if it's a tutorial
            if (isLevel == 0)
            {
                // move the enemy
                pbEtagged.Left += Xvel_enemy;

                // if the enemy touches its left platform edge
                if (pbEtagged.Left < 300)
                {
                    Xvel_enemy = -Xvel_enemy;
                    pbEtagged.Image = Resources.EnemyMONSTER_org;
                }

                // if the enemy touches its left platform edge
                if (pbEtagged.Right > 510)
                {
                    Xvel_enemy = -Xvel_enemy;
                    pbEtagged.Image = Resources.EnemyMONSTER_reverse;
                }

                // if enemy touches the player
                if (pbEtagged.Bounds.IntersectsWith(PIC_Player.Bounds))
                {

                    // if there is life left
                    if (intLives > 1)
                    {
                        // deduct one life value from the player's total
                        intLives -= 1;
                        lbl_Lives.Text = Convert.ToString(intLives);

                        // reset player location
                        PIC_Player.Location = new Point(22, 425);

                        isObtained = false;

                        // if achievement trophy was not obtained before
                        if (A1_Obtained == false)
                        {
                            AchievementOne_Obtained = false;
                        }

                        // otherwise, it was obtained in past
                        else
                        {
                            AchievementOne_Obtained = true;
                        }

                        // create a achievement object to be obtained
                        PictureBox pbAchievement = new PictureBox();
                        Controls.Add(pbAchievement);
                        pbAchievement.Image = Resources.Atrophy1;
                        pbAchievement.Location = new Point(770, 10);
                        pbAchievement.Size = new Size(40, 40);
                        pbAchievement.SizeMode = PictureBoxSizeMode.StretchImage;
                        pbAchievement.BringToFront();
                        pbAchievement.Enabled = false;
                        pbAchievement.Visible = false;
                        pbAchievement.Tag = CodedObjects.Tag_Achievement;

                        // creating a key
                        PictureBox pic_Key = new PictureBox();
                        Controls.Add(pic_Key);
                        pic_Key.Image = Resources.A_Key;
                        pic_Key.BackColor = Color.Transparent;
                        pic_Key.SizeMode = PictureBoxSizeMode.StretchImage;
                        pic_Key.Size = new Size(50, 30);
                        pic_Key.Location = new Point(190, 80);
                        pic_Key.BringToFront();
                        pic_Key.Tag = CodedObjects.Tag_Key;

                    }

                    // otherwise, lose
                    else
                    {
                        lbl_Lives.Text = "0";
                        LoseScenario();

                    }
                }
            }

            // [LEVEL ONE]
            else if (isLevel == 1)
            {
                // move the enemy
                pbEtagged.Left += Xvel_enemy;

                // if the enemy touches its left platform edge
                if (pbEtagged.Left < 260)
                {
                    Xvel_enemy = -Xvel_enemy;
                    pbEtagged.Image = Resources.EnemyMONSTER_org;
                }

                // if the enemy touches its right platform edge
                if (pbEtagged.Right > 460)
                {
                    Xvel_enemy = -Xvel_enemy;
                    pbEtagged.Image = Resources.EnemyMONSTER_reverse;
                }

                // if enemy touches the player
                if (pbEtagged.Bounds.IntersectsWith(PIC_Player.Bounds))
                {

                    // if there is life left
                    if (intLives > 1)
                    {
                        // deduct one life value from the player's total
                        intLives -= 1;
                        lbl_Lives.Text = Convert.ToString(intLives);

                        // reset player location
                        PIC_Player.Location = new Point(22, 425);

                        isObtained = false;

                        // if achievement trophy 2 was not obtained before
                        if (A2_Obtained == false)
                        {
                            AchievementTwo_Obtained = false;
                        }

                        // otherwise, it was obtained in past
                        else
                        {
                            AchievementTwo_Obtained = true;
                        }

                        // creating a key
                        PictureBox pic_Key = new PictureBox();
                        Controls.Add(pic_Key);
                        pic_Key.Image = Resources.A_Key;
                        pic_Key.BackColor = Color.Transparent;
                        pic_Key.SizeMode = PictureBoxSizeMode.StretchImage;
                        pic_Key.Size = new Size(50, 30);
                        pic_Key.Location = new Point(750, 420);
                        pic_Key.BringToFront();
                        pic_Key.Tag = CodedObjects.Tag_Key;

                    }

                    // otherwise, lose
                    else
                    {
                        lbl_Lives.Text = "0";
                        LoseScenario();

                    }
                }
            }

            // [LEVEL TWO]
            else if (isLevel == 2)
            {
                // move the enemy
                pbEtagged.Left += Xvel_enemy;

                // if the enemy touches its left platform edge
                if (pbEtagged.Left < 140)
                {
                    Xvel_enemy = -Xvel_enemy;
                    pbEtagged.Image = Resources.EnemyMONSTER_org;
                }

                // if the enemy touches its left platform edge
                if (pbEtagged.Right > 290)
                {
                    Xvel_enemy = -Xvel_enemy;
                    pbEtagged.Image = Resources.EnemyMONSTER_reverse;
                }

                // if enemy touches the player
                if (pbEtagged.Bounds.IntersectsWith(PIC_Player.Bounds))
                {

                    // if there is life left
                    if (intLives > 1)
                    {
                        // deduct one life value from the player's total
                        intLives -= 1;
                        lbl_Lives.Text = Convert.ToString(intLives);
                        livelost = true;

                        // reset player location
                        PIC_Player.Location = new Point(22, 425);

                        isObtained = false;

                        // if achievement trophy 2 was not obtained before
                        if (A2_Obtained == false)
                        {
                            AchievementTwo_Obtained = false;
                        }

                        // otherwise, it was obtained in past
                        else
                        {
                            AchievementTwo_Obtained = true;
                        }

                        // creating a key
                        PictureBox pic_Key = new PictureBox();
                        Controls.Add(pic_Key);
                        pic_Key.Image = Resources.A_Key;
                        pic_Key.BackColor = Color.Transparent;
                        pic_Key.SizeMode = PictureBoxSizeMode.StretchImage;
                        pic_Key.Size = new Size(50, 30);
                        pic_Key.Location = new Point(750, 440);
                        pic_Key.BringToFront();
                        pic_Key.Tag = CodedObjects.Tag_Key;

                        // create a achievement object to be obtained
                        PictureBox pbAchievement = new PictureBox();
                        Controls.Add(pbAchievement);
                        pbAchievement.Enabled = false;
                        pbAchievement.Visible = false;
                        pbAchievement.Image = Resources.Atrophy2;
                        pbAchievement.Location = new Point(0, 150);
                        pbAchievement.Size = new Size(40, 40);
                        pbAchievement.SizeMode = PictureBoxSizeMode.StretchImage;
                        pbAchievement.BringToFront();
                        pbAchievement.Tag = CodedObjects.Tag_Achievement;
                    }

                    // otherwise, lose
                    else
                    {
                        lbl_Lives.Text = "0";
                        LoseScenario();

                    }
                }
            }

            // [LEVEL THREE]
            else if (isLevel == 3)
            {
                // move the enemy
                pbEtagged.Left += Xvel_enemy;

                // if the enemy touches its left platform edge
                if (pbEtagged.Left < 370)
                {
                    Xvel_enemy = -Xvel_enemy;
                    pbEtagged.Image = Resources.EnemyMONSTER_org;
                }

                // if the enemy touches its left platform edge
                if (pbEtagged.Right > 480)
                {
                    Xvel_enemy = -Xvel_enemy;
                    pbEtagged.Image = Resources.EnemyMONSTER_reverse;
                }

                // if enemy touches the player
                if (pbEtagged.Bounds.IntersectsWith(PIC_Player.Bounds))
                {

                    AchievementObtained = false;

                    // if there is life left
                    if (intLives > 1)
                    {
                        // deduct one life value from the player's total
                        intLives -= 1;
                        lbl_Lives.Text = Convert.ToString(intLives);

                        // reset player location
                        PIC_Player.Location = new Point(22, 425);

                        isObtained = false;

                        // creating a key
                        PictureBox pic_Key = new PictureBox();
                        Controls.Add(pic_Key);
                        pic_Key.Image = Resources.A_Key;
                        pic_Key.BackColor = Color.Transparent;
                        pic_Key.SizeMode = PictureBoxSizeMode.StretchImage;
                        pic_Key.Size = new Size(50, 30);
                        pic_Key.Location = new Point(730, 350);
                        pic_Key.BringToFront();
                        pic_Key.Tag = CodedObjects.Tag_Key;

                    }

                    // otherwise, lose
                    else
                    {
                        lbl_Lives.Text = "0";
                        LoseScenario();

                    }
                }
            }

            // [LEVEL FOUR]
            else if (isLevel == 4)
            {
                // move the enemy
                pbEtagged.Left += Xvel_enemy;

                // if the enemy touches its left platform edge
                if (pbEtagged.Left < 100)
                {
                    Xvel_enemy = -Xvel_enemy;
                    pbEtagged.Image = Resources.EnemyMONSTER_org;
                }

                // if the enemy touches its left platform edge
                if (pbEtagged.Right > 200)
                {
                    Xvel_enemy = -Xvel_enemy;
                    pbEtagged.Image = Resources.EnemyMONSTER_reverse;
                }

                // if enemy touches the player
                if (pbEtagged.Bounds.IntersectsWith(PIC_Player.Bounds))
                {

                    //AchievementObtained = false;

                    // if there is life left
                    if (intLives > 1)
                    {
                        // deduct one life value from the player's total
                        intLives -= 1;
                        lbl_Lives.Text = Convert.ToString(intLives);

                        // reset player location
                        PIC_Player.Location = new Point(22, 425);

                        isObtained = false;

                        // creating a key
                        PictureBox pic_Key = new PictureBox();
                        Controls.Add(pic_Key);
                        pic_Key.Image = Resources.A_Key;
                        pic_Key.BackColor = Color.Transparent;
                        pic_Key.SizeMode = PictureBoxSizeMode.StretchImage;
                        pic_Key.Size = new Size(50, 30);
                        pic_Key.Location = new Point(730, 150);
                        pic_Key.BringToFront();
                        pic_Key.Tag = CodedObjects.Tag_Key;

                    }

                    // otherwise, lose
                    else
                    {
                        lbl_Lives.Text = "0";
                        LoseScenario();

                    }
                }
            }

            // [LEVEL FIVE] create a dynamic / smarter enemy
            else if (isLevel == 5)
            {

                // enemy vision / detect player
                if (PIC_Player.Top > 300 & PIC_Player.Left < 150)
                {
                    // if the player is more to the left than the enemy
                    // move enemy to the left
                    if (pbEtagged.Left > PIC_Player.Left)
                    {
                        pbEtagged.Left -= 1;
                        pbEtagged.Image = Resources.EnemyMONSTER2_reverse;
                    }

                    // otherwise, move enemy to the right
                    else
                    {
                        pbEtagged.Left += 1;
                        pbEtagged.Image = Resources.EnemyMonster2;
                    }

                    // do gravity for the enemy (avoid falling down if away from platform)
                    //pbEtagged.Top += Convert.ToInt32(yVel_Enemy);

                    if (pbEtagged.Right > 170)
                    {
                        pbEtagged.Left -= 1;
                    }
                }
                else
                {
                    // move the enemy
                    pbEtagged.Left += Xvel_enemy;

                    // enemy on a right edge of the platform
                    if (pbEtagged.Right > 170)
                    {
                        Xvel_enemy = -Xvel_enemy;
                        pbEtagged.Image = Resources.EnemyMONSTER2_reverse;
                    }

                    // enemy on a left edge of the platform
                    if (pbEtagged.Left < 1)
                    {
                        Xvel_enemy = -Xvel_enemy;
                        pbEtagged.Image = Resources.EnemyMonster2;
                    }
                }
                // run through the array
                for (iE = 0; iE < array_pbPlatforms.Length; iE++)
                {
                    // if array count reaches end of existing platforms, avoid error and stop the loop
                    if (array_pbPlatforms[iE] == null) { break; }

                    else
                    {
                        // if enemy intersects with a platform
                        //if (array_pbPlatforms[iE].Bounds.IntersectsWith(pbEtagged.Bounds))
                        //{
                        // set the position on a platform
                        //yVel_Enemy = 0;
                        //pbEtagged.Top = array_pbPlatforms[i].Top - pbEtagged.Height;
                        //}

                    }

                }

                // if enemy touches the player
                if (pbEtagged.Bounds.IntersectsWith(PIC_Player.Bounds))
                {

                    //AchievementObtained = false;

                    // if there is life left
                    if (intLives > 1)
                    {
                        // deduct one life value from the player's total
                        intLives -= 1;
                        lbl_Lives.Text = Convert.ToString(intLives);

                        // reset player location
                        PIC_Player.Location = new Point(22, 425);
                        // reset enemy location
                        pbEtagged.Location = new Point(140, 460);

                        isObtained = false;

                        // creating a key
                        PictureBox pic_Key = new PictureBox();
                        Controls.Add(pic_Key);
                        pic_Key.Image = Resources.A_Key;
                        pic_Key.BackColor = Color.Transparent;
                        pic_Key.SizeMode = PictureBoxSizeMode.StretchImage;
                        pic_Key.Size = new Size(50, 30);
                        pic_Key.Location = new Point(100, 60);
                        pic_Key.BringToFront();
                        pic_Key.Tag = CodedObjects.Tag_Key;

                    }

                    // otherwise, lose
                    else
                    {
                        lbl_Lives.Text = "0";
                        LoseScenario();

                    }
                }
            }

            // [LEVEL SIX] create a dynamic / smarter enemy
            else if (isLevel == 6)
            {

                // enemy vision / detect player
                if (PIC_Player.Top < 300 & PIC_Player.Left < 250)
                {
                    // if the player is more to the left than the enemy
                    // move enemy to the left
                    if (pbEtagged.Left > PIC_Player.Left)
                    {
                        pbEtagged.Left -= 1;
                        pbEtagged.Image = Resources.EnemyMONSTER2_reverse;
                    }

                    // otherwise, move enemy to the right
                    else
                    {
                        pbEtagged.Left += 1;
                        pbEtagged.Image = Resources.EnemyMonster2;
                    }

                    if (pbEtagged.Right > 170)
                    {
                        pbEtagged.Left -= 1;
                    }
                }
                else
                {
                    // move the enemy
                    pbEtagged.Left += Xvel_enemy;

                    // enemy on a right edge of the platform
                    if (pbEtagged.Right > 170)
                    {
                        Xvel_enemy = -Xvel_enemy;
                        pbEtagged.Image = Resources.EnemyMONSTER2_reverse;
                    }

                    // enemy on a left edge of the platform
                    if (pbEtagged.Left < 1)
                    {
                        Xvel_enemy = -Xvel_enemy;
                        pbEtagged.Image = Resources.EnemyMonster2;
                    }
                }

                // if enemy touches the player
                if (pbEtagged.Bounds.IntersectsWith(PIC_Player.Bounds))
                {

                    //AchievementObtained = false;

                    // if there is life left
                    if (intLives > 1)
                    {
                        // deduct one life value from the player's total
                        intLives -= 1;
                        lbl_Lives.Text = Convert.ToString(intLives);

                        // reset player location
                        PIC_Player.Location = new Point(22, 425);
                        // reset enemy location
                        pbEtagged.Location = new Point(1, 260);

                        isObtained = false;

                        // creating a key
                        PictureBox pic_Key = new PictureBox();
                        Controls.Add(pic_Key);
                        pic_Key.Image = Resources.A_Key;
                        pic_Key.BackColor = Color.Transparent;
                        pic_Key.SizeMode = PictureBoxSizeMode.StretchImage;
                        pic_Key.Size = new Size(50, 30);
                        pic_Key.Location = new Point(550, 200);
                        pic_Key.BringToFront();
                        pic_Key.Tag = CodedObjects.Tag_Key;

                    }

                    // otherwise, lose
                    else
                    {
                        lbl_Lives.Text = "0";
                        LoseScenario();

                    }
                }
            }

            // [LEVEL SEVEN] create a dynamic / smarter enemy
            else if (isLevel == 7)
            {

                // enemy vision / detect player
                if (PIC_Player.Top < 400 & PIC_Player.Left < 350)
                {
                    // if the player is more to the left than the enemy
                    // move enemy to the left
                    if (pbEtagged.Left > PIC_Player.Left)
                    {
                        pbEtagged.Left -= 1;
                        pbEtagged.Image = Resources.EnemyMONSTER2_reverse;
                    }

                    // otherwise, move enemy to the right
                    else
                    {
                        pbEtagged.Left += 1;
                        pbEtagged.Image = Resources.EnemyMonster2;
                    }

                    // enemy on a right edge of the platform
                    if (pbEtagged.Right > 320)
                    {
                        pbEtagged.Left -= 1;
                        pbEtagged.Image = Resources.EnemyMONSTER2_reverse;
                    }

                    // enemy on a left edge of the platform
                    if (pbEtagged.Left < 180)
                    {
                        pbEtagged.Left += 1;
                        pbEtagged.Image = Resources.EnemyMonster2;
                    }

                }
                else
                {
                    // move the enemy
                    pbEtagged.Left += Xvel_enemy;

                    // enemy on a right edge of the platform
                    if (pbEtagged.Right > 320)
                    {
                        Xvel_enemy = -Xvel_enemy;
                        pbEtagged.Image = Resources.EnemyMONSTER2_reverse;
                    }

                    // enemy on a left edge of the platform
                    if (pbEtagged.Left < 180)
                    {
                        Xvel_enemy = -Xvel_enemy;
                        pbEtagged.Image = Resources.EnemyMonster2;
                    }
                }

                // if enemy touches the player
                if (pbEtagged.Bounds.IntersectsWith(PIC_Player.Bounds))
                {

                    //AchievementObtained = false;

                    // if there is life left
                    if (intLives > 1)
                    {
                        // deduct one life value from the player's total
                        intLives -= 1;
                        lbl_Lives.Text = Convert.ToString(intLives);

                        // reset player location
                        PIC_Player.Location = new Point(22, 425);
                        // reset enemy location
                        pbEtagged.Location = new Point(200, 370);

                        isObtained = false;

                        // creating a key
                        PictureBox pic_Key = new PictureBox();
                        Controls.Add(pic_Key);
                        pic_Key.Image = Resources.A_Key;
                        pic_Key.BackColor = Color.Transparent;
                        pic_Key.SizeMode = PictureBoxSizeMode.StretchImage;
                        pic_Key.Size = new Size(50, 30);
                        pic_Key.Location = new Point(700, 150);
                        pic_Key.BringToFront();
                        pic_Key.Tag = CodedObjects.Tag_Key;

                    }

                    // otherwise, lose
                    else
                    {
                        lbl_Lives.Text = "0";
                        LoseScenario();

                    }
                }
            }

            // [LEVEL EIGHT]
            else if (isLevel == 8)
            {
                // move the enemy
                pbEtagged.Left += Xvel_enemy;

                // if the enemy touches its left platform edge
                if (pbEtagged.Left < 270)
                {
                    Xvel_enemy = -Xvel_enemy;
                    pbEtagged.Image = Resources.EnemyMONSTER_org;
                }

                // if the enemy touches its right platform edge
                if (pbEtagged.Right > 480)
                {
                    Xvel_enemy = -Xvel_enemy;
                    pbEtagged.Image = Resources.EnemyMONSTER_reverse;
                }

                // if enemy touches the player
                if (pbEtagged.Bounds.IntersectsWith(PIC_Player.Bounds))
                {

                    // if there is life left
                    if (intLives > 1)
                    {
                        // deduct one life value from the player's total
                        intLives -= 1;
                        lbl_Lives.Text = Convert.ToString(intLives);

                        // reset player location
                        PIC_Player.Location = new Point(22, 425);

                        isObtained = false;

                        // creating a key
                        PictureBox pic_Key = new PictureBox();
                        Controls.Add(pic_Key);
                        pic_Key.Image = Resources.A_Key;
                        pic_Key.BackColor = Color.Transparent;
                        pic_Key.SizeMode = PictureBoxSizeMode.StretchImage;
                        pic_Key.Size = new Size(50, 30);
                        pic_Key.Location = new Point(730, 160);
                        pic_Key.BringToFront();
                        pic_Key.Tag = CodedObjects.Tag_Key;

                    }

                    // otherwise, lose
                    else
                    {
                        lbl_Lives.Text = "0";
                        LoseScenario();

                    }
                }
            }


            // [LEVEL NINE] more dynamic/smarter enemy
            else if (isLevel == 9)
            {

                // if the player is more to the left than the enemy
                // move enemy to the left
                if (pbEtagged.Left > PIC_Player.Left)
                {
                    pbEtagged.Left -= 1;
                    pbEtagged.Image = Resources.EnemyMONSTER2_reverse;
                }

                // otherwise, move enemy to the right
                else
                {
                    pbEtagged.Left += 1;
                    pbEtagged.Image = Resources.EnemyMonster2;
                }

                // enemy on a right edge of the platform
                if (pbEtagged.Right > 600)
                {
                    pbEtagged.Left -= 1;
                    pbEtagged.Image = Resources.EnemyMONSTER2_reverse;
                }

                // enemy on a left edge of the platform
                if (pbEtagged.Left < 330)
                {
                    pbEtagged.Left += 1;
                    pbEtagged.Image = Resources.EnemyMonster2;
                }



                // if enemy touches the player
                if (pbEtagged.Bounds.IntersectsWith(PIC_Player.Bounds))
                {

                    //AchievementObtained = false;

                    // if there is life left
                    if (intLives > 1)
                    {
                        // deduct one life value from the player's total
                        intLives -= 1;
                        lbl_Lives.Text = Convert.ToString(intLives);

                        // reset player location
                        PIC_Player.Location = new Point(22, 425);
                        // reset enemy location
                        pbEtagged.Location = new Point(340, 310);

                        isObtained = false;

                        // creating a key
                        PictureBox pic_Key = new PictureBox();
                        Controls.Add(pic_Key);
                        pic_Key.Image = Resources.A_Key;
                        pic_Key.BackColor = Color.Transparent;
                        pic_Key.SizeMode = PictureBoxSizeMode.StretchImage;
                        pic_Key.Size = new Size(50, 30);
                        pic_Key.Location = new Point(400, 100);
                        pic_Key.BringToFront();
                        pic_Key.Tag = CodedObjects.Tag_Key;

                    }

                    // otherwise, lose
                    else
                    {
                        lbl_Lives.Text = "0";
                        LoseScenario();

                    }
                }
            }

            else if (isLevel == 13)
            {
                //AchievementObtained = false;

                // move the enemy
                pbEtagged.Left += Xvel_enemy;

                // if the enemy touches its left platform edge
                if (pbEtagged.Left < 99)
                {
                    Xvel_enemy = -Xvel_enemy;
                    pbEtagged.Image = Resources.EnemyMONSTER3;
                }

                // if the enemy touches its right platform edge
                if (pbEtagged.Right > 190)
                {
                    Xvel_enemy = -Xvel_enemy;
                    pbEtagged.Image = Resources.EnemyMONSTER3_reverse;
                }

                // if enemy touches the player
                if (pbEtagged.Bounds.IntersectsWith(PIC_Player.Bounds))
                {
                    // make the player bounce off
                    PIC_Player.Left = PIC_Player.Left * -2;
                    PIC_Player.Left -= Convert.ToInt32(xVel) - 2;
                }

            }
        }

        int iE2;
        private void EnemyAI2(int isLevel, PictureBox pbE2tagged)
        {
            if (isLevel == 1)
            {
                // move the enemy
                pbE2tagged.Left += Xvel_enemy2;

                // if the enemy touches its left platform edge
                if (pbE2tagged.Left < 600)
                {
                    Xvel_enemy2 = -Xvel_enemy2;
                    pbE2tagged.Image = Resources.EnemyMONSTER_org;
                }

                // if the enemy touches its right platform edge
                if (pbE2tagged.Left > 670)
                {
                    Xvel_enemy2 = -Xvel_enemy2;
                    pbE2tagged.Image = Resources.EnemyMONSTER_reverse;
                }

                // if enemy touches the player
                if (pbE2tagged.Bounds.IntersectsWith(PIC_Player.Bounds))
                {

                    // if there is life left
                    if (intLives > 1)
                    {
                        // deduct one life value from the player's total
                        intLives -= 1;
                        lbl_Lives.Text = Convert.ToString(intLives);

                        // reset player location
                        PIC_Player.Location = new Point(22, 425);

                        isObtained = false;

                        // creating a key
                        PictureBox pic_Key = new PictureBox();
                        Controls.Add(pic_Key);
                        pic_Key.Image = Resources.A_Key;
                        pic_Key.BackColor = Color.Transparent;
                        pic_Key.SizeMode = PictureBoxSizeMode.StretchImage;
                        pic_Key.Size = new Size(50, 30);
                        pic_Key.Location = new Point(750, 420);
                        pic_Key.BringToFront();
                        pic_Key.Tag = CodedObjects.Tag_Key;

                    }

                    // otherwise, lose
                    else
                    {
                        lbl_Lives.Text = "0";
                        LoseScenario();

                    }
                }
            }

            else if (isLevel == 2)
            {
                // start off facing left (avoid perfectionism-like bug)
                pbE2tagged.Image = Resources.EnemyMONSTER_reverse;

                // move the enemy
                pbE2tagged.Left += Xvel_enemy2;

                // if the enemy touches its left platform edge
                if (pbE2tagged.Left < 620)
                {
                    Xvel_enemy2 = -Xvel_enemy2;
                    pbE2tagged.Image = Resources.EnemyMONSTER_org;
                }

                // if the enemy touches its right platform edge
                if (pbE2tagged.Right > 810)
                {
                    Xvel_enemy2 = -Xvel_enemy2;
                    pbE2tagged.Image = Resources.EnemyMONSTER_reverse;
                }

                // if enemy touches the player
                if (pbE2tagged.Bounds.IntersectsWith(PIC_Player.Bounds))
                {
                    AchievementObtained = false;

                    // if there is life left
                    if (intLives > 1)
                    {
                        // deduct one life value from the player's total
                        intLives -= 1;
                        lbl_Lives.Text = Convert.ToString(intLives);
                        livelost = true;

                        // reset player location
                        PIC_Player.Location = new Point(22, 425);

                        isObtained = false;

                        // if achievement trophy 2 was not obtained before
                        if (A2_Obtained == false)
                        {
                            AchievementTwo_Obtained = false;
                        }

                        // otherwise, it was obtained in past
                        else
                        {
                            AchievementTwo_Obtained = true;
                        }

                        // creating a key
                        PictureBox pic_Key = new PictureBox();
                        Controls.Add(pic_Key);
                        pic_Key.Image = Resources.A_Key;
                        pic_Key.BackColor = Color.Transparent;
                        pic_Key.SizeMode = PictureBoxSizeMode.StretchImage;
                        pic_Key.Size = new Size(50, 30);
                        pic_Key.Location = new Point(750, 440);
                        pic_Key.BringToFront();
                        pic_Key.Tag = CodedObjects.Tag_Key;

                        // create a achievement object to be obtained
                        PictureBox pbAchievement = new PictureBox();
                        Controls.Add(pbAchievement);
                        pbAchievement.Enabled = false;
                        pbAchievement.Visible = false;
                        pbAchievement.Image = Resources.Atrophy2;
                        pbAchievement.Location = new Point(0, 150);
                        pbAchievement.Size = new Size(40, 40);
                        pbAchievement.SizeMode = PictureBoxSizeMode.StretchImage;
                        pbAchievement.BringToFront();
                        pbAchievement.Tag = CodedObjects.Tag_Achievement;
                    }

                    // otherwise, lose
                    else
                    {
                        lbl_Lives.Text = "0";
                        LoseScenario();

                    }
                }
                
            }

            else if (isLevel == 3)
            {
                //AchievementObtained = false;

                // move the enemy
                pbE2tagged.Left += Xvel_enemy2;

                // if the enemy touches its left platform edge
                if (pbE2tagged.Left < 360)
                {
                    Xvel_enemy2 = -Xvel_enemy2;
                    pbE2tagged.Image = Resources.EnemyMONSTER_org;
                }

                // if the enemy touches its right platform edge
                if (pbE2tagged.Right > 510)
                {
                    Xvel_enemy2 = -Xvel_enemy2;
                    pbE2tagged.Image = Resources.EnemyMONSTER_reverse;
                }

                // if enemy touches the player
                if (pbE2tagged.Bounds.IntersectsWith(PIC_Player.Bounds))
                {

                    // if there is life left
                    if (intLives > 1)
                    {
                        // deduct one life value from the player's total
                        intLives -= 1;
                        lbl_Lives.Text = Convert.ToString(intLives);

                        // reset player location
                        PIC_Player.Location = new Point(22, 425);

                        isObtained = false;

                        // creating a key
                        PictureBox pic_Key = new PictureBox();
                        Controls.Add(pic_Key);
                        pic_Key.Image = Resources.A_Key;
                        pic_Key.BackColor = Color.Transparent;
                        pic_Key.SizeMode = PictureBoxSizeMode.StretchImage;
                        pic_Key.Size = new Size(50, 30);
                        pic_Key.Location = new Point(730, 350);
                        pic_Key.BringToFront();
                        pic_Key.Tag = CodedObjects.Tag_Key;

                    }

                    // otherwise, lose
                    else
                    {
                        lbl_Lives.Text = "0";
                        LoseScenario();

                    }
                }

            }

            // [LEVEL FIVE] create a dynamic / smarter enemy
            else if (isLevel == 5)
            {

                // enemy vision / detect the player
                if (PIC_Player.Top < 200 & PIC_Player.Left < 300) 
                {
                    // if the player is more to the left than the enemy
                    // move enemy to the left
                    if (pbE2tagged.Left > PIC_Player.Left)
                    {
                        pbE2tagged.Left -= 1;
                        pbE2tagged.Image = Resources.EnemyMONSTER2_reverse;
                    }

                    // otherwise, move enemy to the right
                    else
                    {
                        pbE2tagged.Left += 1;
                        pbE2tagged.Image = Resources.EnemyMonster2;
                    }

                    // enemy on a right edge of the platform
                    if (pbE2tagged.Right > 310)
                    {
                        pbE2tagged.Left -= 1;
                    }

                    // enemy on a left edge of the platform
                    if (pbE2tagged.Right < 200)
                    {
                        pbE2tagged.Left += 1;
                    }

                }
                else
                {
                    pbE2tagged.Left += Xvel_enemy2;
                    // move the enemy

                    // enemy on a right edge of the platform
                    if (pbE2tagged.Right > 310)
                    {
                        Xvel_enemy2 = -Xvel_enemy2;
                    }

                    // enemy on a left edge of the platform
                    if (pbE2tagged.Right < 200)
                    {
                        Xvel_enemy2 = -Xvel_enemy2;
                    }
                }

                // do gravity for the enemy (avoid falling down if away from platform)
                //pbE2tagged.Top += Convert.ToInt32(yVel_Enemy2);

                // run through the array
                for (iE2 = 0; iE2 < array_pbPlatforms.Length; iE2++)
                {
                    // if array count reaches end of existing platforms, avoid error and stop the loop
                    if (array_pbPlatforms[iE2] == null) { break; }

                    else
                    {
                        // if enemy intersects with a platform
                        if (array_pbPlatforms[iE2].Bounds.IntersectsWith(pbE2tagged.Bounds))
                        {
                            // set the position on a platform
                            //yVel_Enemy2 = 0;
                            pbE2tagged.Top = array_pbPlatforms[iE2].Top - pbE2tagged.Height;
                        }

                    }

                }

                // if enemy touches the player
                if (pbE2tagged.Bounds.IntersectsWith(PIC_Player.Bounds))
                {

                    //AchievementObtained = false;

                    // if there is life left
                    if (intLives > 1)
                    {
                        // deduct one life value from the player's total
                        intLives -= 1;
                        lbl_Lives.Text = Convert.ToString(intLives);

                        // reset player location
                        PIC_Player.Location = new Point(22, 425);
                        // reset enemy location
                        pbE2tagged.Location = new Point(200, 180);

                        isObtained = false;

                        // creating a key
                        PictureBox pic_Key = new PictureBox();
                        Controls.Add(pic_Key);
                        pic_Key.Image = Resources.A_Key;
                        pic_Key.BackColor = Color.Transparent;
                        pic_Key.SizeMode = PictureBoxSizeMode.StretchImage;
                        pic_Key.Size = new Size(50, 30);
                        pic_Key.Location = new Point(100, 60);
                        pic_Key.BringToFront();
                        pic_Key.Tag = CodedObjects.Tag_Key;

                    }

                    // otherwise, lose
                    else
                    {
                        lbl_Lives.Text = "0";
                        LoseScenario();

                    }
                }
            }
            
            // [LEVEL EIGHT] create a dynamic / smarter enemy
            else if (isLevel == 8)
            {

                // enemy vision / detect the player
                if (PIC_Player.Top < 200 & PIC_Player.Left < 500) 
                {
                    // if the player is more to the left than the enemy
                    // move enemy to the left
                    if (pbE2tagged.Left > PIC_Player.Left)
                    {
                        pbE2tagged.Left -= 1;
                        pbE2tagged.Image = Resources.EnemyMONSTER2_reverse;
                    }

                    // otherwise, move enemy to the right
                    else
                    {
                        pbE2tagged.Left += 1;
                        pbE2tagged.Image = Resources.EnemyMonster2;
                    }

                    // enemy on a right edge of the platform
                    if (pbE2tagged.Right > 480)
                    {
                        pbE2tagged.Left -= 1;
                    }

                    // enemy on a left edge of the platform
                    if (pbE2tagged.Right < 300)
                    {
                        pbE2tagged.Left += 1;
                    }

                }
                else
                {
                    // move the enemy
                    pbE2tagged.Left += Xvel_enemy2;

                    // enemy on a right edge of the platform
                    if (pbE2tagged.Right > 480)
                    {
                        Xvel_enemy2 = -Xvel_enemy2;
                    }

                    // enemy on a left edge of the platform
                    if (pbE2tagged.Right < 300)
                    {
                        Xvel_enemy2 = -Xvel_enemy2;
                    }
                }

                // do gravity for the enemy (avoid falling down if away from platform)
                //pbE2tagged.Top += Convert.ToInt32(yVel_Enemy2);

                // run through the platform array
                //for (iE2 = 0; iE2 < array_pbPlatforms.Length; iE2++)
                //{
                    // if array count reaches end of existing platforms, avoid error and stop the loop
                    //if (array_pbPlatforms[iE2] == null) { break; }

                    //else
                    //{
                        // if enemy intersects with a platform
                        //if (array_pbPlatforms[iE2].Bounds.IntersectsWith(pbE2tagged.Bounds))
                        //{
                            // set the position on a platform
                            //yVel_Enemy2 = 0;
                            //pbE2tagged.Top = array_pbPlatforms[iE2].Top - pbE2tagged.Height;
                        //}

                    //}

                //}

                // if enemy touches the player
                if (pbE2tagged.Bounds.IntersectsWith(PIC_Player.Bounds))
                {

                    //AchievementObtained = false;

                    // if there is life left
                    if (intLives > 1)
                    {
                        // deduct one life value from the player's total
                        intLives -= 1;
                        lbl_Lives.Text = Convert.ToString(intLives);

                        // reset player location
                        PIC_Player.Location = new Point(22, 425);
                        // reset enemy location
                        pbE2tagged.Location = new Point(270, 120);

                        isObtained = false;

                        // creating a key
                        PictureBox pic_Key = new PictureBox();
                        Controls.Add(pic_Key);
                        pic_Key.Image = Resources.A_Key;
                        pic_Key.BackColor = Color.Transparent;
                        pic_Key.SizeMode = PictureBoxSizeMode.StretchImage;
                        pic_Key.Size = new Size(50, 30);
                        pic_Key.Location = new Point(730, 160);
                        pic_Key.BringToFront();
                        pic_Key.Tag = CodedObjects.Tag_Key;

                    }

                    // otherwise, lose
                    else
                    {
                        lbl_Lives.Text = "0";
                        LoseScenario();

                    }
                }
            }

            // level 9 (bouncy enemy)
            else if (isLevel == 9)
            {
                //AchievementObtained = false;

                // move the enemy
                pbE2tagged.Left += Xvel_enemy2;

                // if the enemy touches its left platform edge
                if (pbE2tagged.Left < 10)
                {
                    Xvel_enemy2 = -Xvel_enemy2;
                    pbE2tagged.Image = Resources.EnemyMONSTER3;
                }

                // if the enemy touches its right platform edge
                if (pbE2tagged.Right > 110)
                {
                    Xvel_enemy2 = -Xvel_enemy2;
                    pbE2tagged.Image = Resources.EnemyMONSTER3_reverse;
                }

                // if enemy touches the player
                if (pbE2tagged.Bounds.IntersectsWith(PIC_Player.Bounds))
                {
                    // make the player bounce off
                    PIC_Player.Left = PIC_Player.Left * 2;
                    PIC_Player.Left += Convert.ToInt32(xVel) + 2;
                }

            }

            else if (isLevel == 13)
            {
                //AchievementObtained = false;

                // move the enemy
                pbE2tagged.Left += Xvel_enemy2;

                // if the enemy touches its left platform edge
                if (pbE2tagged.Left < 200)
                {
                    Xvel_enemy2 = -Xvel_enemy2;
                    pbE2tagged.Image = Resources.EnemyMONSTER3;
                }

                // if the enemy touches its right platform edge
                if (pbE2tagged.Right > 400)
                {
                    Xvel_enemy2 = -Xvel_enemy2;
                    pbE2tagged.Image = Resources.EnemyMONSTER3_reverse;
                }

                // if enemy touches the player
                if (pbE2tagged.Bounds.IntersectsWith(PIC_Player.Bounds))
                {
                    // make the player bounce off
                    PIC_Player.Left = PIC_Player.Left * -2;
                    PIC_Player.Left -= Convert.ToInt32(xVel) - 2;
                }

            }
        }

        // third enemy unit
        private void EnemyAI3(int isLevel, PictureBox pbE3tagged)
        {
            if (isLevel == 2)
            {
                // move the enemy
                pbE3tagged.Left += Xvel_enemy3;

                // if the enemy touches its left platform edge
                if (pbE3tagged.Left < 120)
                {
                    Xvel_enemy3 = -Xvel_enemy3;
                    pbE3tagged.Image = Resources.EnemyMONSTER_org;
                }

                // if the enemy touches its right platform edge
                if (pbE3tagged.Right > 230)
                {
                    Xvel_enemy3 = -Xvel_enemy3;
                    pbE3tagged.Image = Resources.EnemyMONSTER_reverse;
                }

                // if enemy touches the player
                if (pbE3tagged.Bounds.IntersectsWith(PIC_Player.Bounds))
                {

                    // if there is life left
                    if (intLives > 1)
                    {
                        // deduct one life value from the player's total
                        intLives -= 1;
                        lbl_Lives.Text = Convert.ToString(intLives);

                        // reset player location
                        PIC_Player.Location = new Point(22, 425);

                        isObtained = false;

                        // if achievement trophy 2 was not obtained before
                        if (A2_Obtained == false)
                        {
                            AchievementTwo_Obtained = false;
                        }

                        // otherwise, it was obtained in past
                        else
                        {
                            AchievementTwo_Obtained = true;
                        }

                        // creating a key
                        PictureBox pic_Key = new PictureBox();
                        Controls.Add(pic_Key);
                        pic_Key.Image = Resources.A_Key;
                        pic_Key.BackColor = Color.Transparent;
                        pic_Key.SizeMode = PictureBoxSizeMode.StretchImage;
                        pic_Key.Size = new Size(50, 30);
                        pic_Key.Location = new Point(750, 440);
                        pic_Key.BringToFront();
                        pic_Key.Tag = CodedObjects.Tag_Key;

                        // create a achievement object to be obtained
                        PictureBox pbAchievement = new PictureBox();
                        Controls.Add(pbAchievement);
                        pbAchievement.Enabled = false;
                        pbAchievement.Visible = false;
                        pbAchievement.Image = Resources.Atrophy2;
                        pbAchievement.Location = new Point(0, 150);
                        pbAchievement.Size = new Size(40, 40);
                        pbAchievement.SizeMode = PictureBoxSizeMode.StretchImage;
                        pbAchievement.BringToFront();
                        pbAchievement.Tag = CodedObjects.Tag_Achievement;
                    }

                    // otherwise, lose
                    else
                    {
                        lbl_Lives.Text = "0";
                        LoseScenario();

                    }
                }
            }

            // level 3 (bonus)
            else if (isLevel == 13)
            {
                //AchievementObtained = false;

                // move the enemy
                pbE3tagged.Left += Xvel_enemy3;

                // if the enemy touches its left platform edge
                if (pbE3tagged.Left < 500)
                {
                    Xvel_enemy3 = -Xvel_enemy3;
                    pbE3tagged.Image = Resources.EnemyMONSTER3;
                }

                // if the enemy touches its right platform edge
                if (pbE3tagged.Right > 600)
                {
                    Xvel_enemy3 = -Xvel_enemy3;
                    pbE3tagged.Image = Resources.EnemyMONSTER3_reverse;
                }

                // if enemy touches the player
                if (pbE3tagged.Bounds.IntersectsWith(PIC_Player.Bounds))
                {
                    // make the player bounce off
                    PIC_Player.Left = PIC_Player.Left * -2;
                    PIC_Player.Left -= Convert.ToInt32(xVel) - 2;
                }

            }
        }
        
        // fourth enemy unit
        private void EnemyAI4(int isLevel, PictureBox pbE4tagged)
        {
            if (isLevel == 2)
            {
                // move the enemy
                pbE4tagged.Left += Xvel_enemy4;

                // if the enemy touches its left platform edge
                if (pbE4tagged.Left < 0)
                {
                    Xvel_enemy4 = -Xvel_enemy4;
                    pbE4tagged.Image = Resources.EnemyMONSTER_org;
                }

                // if the enemy touches its right platform edge
                if (pbE4tagged.Right > 90)
                {
                    Xvel_enemy4 = -Xvel_enemy4;
                    pbE4tagged.Image = Resources.EnemyMONSTER_reverse;
                }

                // if enemy touches the player
                if (pbE4tagged.Bounds.IntersectsWith(PIC_Player.Bounds))
                {

                    // if there is life left
                    if (intLives > 1)
                    {
                        // deduct one life value from the player's total
                        intLives -= 1;
                        lbl_Lives.Text = Convert.ToString(intLives);

                        // reset player location
                        PIC_Player.Location = new Point(22, 425);

                        isObtained = false;

                        // if achievement trophy 2 was not obtained before
                        if (A2_Obtained == false)
                        {
                            AchievementTwo_Obtained = false;
                        }

                        // otherwise, it was obtained in past
                        else
                        {
                            AchievementTwo_Obtained = true;
                        }

                        // creating a key
                        PictureBox pic_Key = new PictureBox();
                        Controls.Add(pic_Key);
                        pic_Key.Image = Resources.A_Key;
                        pic_Key.BackColor = Color.Transparent;
                        pic_Key.SizeMode = PictureBoxSizeMode.StretchImage;
                        pic_Key.Size = new Size(50, 30);
                        pic_Key.Location = new Point(750, 440);
                        pic_Key.BringToFront();
                        pic_Key.Tag = CodedObjects.Tag_Key;

                        // create a achievement object to be obtained
                        PictureBox pbAchievement = new PictureBox();
                        Controls.Add(pbAchievement);
                        pbAchievement.Enabled = false;
                        pbAchievement.Visible = false;
                        pbAchievement.Image = Resources.Atrophy2;
                        pbAchievement.Location = new Point(0, 150);
                        pbAchievement.Size = new Size(40, 40);
                        pbAchievement.SizeMode = PictureBoxSizeMode.StretchImage;
                        pbAchievement.BringToFront();
                        pbAchievement.Tag = CodedObjects.Tag_Achievement;
                    }

                    // otherwise, lose
                    else
                    {
                        lbl_Lives.Text = "0";
                        LoseScenario();

                    }
                }
            }

            else if (isLevel == 13)
            {
                //AchievementObtained = false;

                // move the enemy
                pbE4tagged.Left += Xvel_enemy4;

                // if the enemy touches its left platform edge
                if (pbE4tagged.Left < 650)
                {
                    Xvel_enemy4 = -Xvel_enemy4;
                    pbE4tagged.Image = Resources.EnemyMONSTER3;
                }

                // if the enemy touches its right platform edge
                if (pbE4tagged.Right > 750)
                {
                    Xvel_enemy4 = -Xvel_enemy4;
                    pbE4tagged.Image = Resources.EnemyMONSTER3_reverse;
                }

                // if enemy touches the player
                if (pbE4tagged.Bounds.IntersectsWith(PIC_Player.Bounds))
                {
                    // make the player bounce off
                    PIC_Player.Left = PIC_Player.Left * -2;
                    PIC_Player.Left -= Convert.ToInt32(xVel) - 2;
                }

            }
        }

        private void LoseScenario()
        {
            // stop game loop
            FPS_Timer.Stop();

            // notify to player about lose, provide with restart choice
            DialogResult gameover = MessageBox.Show("Game over, Restart?", "Game Over!", MessageBoxButtons.YesNo);
            switch (gameover)
            {
                // restart the level
                case DialogResult.Yes:
                    RestartLevel(isLevel, 0);
                    break;

                // close game form, open main menu
                case DialogResult.No:
                    this.Close();
                    break;
            }
        }

        // loop through controls to find specific object registered within the code, not in design
        private void controlLoop()
        {
            
            // for each assigned control of all controls
            foreach (Control ctrl in this.Controls)
            {
                // find 'picturebox' controls
                if (ctrl is PictureBox)
                {
                    // detect which one is which
                    switch (ctrl.Tag)
                    {
                        // Enemy
                        case CodedObjects.Tag_Enemy:
                            PictureBox pbEtagged = (PictureBox)ctrl;
                            EnemyAI(isLevel, pbEtagged);
                            break;

                        // Enemy 2
                        case CodedObjects.Tag_Enemy2:
                            PictureBox pbE2Tagged = (PictureBox)ctrl;
                            EnemyAI2(isLevel, pbE2Tagged);
                            break;
                            
                        // Enemy 3
                        case CodedObjects.Tag_Enemy3:
                            PictureBox pbE3tagged = (PictureBox)ctrl;
                            EnemyAI3(isLevel, pbE3tagged);
                            break;

                        // Enemy 4
                        case CodedObjects.Tag_Enemy4:
                            PictureBox pbE4Tagged = (PictureBox)ctrl;
                            EnemyAI4(isLevel, pbE4Tagged);
                            break;

                        // Ladder
                        case CodedObjects.Tag_Ladder:
                            PictureBox pbLtagged = (PictureBox)ctrl;
                            PlayerWithLadder(pbLtagged);
                            break;

                        // Key
                        case (CodedObjects.Tag_Key):
                            PictureBox pbKtagged = (PictureBox)ctrl;
                            PlayerKeyCollision(pbKtagged);
                            break;

                        // Exit door
                        case CodedObjects.Tag_Exit:
                            PictureBox pbExtagged = (PictureBox)ctrl;
                            InteractionDetection(isLevel, pbExtagged);
                            break;

                        // Shop
                        case CodedObjects.Tag_Shop:
                            PictureBox pbStagged = (PictureBox)ctrl;
                            InteractionDetection(isLevel, pbStagged);
                            break;
                            
                        // Coin
                        case CodedObjects.Tag_Coin:
                            PictureBox pbCtagged = (PictureBox)ctrl;
                            CoinInteraction(isLevel, pbCtagged);
                            break;

                        // Achievement
                        case CodedObjects.Tag_Achievement:
                            PictureBox pbAchievement_tagged = (PictureBox)ctrl;
                            Achievement(isLevel, pbAchievement_tagged);
                            break;

                        // Achievement platform
                        case CodedObjects.Tag_AchPlat:
                            PictureBox pbAchPlat_tagged = (PictureBox)ctrl;
                            AchievementPlatformControl(isLevel, pbAchPlat_tagged);
                            break;

                        // floating platform (X)
                        case CodedObjects.Tag_MovePlat:
                            PictureBox pbFloated_tagged = (PictureBox)ctrl;
                            MovePlatform(isLevel, pbFloated_tagged);
                            break;
                            
                        // floating platform 2 (X)
                        case CodedObjects.Tag_MovePlat2:
                            PictureBox pbFloated2_tagged = (PictureBox)ctrl;
                            MovePlatform(isLevel, pbFloated2_tagged);
                            break;
                            
                        // floating platform 3 (Y)
                        case CodedObjects.Tag_MovePlat3:
                            PictureBox pbFloated3_tagged = (PictureBox)ctrl;
                            MovePlatform(isLevel, pbFloated3_tagged);
                            break;
                        
                        // floating platform 4 (Y)
                        case CodedObjects.Tag_MovePlat4:
                            PictureBox pbFloated4_tagged = (PictureBox)ctrl;
                            MovePlatform(isLevel, pbFloated4_tagged);
                            break;
                            
                        // floating platform 5 (Y)
                        case CodedObjects.Tag_MovePlat5:
                            PictureBox pbFloated5_tagged = (PictureBox)ctrl;
                            MovePlatform(isLevel, pbFloated5_tagged);
                            break;
                            
                        // floating platform 6 (Y)
                        case CodedObjects.Tag_MovePlat6:
                            PictureBox pbFloated6_tagged = (PictureBox)ctrl;
                            MovePlatform(isLevel, pbFloated6_tagged);
                            break;

                    }
                }
                else if (ctrl is Label)
                {
                    switch (ctrl.Tag)
                    {
                        case CodedObjects.Tag_KeyText:
                            Label lbl_KeyText = (Label)ctrl;
                            KeyLabel(lbl_KeyText);
                            break;
                    }
                }

            }
        }

        private void KeyLabel(Label lbl_KeyText)
        {
            if (isObtained)
            {
                lbl_KeyText.Visible = true;
            }
            else
            {
                lbl_KeyText.Visible = false;
            }
        }

        // control player movements
        private void MovePlayer()
        {
            // if the left movement key is pressed
            if (blnKeyLeft)
            {
                PIC_Player.Image = Properties.Resources.RallyTheBoy__Reversed;
                PIC_Player.Left -= 5;
            }

            // if the right movement key is pressed
            if (blnKeyRight)
            {
                PIC_Player.Image = Properties.Resources.RallyTheBoy;
                PIC_Player.Left += 5;
            }

            // if the jump key is pressed whilst on a platform
            if (blnKeyUp && blnOnPlatform && !blnOnLadder)
            {
                yVel -= 12;
            }

            // add y coordinates for the player
            PIC_Player.Top += Convert.ToInt32(yVel);

        }



        // gravity
        private void DoGravity()
        {
            // player gravity
            yVel += 1;

            // enemy AI gravity
            yVel_Enemy += 1;
        }

        int i = 0;
        bool blnOnPlatform = false; // in the air
        // player - platform collision detection
        public void PlayerPlatformCollision()
        {
            //if (blnOnPlatform)
            //{
                blnOnPlatform = false; // in the air
            //}

            // run through the array
            for (i = 0; i < array_pbPlatforms.Length; i++)
            {
                // if array count reaches end of existing platforms, avoid error and stop the loop
                if (array_pbPlatforms[i] == null) { break; }

                else
                {
                    // if player touches any platform
                    if (array_pbPlatforms[i].Bounds.IntersectsWith(PIC_Player.Bounds))
                    {

                        // if the player hits the platform with head
                        if (yVel < 0)
                        {
                            yVel *= -1;
                        }

                        // otherwise, assume the player falling on to a platform and set his position on it
                        else
                        {
                            // stop falling and set the position on a platform
                            yVel = 0;
                            PIC_Player.Top = array_pbPlatforms[i].Top - PIC_Player.Height;
                            blnOnPlatform = true; // standing on platform
                            intPlayerJump = 0;
                        }

                    }

                }

            }
            
        }

        // if the user restarts the level
        public void RestartLevel(int intLevel, int oldtime)
        {
            // assign local level number as a global
            intLevel = isLevel;

            oldtime = VarTimeLoad;

            // create new instance of same form
            TheGame gameRestared = new TheGame();
            gameRestared.Show();

            // re-set coins
            gameRestared.intCoins = FormProvider.SML_Form.GlobalCoins;

            // pass the level into its method
            gameRestared.LevelDetermine(intLevel);

            // get rid of the old instance
            this.Dispose();
        }

        // player - walls collision
        private void PlayerPlatformWallsCollision()
        {
            // run through the array
            for (i = 0; i < array_pbPlatformWalls.Length; i++)
            {
                // if array count reaches end of existing platform walls, avoid error and stop the loop
                if (array_pbPlatformWalls[i] == null) { break; }

                else
                {
                    if (array_pbPlatformWalls[i].Bounds.IntersectsWith(PIC_Player.Bounds))
                    {
                        // if player touches any wall's right side
                        if (PIC_Player.Left <= array_pbPlatformWalls[i].Right)
                        {
                            // set the position
                            PIC_Player.Left = array_pbPlatformWalls[i].Right;

                        }
                    }
                }

            }
        }

        bool blnOnLadder;
        // if player touches ladder and user wants to climb it
        private void PlayerWithLadder(PictureBox pbLtagged)
        {
            blnOnLadder = false;

            if (pbLtagged.Bounds.IntersectsWith(PIC_Player.Bounds))
            {

                blnOnPlatform = true;
                yVel = 0;

                if (blnKeyUp)
                {
                    yVel -= 4;
                    blnOnLadder = true;
                }

                if (blnKeyDown)
                {
                    yVel += 4;
                    blnOnLadder = true;
                }

            }
        }

        private void MovePlatform(int isLevel, PictureBox pb_FloatingPlatform)
        {
            // decide which platform unit it is by its tag
            switch (pb_FloatingPlatform.Tag)
            {
                // floating platform 1 (X)
                case CodedObjects.Tag_MovePlat:
                    
                    // level 4
                    if (isLevel == 4)
                    {
                        // move the platform
                        pb_FloatingPlatform.Left += Xvel_platform;

                        // if the platform touches its left edge
                        if (pb_FloatingPlatform.Left < 400)
                        {
                            Xvel_platform = -Xvel_platform;
                        }
                        
                        // if the platform touches its right edge
                        if (pb_FloatingPlatform.Right > 600)
                        {
                            Xvel_platform = -Xvel_platform;
                        }
                    }

                    // level 6
                    if (isLevel == 6)
                    {
                        // move the platform
                        pb_FloatingPlatform.Left += Xvel_platform;

                        // if the platform touches its left edge
                        if (pb_FloatingPlatform.Left < 160)
                        {
                            Xvel_platform = -Xvel_platform;
                        }

                        // if the platform touches its right edge
                        if (pb_FloatingPlatform.Right > 600)
                        {
                            Xvel_platform = -Xvel_platform;
                        }
                    }

                    // level 7
                    if (isLevel == 7)
                    {
                        // move the platform
                        pb_FloatingPlatform.Left += Xvel_platform;

                        // if the platform touches its left edge
                        if (pb_FloatingPlatform.Left < 450)
                        {
                            Xvel_platform = -Xvel_platform;
                        }

                        // if the platform touches its right edge
                        if (pb_FloatingPlatform.Right > 600)
                        {
                            Xvel_platform = -Xvel_platform;
                        }
                    }

                    // level 8
                    if (isLevel == 8)
                    {
                        // move the platform
                        pb_FloatingPlatform.Left += Xvel_platform;

                        // if the platform touches its left edge
                        if (pb_FloatingPlatform.Left < 160)
                        {
                            Xvel_platform = -Xvel_platform;
                        }

                        // if the platform touches its right edge
                        if (pb_FloatingPlatform.Right > 600)
                        {
                            Xvel_platform = -Xvel_platform;
                        }
                    }
                    
                    // level 9
                    if (isLevel == 9)
                    {
                        // move the platform
                        pb_FloatingPlatform.Left += Xvel_platform;

                        // if the platform touches its left edge
                        if (pb_FloatingPlatform.Left < 260)
                        {
                            Xvel_platform = -Xvel_platform;
                        }

                        // if the platform touches its right edge
                        if (pb_FloatingPlatform.Right > 600)
                        {
                            Xvel_platform = -Xvel_platform;
                        }
                    }
                    
                    // level 10 (Y)
                    if (isLevel == 10)
                    {
                        // move the platform
                        pb_FloatingPlatform.Top += Yvel_platform;

                        if (livelost)
                        {
                            pb_FloatingPlatform.Location = new Point(10, 450);
                            livelost = false;
                        }

                        // if the platform reaches top edge
                        if (pb_FloatingPlatform.Top < 260)
                        {
                            Yvel_platform = -Yvel_platform;
                        }

                        // if the platform reaches bottom edge
                        if (pb_FloatingPlatform.Top > 450)
                        {
                            Yvel_platform = -Yvel_platform;
                        }
                    }
                    
                    // level 12 (Y)
                    if (isLevel == 12)
                    {
                        // move the platform
                        pb_FloatingPlatform.Top += Yvel_platform;

                        if (livelost)
                        {
                            pb_FloatingPlatform.Location = new Point(10, 450);
                            livelost = false;
                        }

                        // if the platform reaches top edge
                        if (pb_FloatingPlatform.Top < 350)
                        {
                            Yvel_platform = -Yvel_platform;
                        }

                        // if the platform reaches bottom edge
                        if (pb_FloatingPlatform.Top > 450)
                        {
                            Yvel_platform = -Yvel_platform;
                        }
                    }

                    break;
                
                // floating platform 2 (X)
                case CodedObjects.Tag_MovePlat2:
                    
                    // if level 4
                    if (isLevel == 4)
                    {
                        // move the platform
                        pb_FloatingPlatform.Left += Xvel_platform2;

                        // if the platform touches its left edge
                        if (pb_FloatingPlatform.Left < 360)
                        {
                            Xvel_platform2 = -Xvel_platform2;
                        }
                        
                        // if the platform touches its right edge
                        if (pb_FloatingPlatform.Right > 700)
                        {
                            Xvel_platform2 = -Xvel_platform2;
                        }

                        if (PIC_Player.Bounds.IntersectsWith(pb_FloatingPlatform.Bounds))
                        {

                        }
                    }

                    // level 9 (Y2)
                    if (isLevel == 9)
                    {
                        // move the platform
                        pb_FloatingPlatform.Top += Yvel_platform2;

                        if (pb_FloatingPlatform.Top < 200)
                        {
                            Yvel_platform2 = -Yvel_platform2;
                        }

                        if (pb_FloatingPlatform.Top > 400)
                        {
                            Yvel_platform2 = -Yvel_platform2;
                        }
                    }
                    
                    if (isLevel == 10)
                    {
                        // move the platform
                        pb_FloatingPlatform.Left += Xvel_platform;

                        if (pb_FloatingPlatform.Left < 200)
                        {
                            Xvel_platform = -Xvel_platform;
                        }

                        if (pb_FloatingPlatform.Left > 300)
                        {
                            Xvel_platform = -Xvel_platform;
                        }
                    }

                    // level 12 (Y)
                    if (isLevel == 12)
                    {
                        // move the platform
                        pb_FloatingPlatform.Top += Yvel_platform2;

                        // if the platform reaches top edge
                        if (pb_FloatingPlatform.Top < 200)
                        {
                            Yvel_platform2 = -Yvel_platform2;
                        }

                        // if the platform reaches bottom edge
                        if (pb_FloatingPlatform.Top > 350)
                        {
                            Yvel_platform2 = -Yvel_platform2;
                        }
                    }
                    break;

                // floating platform 3 (Y)
                case CodedObjects.Tag_MovePlat3:

                    if (isLevel == 5)
                    {
                        // move the platform
                        pb_FloatingPlatform.Top += Yvel_platform;

                        if (pb_FloatingPlatform.Top < 200)
                        {
                            Yvel_platform = -Yvel_platform;
                        }
                        
                        if (pb_FloatingPlatform.Top > 500)
                        {
                            Yvel_platform = -Yvel_platform;
                        }
                    }
                    
                    if (isLevel == 7)
                    {
                        // move the platform
                        pb_FloatingPlatform.Top += Yvel_platform;

                        if (pb_FloatingPlatform.Top < 200)
                        {
                            Yvel_platform = -Yvel_platform;
                        }
                        
                        if (pb_FloatingPlatform.Top > 500)
                        {
                            Yvel_platform = -Yvel_platform;
                        }
                    }
                    
                    if (isLevel == 8)
                    {
                        // move the platform
                        pb_FloatingPlatform.Top += Yvel_platform;

                        if (pb_FloatingPlatform.Top < 200)
                        {
                            Yvel_platform = -Yvel_platform;
                        }
                        
                        if (pb_FloatingPlatform.Top > 470)
                        {
                            Yvel_platform = -Yvel_platform;
                        }
                    }
                    
                    if (isLevel == 9)
                    {
                        // move the platform
                        pb_FloatingPlatform.Top += Yvel_platform;

                        if (pb_FloatingPlatform.Top < 200)
                        {
                            Yvel_platform = -Yvel_platform;
                        }
                        
                        if (pb_FloatingPlatform.Top > 400)
                        {
                            Yvel_platform = -Yvel_platform;
                        }
                    }

                    if (isLevel == 10)
                    {
                        // move the platform
                        pb_FloatingPlatform.Left += Xvel_platform2;

                        if (pb_FloatingPlatform.Left < 400)
                        {
                            Xvel_platform2 = -Xvel_platform2;
                        }

                        if (pb_FloatingPlatform.Left > 500)
                        {
                            Xvel_platform2 = -Xvel_platform2;
                        }
                    }
                    
                    if (isLevel == 12)
                    {
                        // move the platform
                        pb_FloatingPlatform.Left += Xvel_platform;

                        if (pb_FloatingPlatform.Left < 250)
                        {
                            Xvel_platform = -Xvel_platform;
                        }

                        if (pb_FloatingPlatform.Left > 400)
                        {
                            Xvel_platform = -Xvel_platform;
                        }
                    }

                    break;
                
                // floating platform 4 (Y)
                case CodedObjects.Tag_MovePlat4:
                    
                    // level 10 (Y4)
                    if (isLevel == 10)
                    {
                        // move the platform
                        pb_FloatingPlatform.Top += Yvel_platform3;

                        // if the platform reaches top edge
                        if (pb_FloatingPlatform.Top < 100)
                        {
                            Yvel_platform3 = -Yvel_platform3;
                        }

                        // if the platform reaches bottom edge
                        if (pb_FloatingPlatform.Top > 300)
                        {
                            Yvel_platform3 = -Yvel_platform3;
                        }
                    }

                    // level 12 (Y)
                    if (isLevel == 12)
                    {
                        // move the platform
                        pb_FloatingPlatform.Top += Yvel_platform3;

                        // if the platform reaches top edge
                        if (pb_FloatingPlatform.Top < 200)
                        {
                            Yvel_platform3 = -Yvel_platform3;
                        }

                        // if the platform reaches bottom edge
                        if (pb_FloatingPlatform.Top > 400)
                        {
                            Yvel_platform3 = -Yvel_platform3;
                        }
                    }
                    break;
                    
                // floating platform 5 (Y)
                case CodedObjects.Tag_MovePlat5:
                    
                    // level 10 (Y5)
                    if (isLevel == 10)
                    {
                        // move the platform
                        pb_FloatingPlatform.Top += Yvel_platform4;

                        // if the platform reaches top edge
                        if (pb_FloatingPlatform.Top < 360)
                        {
                            Yvel_platform4 = -Yvel_platform4;
                        }

                        // if the platform reaches bottom edge
                        if (pb_FloatingPlatform.Top > 470)
                        {
                            Yvel_platform4 = -Yvel_platform4;
                        }
                    }

                    // level 12 (Y)
                    if (isLevel == 12)
                    {
                        // move the platform
                        pb_FloatingPlatform.Top += Yvel_platform4;

                        // if the platform reaches top edge
                        if (pb_FloatingPlatform.Top < 230)
                        {
                            Yvel_platform4 = -Yvel_platform4;
                        }

                        // if the platform reaches bottom edge
                        if (pb_FloatingPlatform.Top > 450)
                        {
                            Yvel_platform4 = -Yvel_platform4;
                        }
                    }
                    break;

                // floating platform 6 (Y)
                case CodedObjects.Tag_MovePlat6:

                    // level 10 (Y)
                    if (isLevel == 10)
                    {
                        // move the platform
                        pb_FloatingPlatform.Top += Yvel_platform5;

                        // if the platform reaches top edge
                        if (pb_FloatingPlatform.Top < 250)
                        {
                            Yvel_platform5 = -Yvel_platform5;
                        }

                        // if the platform reaches bottom edge
                        if (pb_FloatingPlatform.Top > 450)
                        {
                            Yvel_platform5 = -Yvel_platform5;
                        }
                    }

                    break;

            }
        }

        bool isObtained = false;
        // if player touches the key
        private void PlayerKeyCollision(PictureBox pbKtagged)
        {
            if (pbKtagged.Bounds.IntersectsWith(PIC_Player.Bounds))
            {

                // key obtained
                pbKtagged.Visible = false;
                isObtained = true;

                pbKtagged.Dispose();


            }

        }

        // control achievement platforms throughout certain levels
        private void AchievementPlatformControl(int isLevel, PictureBox pbAchPlat_tagged)
        {
            // if it's a tutorial
            if (isLevel == 0)
            {
                // if achievement was obtained before
                if (AchievementOne_Obtained)
                {
                    // enable the platform an achievement is in
                    pbAchPlat_tagged.Enabled = true;
                    pbAchPlat_tagged.BackColor = Color.Lime;
                    array_pbPlatforms[10] = pbAchPlat_tagged;
                }

                // otherwise, if the key is obtained but no achievement
                else if (isObtained && !AchievementOne_Obtained)
                {
                    // enable the platform an achievement is in
                    pbAchPlat_tagged.Enabled = true;
                    pbAchPlat_tagged.BackColor = Color.Lime;
                    array_pbPlatforms[10] = pbAchPlat_tagged;
                }

                // otherwise, disable the platform
                else
                {
                    pbAchPlat_tagged.Enabled = false;
                    pbAchPlat_tagged.BackColor = Color.DarkGreen;
                    array_pbPlatforms[10] = null;
                }
            }
        }

        // check if achievement was obtained in certain levels
        private void AchievementCheck()
        {
            // if first achievement was obtained
            if (A1_Obtained)
            {
                // make certain star turned on for a certain achievement
                FormProvider.Achs_Form.pb_AchStar.Visible = true;
                FormProvider.Achs_Form.pb_AchStar.Enabled = true;
                AchievementOne_Obtained = true;
            }

            if (A2_Obtained)
            {
                FormProvider.Achs_Form.pb_AchStar2.Visible = true;
                FormProvider.Achs_Form.pb_AchStar2.Enabled = true;
                AchievementTwo_Obtained = true;
            }
        }

        // control achievements throughout certain levels
        private void Achievement(int isLevel, PictureBox pbAchievement_tagged)
        {
            // if it's a tutorial
            if (isLevel == 0)
            {
                // if first achievement was already obtained in the past
                if (AchievementOne_Obtained)
                {
                    pbAchievement_tagged.Dispose();
                }

                // if key is obtained
                if (isObtained)
                {
                    // if first achievement was already obtained in the past
                    if (FormProvider.Achs_Form.pb_AchStar.Visible == true)
                    {
                        /*
                        // enable and unhide an achievement trophy
                        pbAchievement_tagged.Enabled = true;
                        pbAchievement_tagged.Visible = true;

                        // if player touches achievement trophy
                        if (pbAchievement_tagged.Bounds.IntersectsWith(PIC_Player.Bounds))
                        {
                            pbAchievement_tagged.Dispose();
                            AchievementOne_Obtained = true;
                        }*/
                        pbAchievement_tagged.Dispose();
                    }

                    else
                    {
                        // enable and unhide an achievement trophy
                        pbAchievement_tagged.Enabled = true;
                        pbAchievement_tagged.Visible = true;

                        // if player touches achievement trophy
                        if (pbAchievement_tagged.Bounds.IntersectsWith(PIC_Player.Bounds))
                        {
                            pbAchievement_tagged.Dispose();
                            AchievementOne_Obtained = true;
                        }
                    }
                }

                // otherwise, disable and hide an achievement trophy
                else
                {
                    pbAchievement_tagged.Enabled = false;
                    pbAchievement_tagged.Visible = false;
                }
            }

            // if it's level two
            if (isLevel == 2)
            {
                
                if (AchievementTwo_Obtained)
                {
                    pbAchievement_tagged.Dispose();
                }

                // if key is obtained
                if (isObtained)
                {
                    // if first achievement was already obtained in the past
                    if (FormProvider.Achs_Form.pb_AchStar2.Visible == true)
                    {
                        /*
                        // enable and unhide an achievement trophy
                        pbAchievement_tagged.Enabled = true;
                        pbAchievement_tagged.Visible = true;

                        // if player touches achievement trophy
                        if (pbAchievement_tagged.Bounds.IntersectsWith(PIC_Player.Bounds))
                        {
                            pbAchievement_tagged.Dispose();
                            AchievementOne_Obtained = true;
                        }*/
                        pbAchievement_tagged.Dispose();
                    }

                    else
                    {
                        // enable and unhide an achievement trophy
                        pbAchievement_tagged.Enabled = true;
                        pbAchievement_tagged.Visible = true;

                        // if player touches achievement trophy
                        if (pbAchievement_tagged.Bounds.IntersectsWith(PIC_Player.Bounds))
                        {
                            pbAchievement_tagged.Dispose();
                            AchievementTwo_Obtained = true;
                        }
                    }
                }

                // otherwise, disable and hide an achievement trophy
                else
                {
                    pbAchievement_tagged.Enabled = false;
                    pbAchievement_tagged.Visible = false;
                }
            }
        }

        // detect coin interaction
        private void CoinInteraction(int isLevel, PictureBox pbCtagged)
        {
            // Tutorial
            //if (isLevel == 0)
            //{
            // if player touches the coin
            if (pbCtagged.Bounds.IntersectsWith(PIC_Player.Bounds))
            {
                // add up one coin to player's bank
                intCoins += 1;
                // get rid of it once collected
                pbCtagged.Dispose();
            }
            //}
        }

        // stop the game loop from specific condition
        private void TemporaryStop()
        {
            // stop the game fully
            FPS_Timer.Stop();
            // stop the stopwatch fully
            Stopwatch_Secs.Stop();

            blnInteractKey = false;
            MessageBox.Show("Find the key first to unlock this door.", "No key.");

            // resume the game
            FPS_Timer.Start();
            // resume the stopwatch
            Stopwatch_Secs.Start();
        }

        int intcount = 0;
        bool blnInShop = false;
        // check if the interaction key was pressed on specific objects
        private void InteractionDetection(int isLevel, PictureBox pbE_OR_Sxtagged)
        {
            // switch statement to allow multiple parameters stored as one into this method (avoid bug)
            switch (pbE_OR_Sxtagged.Tag)
            {

                // if interaction happened with exit door
                case CodedObjects.Tag_Exit:

                    // control door image for key touch (avoid bug)
                    if (isObtained)
                    {
                        // Don't reveal the door opened for level 10 or 1 (bonus)
                        if (isLevel == 10 || isLevel == 11)
                        {
                            pbE_OR_Sxtagged.Image = Resources.Door_Closed;
                        }
                        
                        else
                        {
                            pbE_OR_Sxtagged.Image = Resources.Door_Open;
                        }
                    }

                    if (!isObtained)
                    {
                        pbE_OR_Sxtagged.Image = Resources.Door_Closed;
                    }

                    // if interaction key was pressed
                    if (blnInteractKey == true)
                    {

                        // if it's a tutorial
                        if (isLevel == 0)
                        {
                            // if player touches the door boundaries
                            if (pbE_OR_Sxtagged.Bounds.IntersectsWith(PIC_Player.Bounds))
                            {
                                // if the player does not have a key
                                if (!isObtained)
                                {
                                    TemporaryStop();
                                }

                                // otherwise, finish the level and award the player
                                else
                                {
                                    LevelCompleted(isLevel);
                                }
                            }
                        }
                        
                        // if it's level one
                        if (isLevel == 1)
                        {
                            // if player touches the door boundaries
                            if (pbE_OR_Sxtagged.Bounds.IntersectsWith(PIC_Player.Bounds))
                            {
                                // if the player does not have a key
                                if (!isObtained)
                                {
                                    TemporaryStop();
                                }

                                // otherwise, finish the level and award the player
                                else
                                {
                                    LevelCompleted(isLevel);
                                }
                            }
                        }

                        // if it's level two
                        if (isLevel == 2)
                        {
                            // if player touches the door boundaries
                            if (pbE_OR_Sxtagged.Bounds.IntersectsWith(PIC_Player.Bounds))
                            {
                                // if the player does not have a key
                                if (!isObtained)
                                {
                                    TemporaryStop();
                                }

                                // otherwise, finish the level and award the player
                                else
                                {
                                    LevelCompleted(isLevel);
                                }
                            }
                        }

                        // if it's level three
                        if (isLevel == 3)
                        {
                            // if player touches the door boundaries
                            if (pbE_OR_Sxtagged.Bounds.IntersectsWith(PIC_Player.Bounds))
                            {
                                // if the player does not have a key
                                if (!isObtained)
                                {
                                    TemporaryStop();
                                }

                                // otherwise, finish the level and award the player
                                else
                                {
                                    LevelCompleted(isLevel);
                                }
                            }
                        }
                        
                        // if it's level four
                        if (isLevel == 4)
                        {
                            // if player touches the door boundaries
                            if (pbE_OR_Sxtagged.Bounds.IntersectsWith(PIC_Player.Bounds))
                            {
                                // if the player does not have a key
                                if (!isObtained)
                                {
                                    TemporaryStop();
                                }

                                // otherwise, finish the level and award the player
                                else
                                {
                                    LevelCompleted(isLevel);
                                }
                            }
                        }
                        
                        // if it's level five
                        if (isLevel == 5)
                        {
                            // if player touches the door boundaries
                            if (pbE_OR_Sxtagged.Bounds.IntersectsWith(PIC_Player.Bounds))
                            {
                                // if the player does not have a key
                                if (!isObtained)
                                {
                                    TemporaryStop();
                                }

                                // otherwise, finish the level and award the player
                                else
                                {
                                    LevelCompleted(isLevel);
                                }
                            }
                        }
                        
                        // if it's level six
                        if (isLevel == 6)
                        {
                            // if player touches the door boundaries
                            if (pbE_OR_Sxtagged.Bounds.IntersectsWith(PIC_Player.Bounds))
                            {
                                // if the player does not have a key
                                if (!isObtained)
                                {
                                    TemporaryStop();
                                }

                                // otherwise, finish the level and award the player
                                else
                                {
                                    LevelCompleted(isLevel);
                                }
                            }
                        }
                        
                        // if it's level seven
                        if (isLevel == 7)
                        {
                            // if player touches the door boundaries
                            if (pbE_OR_Sxtagged.Bounds.IntersectsWith(PIC_Player.Bounds))
                            {
                                // if the player does not have a key
                                if (!isObtained)
                                {
                                    TemporaryStop();
                                }

                                // otherwise, finish the level and award the player
                                else
                                {
                                    LevelCompleted(isLevel);
                                }
                            }
                        }
                        
                        // if it's level eight
                        if (isLevel == 8)
                        {
                            // if player touches the door boundaries
                            if (pbE_OR_Sxtagged.Bounds.IntersectsWith(PIC_Player.Bounds))
                            {
                                // if the player does not have a key
                                if (!isObtained)
                                {
                                    TemporaryStop();
                                }

                                // otherwise, finish the level and award the player
                                else
                                {
                                    LevelCompleted(isLevel);
                                }
                            }
                        }
                        
                        // if it's level nine
                        if (isLevel == 9)
                        {
                            // if player touches the door boundaries
                            if (pbE_OR_Sxtagged.Bounds.IntersectsWith(PIC_Player.Bounds))
                            {
                                // if the player does not have a key
                                if (!isObtained)
                                {
                                    TemporaryStop();
                                }

                                // otherwise, finish the level and award the player
                                else
                                {
                                    LevelCompleted(isLevel);
                                }
                            }
                        }
                        
                        // if it's level 10
                        if (isLevel == 10)
                        {

                            // if player touches the door boundaries
                            if (pbE_OR_Sxtagged.Bounds.IntersectsWith(PIC_Player.Bounds))
                            {
                                // if the player does not have a key
                                if (!isObtained)
                                {
                                    TemporaryStop();
                                }

                                // otherwise, finish the level and award the player
                                else
                                {
                                    LevelCompleted(isLevel);
                                }
                            }
                        }
                        
                        // if it's level 1 (bonus)
                        if (isLevel == 11)
                        {

                            // if player touches the door boundaries
                            if (pbE_OR_Sxtagged.Bounds.IntersectsWith(PIC_Player.Bounds))
                            {
                                // if the player does not have a key
                                if (!isObtained)
                                {
                                    TemporaryStop();
                                }

                                // otherwise, finish the level and award the player
                                else
                                {
                                    LevelCompleted(isLevel);
                                }
                            }
                        }
                        
                        // if it's level 2 (bonus)
                        if (isLevel == 12)
                        {
                            // if player touches the door boundaries
                            if (pbE_OR_Sxtagged.Bounds.IntersectsWith(PIC_Player.Bounds))
                            {
                                // if the player does not have a key
                                if (!isObtained)
                                {
                                    TemporaryStop();
                                }

                                // otherwise, finish the level and award the player
                                else
                                {
                                    LevelCompleted(isLevel);
                                }
                            }
                        }
                        
                        // if it's level 3 (bonus)
                        if (isLevel == 13)
                        {
                            // if player touches the door boundaries
                            if (pbE_OR_Sxtagged.Bounds.IntersectsWith(PIC_Player.Bounds))
                            {
                                // if the player does not have a key
                                if (!isObtained)
                                {
                                    TemporaryStop();
                                }

                                // otherwise, finish the level and award the player
                                else
                                {
                                    LevelCompleted(isLevel);
                                }
                            }
                        }
                    }

                    break;

                // if interaction happened with the shop
                case CodedObjects.Tag_Shop:
                    
                    // if button was pressed
                    if (blnInteractKey)
                    {
                        // if player touches the shop boundaries
                        if (pbE_OR_Sxtagged.Bounds.IntersectsWith(PIC_Player.Bounds))
                        {
                            // stop the game for a moment
                            FPS_Timer.Stop();

                            // temporarily stop the stopwatch
                            Stopwatch_Secs.Stop();

                            // the player did not interact with the shop (avoid multiple shop GUI's)
                            if (!blnInShop)
                            {

                                // 'Exit' button to exit the groupbox 'Shop'
                                Button btn_Exit = new Button();
                                Controls.Add(btn_Exit);
                                btn_Exit.Location = new Point(250, 20);
                                btn_Exit.Size = new Size(50, 50);
                                btn_Exit.Text = "Exit";

                                // 'Double Jump' button
                                Button btn_DJ = new Button();
                                Controls.Add(btn_DJ);
                                btn_DJ.Location = new Point(20, 100);
                                btn_DJ.Size = new Size(130, 50);
                                btn_DJ.Text = "Double Jump";
                                btn_DJ.Font = new Font("Comic Sans MS", 12, FontStyle.Bold);

                                // 'Extra life' button
                                Button btn_EL = new Button();
                                Controls.Add(btn_EL);
                                btn_EL.Location = new Point(20, 170);
                                btn_EL.Size = new Size(130, 50);
                                btn_EL.Text = "Extra life";
                                btn_EL.Font = new Font("Comic Sans MS", 12, FontStyle.Bold);

                                // a text saying how much was bought
                                Label lbl_DJ_Count = new Label();
                                Controls.Add(lbl_DJ_Count);
                                lbl_DJ_Count.Location = new Point(200, 100);
                                if (isDouble)
                                {
                                    lbl_DJ_Count.Text = "YES";
                                }
                                else
                                {
                                    lbl_DJ_Count.Text = "NO";
                                }
                                lbl_DJ_Count.Size = new Size(70, 70);
                                lbl_DJ_Count.Font = new Font("Comic Sans MS", 18, FontStyle.Bold);

                                // a text saying how much was bought
                                Label lbl_EL_Count = new Label();
                                Controls.Add(lbl_EL_Count);
                                lbl_EL_Count.Location = new Point(200, 180);
                                lbl_EL_Count.Text = "x" + intcount;
                                lbl_EL_Count.Size = new Size(50, 50);
                                lbl_EL_Count.Font = new Font("Comic Sans MS", 18, FontStyle.Bold);

                                // a text saying how much was bought
                                Label lbl_YouHave = new Label();
                                Controls.Add(lbl_YouHave);
                                lbl_YouHave.Location = new Point(45, 240);
                                lbl_YouHave.Text = "You have:";
                                lbl_YouHave.Size = new Size(150, 150);
                                lbl_YouHave.Font = new Font("Comic Sans MS", 12, FontStyle.Bold);

                                // a text giving amount of coins
                                Label lbl_Points_Count = new Label();
                                Controls.Add(lbl_Points_Count);
                                lbl_Points_Count.Location = new Point(140, 240);
                                lbl_Points_Count.Text = intCoins + " Coins";
                                lbl_Points_Count.Size = new Size(150, 150);
                                lbl_Points_Count.Font = new Font("Comic Sans MS", 12, FontStyle.Bold);

                                // title of the groupbox
                                Label lbl_title = new Label();
                                Controls.Add(lbl_title);
                                lbl_title.Location = new Point(110, 30);
                                lbl_title.Text = "Shop";
                                lbl_title.Size = new Size(70, 70);
                                lbl_title.Font = new Font("Comic Sans MS", 16, FontStyle.Bold | FontStyle.Underline);

                                // groupbox mixing all the controls above together, forming a GUI
                                GroupBox GB_ShopOptions = new GroupBox();
                                Controls.Add(GB_ShopOptions);
                                GB_ShopOptions.Location = new Point(200, 200);
                                GB_ShopOptions.Size = new Size(300, 300);
                                GB_ShopOptions.BackColor = Color.White;
                                GB_ShopOptions.Controls.Add(lbl_title);
                                GB_ShopOptions.Controls.Add(btn_DJ);
                                GB_ShopOptions.Controls.Add(btn_EL);
                                GB_ShopOptions.Controls.Add(lbl_DJ_Count);
                                GB_ShopOptions.Controls.Add(lbl_EL_Count);
                                GB_ShopOptions.Controls.Add(lbl_Points_Count);
                                GB_ShopOptions.Controls.Add(lbl_YouHave);
                                GB_ShopOptions.Controls.Add(btn_Exit);
                                GB_ShopOptions.BringToFront();

                                if (isDefaultT)
                                {
                                    MessageBox.Show("Double jump allows you to press jump twice.", "Guider");
                                    MessageBox.Show("Extra life adds your total life count.", "Guider");
                                    MessageBox.Show("The coins are scattered around every level, collect them if you wish.", "Guider");
                                    MessageBox.Show("You can also gain coins by completing each level successfully.", "Guider");
                                    MessageBox.Show("The coins throughout the game are limited, so don't try and cheat by buying 100 lives because that's boring man.", "Guider");
                                    MessageBox.Show("Also, upon restarting the level, the coins do restart.");
                                    MessageBox.Show("For now, I'll give you a coin if you need an extra life. If you want a double jump, collect the coin on top-right side of this area and come back here. (You can save these coins for future)\n\nDouble Jump = 2 coins\nExtra Life = 1 coin", "Guider");

                                    isDefaultT = false;
                                    intCoins += 1;
                                }

                                // if the user wants to buy extra life
                                btn_DJ.Click += delegate
                                {
                                    // if double jump was already bought
                                    if (lbl_DJ_Count.Text == "YES")
                                    {
                                        MessageBox.Show("You already bought Double Jump.");
                                    }

                                    // if there are at least 2 coins
                                    else if (intCoins >= 2)
                                    {
                                        lbl_DJ_Count.Text = "YES";

                                        isDouble = true;

                                        // remove a coin from player's bank
                                        intCoins -= 2;
                                        lbl_Points_Count.Text = intCoins + " Coins";
                                    }

                                    // otherwise, notify the player that he doesn't have enough coins
                                    else
                                    {
                                        MessageBox.Show("You don't have enough coins to buy Double Jump.");
                                    }
                                };

                                // if the user wants to buy extra life
                                btn_EL.Click += delegate
                                {
                                    // if there are coins
                                    if (intCoins != 0)
                                    {
                                        intcount++;
                                        lbl_EL_Count.Text = "x" + intcount;

                                        // add +1 life to player's health count
                                        intLives += 1;
                                        lbl_Lives.Text = Convert.ToString(intLives);

                                        // remove a coin from player's bank
                                        intCoins -= 1;
                                        lbl_Points_Count.Text = intCoins + " Coins";
                                    }
                                    // otherwise, notify the player that he doesn't have enough coins
                                    else
                                    {
                                        MessageBox.Show("You don't have enough coins to buy Extra Life.");
                                    }
                                };

                                // if exit button is pressed within a shop
                                btn_Exit.Click += delegate
                                {
                                    // not in shop anymore
                                    blnInShop = false;

                                    // clear off the groupbox and its contents
                                    GB_ShopOptions.Dispose();

                                    // resume the game
                                    FPS_Timer.Start();

                                    // resume the stopwatch
                                    Stopwatch_Secs.Start();
                                };
                                // disable interaction with the shop
                                blnInteractKey = false;

                                blnInShop = true;
                            }
                        }
                    }
                    
                    break;
            }
            
        }

        // after the game is done
        private void LevelCompleted(int islevel)
        {

            // stop the game fully
            FPS_Timer.Stop();

            // stop the stopwatch fully
            Stopwatch_Secs.Stop();

            // disable button interaction
            blnInteractKey = false;

            // add coin to bank
            intCoins += 1;

            // add the bank to saving process
            FormProvider.SML_Form.CoinSave(intCoins);

            // tutorial completed
            if (islevel == 0)
            {
                // store time in a JSON file as a score
                int mintosec = ticksMin * 60;
                int TimeScore = mintosec + ticksSec;

                string json = Properties.Resources.TimeScore;
                dynamic jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
                jsonObj["Time"] = TimeScore;
                string output = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObj, Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText(@"TimeScore.txt", output);
                
                // pass current time into different form (avoid time count bug)
                int VarTimeSave = TimeScore;
                FormProvider.SML_Form.StoreTime(VarTimeSave);

                isCompleted = true;

                // pass to a different form a completed level counter
                string lc = FormProvider.SML_Form.LC = "0";
                
                // pass achievement to different method
                FormProvider.SML_Form.SavedAchievements(AchievementOne_Obtained, isLevel);
                
                // disable the guider
                FormProvider.SETT_Form.CB_Guider.Checked = false;
                
                // provide the user with a choice of keep playing or not
                DialogResult endlevelchoice = MessageBox.Show("Tutorial completed!\n\n Move to the next level?", "Tutorial completed!", MessageBoxButtons.YesNo);
                
                // pass parameters into a method that checks progress through level
                FormProvider.SML_Form.LevelCompleted(lc, endlevelchoice);
            }

            // level 1 completed
            if (islevel == 1)
            {

                // store time in a JSON file as a score
                int mintosec = ticksMin * 60;
                int TimeScore = mintosec + ticksSec;

                string json = Properties.Resources.TimeScore;
                dynamic jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
                jsonObj["Time"] = TimeScore;
                string output = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObj, Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText(@"TimeScore.txt", output);

                // pass current time into different form (avoid time count bug)
                int VarTimeSave = TimeScore;
                FormProvider.SML_Form.StoreTime(VarTimeSave);

                // pass to a different form a completed level counter
                string lc = FormProvider.SML_Form.LC = "1";
                
                // provide the user with a choice of keep playing or not
                DialogResult endlevelchoice = MessageBox.Show("Level one completed!\n\n Move to the next level?", "Level One completed!", MessageBoxButtons.YesNo);
                
                // pass parameters into a method that checks progress through level
                FormProvider.SML_Form.LevelCompleted(lc, endlevelchoice);
            }

            // level 2 completed
            if (islevel == 2)
            {
                // store time in a JSON file as a score
                int mintosec = ticksMin * 60;
                int TimeScore = VarTimeLoad + (mintosec + ticksSec);

                string json = Properties.Resources.TimeScore;
                dynamic jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
                jsonObj["Time"] = 0;
                jsonObj["Time"] += TimeScore;
                string output = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObj, Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText(@"TimeScore.txt", output);

                // pass current time into different form (avoid time count bug)
                int VarTimeSave = TimeScore;
                FormProvider.SML_Form.StoreTime(VarTimeSave);

                // pass to a different form completed level counter
                string lc = FormProvider.SML_Form.LC = "2";

                // achievement pass
                FormProvider.SML_Form.SavedAchievements(AchievementTwo_Obtained, isLevel);

                // provide the user with a choice of keep playing or not
                DialogResult endlevelchoice = MessageBox.Show("Level two completed!\n\n Move to the next level?", "Level Two completed!", MessageBoxButtons.YesNo);

                // pass parameters into a method that checks progress through level
                FormProvider.SML_Form.LevelCompleted(lc, endlevelchoice);
            }

            // level 3 completed
            if (islevel == 3)
            {
                // store time in a JSON file as a score
                int mintosec = ticksMin * 60;
                int TimeScore = VarTimeLoad + (mintosec + ticksSec);

                string json = Properties.Resources.TimeScore;
                dynamic jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
                jsonObj["Time"] = 0;
                jsonObj["Time"] += TimeScore;
                string output = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObj, Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText(@"TimeScore.txt", output);

                // pass current time into different form (avoid time count bug)
                int VarTimeSave = TimeScore;
                FormProvider.SML_Form.StoreTime(VarTimeSave);

                // pass to a different form completed level counter
                string lc = FormProvider.SML_Form.LC = "3";

                // provide the user with a choice of keep playing or not
                //FormProvider.SML_Form.SavedAchievements(AchievementTwo_Obtained);
                DialogResult endlevelchoice = MessageBox.Show("Level three completed!\n\n Move to the next level?", "Level Three completed!", MessageBoxButtons.YesNo);

                // pass parameters into a method that checks progress through level
                FormProvider.SML_Form.LevelCompleted(lc, endlevelchoice);
            }

            // level 4 completed
            if (islevel == 4)
            {
                // store time in a JSON file as a score
                int mintosec = ticksMin * 60;
                int TimeScore = VarTimeLoad + (mintosec + ticksSec);

                string json = Properties.Resources.TimeScore;
                dynamic jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
                jsonObj["Time"] = 0;
                jsonObj["Time"] += TimeScore;
                string output = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObj, Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText(@"TimeScore.txt", output);

                // pass current time into different form (avoid time count bug)
                int VarTimeSave = TimeScore;
                FormProvider.SML_Form.StoreTime(VarTimeSave);

                // pass to a different form completed level counter
                string lc = FormProvider.SML_Form.LC = "4";

                // provide the user with a choice of keep playing or not
                //FormProvider.SML_Form.SavedAchievements(AchievementTwo_Obtained);
                DialogResult endlevelchoice = MessageBox.Show("Level four completed!\n\n Move to the next level?", "Level Four completed!", MessageBoxButtons.YesNo);

                // pass parameters into a method that checks progress through level
                FormProvider.SML_Form.LevelCompleted(lc, endlevelchoice);
            }

            // level 5 completed
            if (islevel == 5)
            {
                // store time in a JSON file as a score
                int mintosec = ticksMin * 60;
                int TimeScore = VarTimeLoad + (mintosec + ticksSec);

                string json = Properties.Resources.TimeScore;
                dynamic jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
                jsonObj["Time"] = 0;
                jsonObj["Time"] += TimeScore;
                string output = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObj, Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText(@"TimeScore.txt", output);

                // pass current time into different form (avoid time count bug)
                int VarTimeSave = TimeScore;
                FormProvider.SML_Form.StoreTime(VarTimeSave);

                // pass to a different form completed level counter
                string lc = FormProvider.SML_Form.LC = "5";

                // provide the user with a choice of keep playing or not
                //FormProvider.SML_Form.SavedAchievements(AchievementTwo_Obtained);
                DialogResult endlevelchoice = MessageBox.Show("Level five completed!\n\n Move to the next level?", "Level Five completed!", MessageBoxButtons.YesNo);

                // pass parameters into a method that checks progress through level
                FormProvider.SML_Form.LevelCompleted(lc, endlevelchoice);
            }
            
            // level 6 completed
            if (islevel == 6)
            {
                // store time in a JSON file as a score
                int mintosec = ticksMin * 60;
                int TimeScore = VarTimeLoad + (mintosec + ticksSec);

                string json = Properties.Resources.TimeScore;
                dynamic jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
                jsonObj["Time"] = 0;
                jsonObj["Time"] += TimeScore;
                string output = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObj, Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText(@"TimeScore.txt", output);

                // pass current time into different form (avoid time count bug)
                int VarTimeSave = TimeScore;
                FormProvider.SML_Form.StoreTime(VarTimeSave);

                // pass to a different form completed level counter
                string lc = FormProvider.SML_Form.LC = "6";

                // provide the user with a choice of keep playing or not
                //FormProvider.SML_Form.SavedAchievements(AchievementTwo_Obtained);
                DialogResult endlevelchoice = MessageBox.Show("Level six completed!\n\n Move to the next level?", "Level Six completed!", MessageBoxButtons.YesNo);

                // pass parameters into a method that checks progress through level
                FormProvider.SML_Form.LevelCompleted(lc, endlevelchoice);
            }
            
            // level 7 completed
            if (islevel == 7)
            {
                // store time in a JSON file as a score
                int mintosec = ticksMin * 60;
                int TimeScore = VarTimeLoad + (mintosec + ticksSec);

                string json = Properties.Resources.TimeScore;
                dynamic jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
                jsonObj["Time"] = 0;
                jsonObj["Time"] += TimeScore;
                string output = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObj, Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText(@"TimeScore.txt", output);

                // pass current time into different form (avoid time count bug)
                int VarTimeSave = TimeScore;
                FormProvider.SML_Form.StoreTime(VarTimeSave);

                // pass to a different form completed level counter
                string lc = FormProvider.SML_Form.LC = "7";

                // provide the user with a choice of keep playing or not
                //FormProvider.SML_Form.SavedAchievements(AchievementTwo_Obtained);
                DialogResult endlevelchoice = MessageBox.Show("Level seven completed!\n\n Move to the next level?", "Level Seven completed!", MessageBoxButtons.YesNo);

                // pass parameters into a method that checks progress through level
                FormProvider.SML_Form.LevelCompleted(lc, endlevelchoice);
            }
            
            // level 8 completed
            if (islevel == 8)
            {
                // store time in a JSON file as a score
                int mintosec = ticksMin * 60;
                int TimeScore = VarTimeLoad + (mintosec + ticksSec);

                string json = Properties.Resources.TimeScore;
                dynamic jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
                jsonObj["Time"] = 0;
                jsonObj["Time"] += TimeScore;
                string output = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObj, Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText(@"TimeScore.txt", output);

                // pass current time into different form (avoid time count bug)
                int VarTimeSave = TimeScore;
                FormProvider.SML_Form.StoreTime(VarTimeSave);

                // pass to a different form completed level counter
                string lc = FormProvider.SML_Form.LC = "8";

                // provide the user with a choice of keep playing or not
                //FormProvider.SML_Form.SavedAchievements(AchievementTwo_Obtained);
                DialogResult endlevelchoice = MessageBox.Show("Level eight completed!\n\n Move to the next level?", "Level Eight completed!", MessageBoxButtons.YesNo);

                // pass parameters into a method that checks progress through level
                FormProvider.SML_Form.LevelCompleted(lc, endlevelchoice);
            }
            
            // level 9 completed
            if (islevel == 9)
            {
                // store time in a JSON file as a score
                int mintosec = ticksMin * 60;
                int TimeScore = VarTimeLoad + (mintosec + ticksSec);

                string json = Properties.Resources.TimeScore;
                dynamic jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
                jsonObj["Time"] = 0;
                jsonObj["Time"] += TimeScore;
                string output = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObj, Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText(@"TimeScore.txt", output);

                // pass current time into different form (avoid time count bug)
                int VarTimeSave = TimeScore;
                FormProvider.SML_Form.StoreTime(VarTimeSave);

                // pass to a different form completed level counter
                string lc = FormProvider.SML_Form.LC = "9";

                // provide the user with a choice of keep playing or not
                //FormProvider.SML_Form.SavedAchievements(AchievementTwo_Obtained);
                DialogResult endlevelchoice = MessageBox.Show("Level nine completed!\n\n Move to the next level?", "Level Nine completed!", MessageBoxButtons.YesNo);

                // pass parameters into a method that checks progress through level
                FormProvider.SML_Form.LevelCompleted(lc, endlevelchoice);
            }
            
            // level 10 completed
            if (islevel == 10)
            {
                // store time in a JSON file as a score
                int mintosec = ticksMin * 60;
                int TimeScore = VarTimeLoad + (mintosec + ticksSec);

                string json = Properties.Resources.TimeScore;
                dynamic jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
                jsonObj["Time"] += TimeScore;
                string output = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObj, Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText(@"TimeScore.txt", output);

                // pass current time into different form (avoid time count bug)
                int VarTimeSave = TimeScore;
                FormProvider.SML_Form.StoreTime(VarTimeSave);

                // pass to a different form completed level counter
                string lc = FormProvider.SML_Form.LC = "10";
                
                // end text
                MessageBox.Show("Well done, you have completed all the levels!", "Guider");
                MessageBox.Show("You're trully are... An adventurer!", "Guider");
                MessageBox.Show("There's still so much to do with this game if you're interested.\nYou decide.", "Guider");
                MessageBox.Show("Enter your name after this message so that your time can be saved as a score.");

                // store name input as a string through InputBox
                string nameInput = Microsoft.VisualBasic.Interaction.InputBox("Enter your name", "Player name");

                int actualTime = jsonObj["Time"];

                // read highscores file
                string argnewPath = "HScores.txt";
                newScore = new StatsLoad(ref argnewPath);

                newScore.InsertNewHighScore(ref nameInput, actualTime);
                var argTxtBox = FormProvider.Stats_Form.textBox1;
                newScore.ShowHighScores(ref argTxtBox);

                FormProvider.Stats_Form.textBox1 = argTxtBox;

                // pass parameters into a method that checks progress through level
                FormProvider.SML_Form.LevelCompleted(lc, DialogResult.No);
            }

            // [BONUS] level 1 completed
            if (islevel == 11)
            {
                MessageBox.Show("Level One completed!");

                // pass to a different form completed level counter
                string blc = FormProvider.BL_Form.BLC = "1";
                FormProvider.BL_Form.LevelCompleted(blc);
            }
            
            // [BONUS] level 2 completed
            if (islevel == 12)
            {
                MessageBox.Show("Level Two completed!");

                // pass to a different form completed level counter
                string blc = FormProvider.BL_Form.BLC = "2";
                FormProvider.BL_Form.LevelCompleted(blc);
            }
            
            // [BONUS] level 3 completed
            if (islevel == 13)
            {
                MessageBox.Show("Level Three completed!");

                // pass to a different form completed level counter
                string blc = FormProvider.BL_Form.BLC = "3";
                FormProvider.BL_Form.LevelCompleted(blc);
            }

            // get rid of this form forever
            this.Dispose();
        }

        // Pause menu
        private void PauseLevel()
        {
            // if not in pause menu (avoid multiple GUI when clicking)
            if (!blnInPause)
            {
                // stop the game loop
                FPS_Timer.Stop();
                
                // temporarily stop the stopwatch
                Stopwatch_Secs.Stop();

                // 'pause' title
                Label lbl_pause = new Label();
                Controls.Add(lbl_pause);
                lbl_pause.Location = new Point(170, 25);
                lbl_pause.Size = new Size(240, 50);
                lbl_pause.Text = "Pause Menu";
                lbl_pause.Font = new Font("Comic Sans MS", 28, FontStyle.Bold);

                // 'Continue' button
                Button btn_Resume = new Button();
                Controls.Add(btn_Resume);
                btn_Resume.Location = new Point(180, 100);
                btn_Resume.Size = new Size(200, 70);
                btn_Resume.Text = "Resume";
                btn_Resume.Font = new Font("Comic Sans MS", 16, FontStyle.Bold);
                
                // 'Hint' button
                Button btn_Hint = new Button();
                Controls.Add(btn_Hint);
                btn_Hint.Location = new Point(180, 200);
                btn_Hint.Size = new Size(200, 70);
                btn_Hint.Text = "Hint";
                btn_Hint.Font = new Font("Comic Sans MS", 16, FontStyle.Bold);
                
                // 'Exit' button
                Button btn_Exit = new Button();
                Controls.Add(btn_Exit);
                btn_Exit.Location = new Point(180, 300);
                btn_Exit.Size = new Size(200, 70);
                btn_Exit.Text = "Exit";
                btn_Exit.Font = new Font("Comic Sans MS", 16, FontStyle.Bold);

                // background gif image
                PictureBox backgroundGif = new PictureBox();
                Controls.Add(backgroundGif);
                backgroundGif.Image = Resources.SolidColouredGif;
                backgroundGif.Dock = DockStyle.Fill;

                // level label
                Label labellevel = new Label();
                Controls.Add(labellevel);
                labellevel.Location = new Point(450, 25);
                labellevel.Size = new Size(80, 30);
                labellevel.Text = "Level:";
                labellevel.Font = new Font("Comic Sans MS", 16, FontStyle.Bold);
                
                // level number label
                Label lbl_level = new Label();
                Controls.Add(lbl_level);
                lbl_level.Location = new Point(530, 25);
                lbl_level.Size = new Size(40, 30);
                lbl_level.Text = Convert.ToString(isLevel);
                lbl_level.Font = new Font("Comic Sans MS", 16, FontStyle.Bold);

                // groupbox which is actually a menu
                GroupBox GB_PauseMenu = new GroupBox();
                Controls.Add(GB_PauseMenu);
                GB_PauseMenu.Location = new Point(100, 50);
                GB_PauseMenu.Size = new Size(600, 400);
                GB_PauseMenu.BackColor = Color.White;
                GB_PauseMenu.Controls.Add(lbl_pause);
                GB_PauseMenu.Controls.Add(labellevel);
                GB_PauseMenu.Controls.Add(lbl_level);
                GB_PauseMenu.Controls.Add(btn_Resume);
                GB_PauseMenu.Controls.Add(btn_Hint);
                GB_PauseMenu.Controls.Add(btn_Exit);
                GB_PauseMenu.Controls.Add(backgroundGif);
                GB_PauseMenu.BringToFront();

                // mini-method for pressing 'continue' button
                btn_Resume.Click += delegate
                {
                    blnInPause = false;
                    // continue game loop
                    FPS_Timer.Start();
                    // resume the stopwatch
                    Stopwatch_Secs.Start();
                    // remove the groupbox/pause menu
                    GB_PauseMenu.Dispose();
                };

                // mini-method for exiting the pause menu
                btn_Exit.Click += delegate
                {
                    DialogResult exit = MessageBox.Show("Are you sure you want to quit the game?\nThe current level progress will be gone!", "", MessageBoxButtons.YesNo);
                    switch (exit)
                    {
                        case DialogResult.Yes:
                            blnInPause = false;
                            // remove the groupbox/pause menu
                            GB_PauseMenu.Dispose();

                            this.Close();
                            break;
                    }
                };

                // mini-method for giving a random hint
                btn_Hint.Click += delegate
                {
                    Random intRnd = new Random();
                    int intRand = intRnd.Next(0, 7);
                    switch (intRand)
                    {
                        case 0:
                            MessageBox.Show("To interact with a shop/door, press the 'E' key.", "Random Hint");
                            break;
                        case 1:
                            MessageBox.Show("Double Jump and Extra Life cost only one coin.", "Random Hint");
                            break;
                        case 2:
                            MessageBox.Show("Coins are limited, use them wisely.", "Random Hint");
                            break;
                        case 3:
                            MessageBox.Show("Instead of weapons, you can just jump around enemies to avoid being hit.", "Random Hint");
                            break;
                        case 4:
                            MessageBox.Show("Achievement trophies are optional challenges.", "Random Hint");
                            break;
                        case 5:
                            MessageBox.Show("To restart the level, press the 'R' key.", "Random Hint");
                            break;
                        case 6:
                            MessageBox.Show("Try to judge what the enemy movement speed is, might come in handy...", "Random Hint");
                            break;
                        case 7:
                            MessageBox.Show("Some levels will require you to have extra life or a double jump in case you can't complete the level.", "Random Hint");
                            break;
                        case 8:
                            MessageBox.Show("Depending on a level, you'll get certain amount of coins to spend in shop.", "Random Hint");
                            break;
                        case 9:
                            MessageBox.Show("To interact with a shop/door, press the 'E' key.", "Random Hint");
                            break;
                        case 10:
                            MessageBox.Show("Double Jump and Extra Life cost only one coin.", "Random Hint");
                            break;
                        case 11:
                            MessageBox.Show("Coins are limited, use them wisely.", "Random Hint");
                            break;
                        case 12:
                            MessageBox.Show("Instead of weapons, you can just jump around enemies to avoid being hit.", "Random Hint");
                            break;
                        case 13:
                            MessageBox.Show("Achievement trophies are optional challenges.", "Random Hint");
                            break;
                        case 14:
                            MessageBox.Show("To restart the level, press the 'R' key.", "Random Hint");
                            break;
                        case 15:
                            MessageBox.Show("Try to judge what the enemy movement speed is, might come in handy...", "Random Hint");
                            break;
                        case 16:
                            MessageBox.Show("Some levels will require you to have extra life or a double jump in case you can't complete the level.", "Random Hint");
                            break;
                        case 17:
                            MessageBox.Show("Depending on a level, you'll get certain amount of coins to spend in shop.", "Random Hint");
                            break;
                    }
                };
            }
        }

        // frames time / game loop
        public void FPS_Timer_Tick(object sender, EventArgs e)
        {
            // code created controls are checked here
            controlLoop();

            // call a method that controls player movements
            MovePlayer();

            // Gravity control
            DoGravity();

            // check if player touches the platform
            PlayerPlatformCollision();
            
            // check if player touches the platform that are actually walls
            PlayerPlatformWallsCollision();

            // Screen Size/boundary Control
            ScreenSizeLimit();

        }

        public int ticksSec = 0;
        public int ticksMin = 0;
        public void Stopwatch_Secs_Tick(object sender, EventArgs e)
        {
            // as program timer ticks, so should the seconds tick to a form
            ticksSec++;

            // keep adding +1 to a sec label every second
            lbl_time_secs.Text = "0" + Convert.ToString(ticksSec);

            // add +1 to a min label every 60 seconds
            lbl_time_min.Text = "0" + Convert.ToString(ticksMin) + ":";

            // if double digits occur, remove the '0' that displayed a double digit
            if (ticksSec >= 10)
            {
                lbl_time_secs.Text = Convert.ToString(ticksSec);
            }

            // if double digits occur, remove the '0' that displayed a double digit
            if (ticksMin >= 10)
            {
                lbl_time_min.Text = Convert.ToString(ticksMin) + ":";
            }

            // if there's 60 seconds
            if (ticksSec == 60)
            {
                // restart seconds timer
                ticksSec = 0;

                // add +1 to a min label every 60 seconds
                ticksMin += 1;
            }

            // if there's 60 minutes / 1 hour
            if (ticksMin == 59)
            {
                MessageBox.Show("Level is restarting, because the timer exceeded the limit.");
                RestartLevel(isLevel, 0);
            }
        }

        // if any certain key is pressed
        private void TheGame_KeyDown(object sender, KeyEventArgs e)
        {
            // key 'Left'
            if (e.KeyCode == Keys.Left)
            {
                blnKeyLeft = true;
            }
            
            // key 'Right'
            if (e.KeyCode == Keys.Right)
            {
                blnKeyRight = true;
            }

            // key 'Up'
            if (e.KeyCode == Keys.Up)
            {
                blnKeyUp = true;

                // if Double Jump was bought AND jump key was pressed
                if (isDouble && blnKeyUp)
                {
                    // change default maximum available jumps into 2 / allow double jump
                    intMaxJump = 2;

                    // add a jump to player's amount
                    intPlayerJump++;
                    
                    // if player's jump amount is less than available jump amount, let him have jumps
                    if (intPlayerJump <= intMaxJump)
                    {
                        // make the program think the player is standing on a platform
                        blnOnPlatform = true;
                        // set the velocity on y-axis to 0 (avoid high velocity bug)
                        yVel = 0;
                    }
                }

            }
            
            // key 'Down'
            if (e.KeyCode == Keys.Down)
            {
                blnKeyDown = true;
            }

            // key 'E'
            if (e.KeyCode == Keys.E)
            {
                blnInteractKey = true;
            }
            
            // key 'R'
            if (e.KeyCode == Keys.R)
            {
                // stop the game for a moment
                FPS_Timer.Stop();

                // if user decided to restart
                if (MessageBox.Show("Restart?", "Are you sure?", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    RestartLevel(isLevel, VarTimeLoad);
                }
                // otherwise, continue the game
                else
                {
                    // resume the game loop
                    FPS_Timer.Start();
                    
                    // disable booleans below to avoid automatic/unexpected movement
                    blnKeyLeft = false;
                    blnKeyRight = false;
                    blnKeyUp = false;
                    blnKeyDown = false;
                }
            }

            // key 'ESC'
            if (e.KeyCode == Keys.Escape)
            {
                // call the method for pause menu first, then make the boolean true to avoid bug
                PauseLevel();
                blnInPause = true;
            }
        }

        // If a certain key was pressed then let go, stop increasing player movement
        private void TheGame_KeyUp(object sender, KeyEventArgs e)
        {
            // key 'Left'
            if (e.KeyCode == Keys.Left)
            {
                blnKeyLeft = false;
            }

            // key 'Right'
            if (e.KeyCode == Keys.Right)
            {
                blnKeyRight = false;
            }

            // key 'Up'
            if (e.KeyCode == Keys.Up)
            {
                blnKeyUp = false;

            }
            
            // key 'Down'
            if (e.KeyCode == Keys.Down)
            {
                blnKeyDown = false;
                
            }
            
            // key 'E'
            if (e.KeyCode == Keys.E)
            {
                blnInteractKey = false;
                
            }
        }

        // on form closing event
        private void TheGame_FormClosing(object sender, FormClosingEventArgs e)
        {

            // unhide 'MainMenu' form after this form is closed
            FormProvider.MainMenu_Form.Visible = true;


            // if music was playing / not empty
            if (FormProvider.MainMenu_Form.m_MusicPlayer != null)
            {
                FormProvider.MainMenu_Form.m_MusicPlayer.Stop();
                FormProvider.MainMenu_Form.m_MusicPlayer = null;
            }

        }

        // while this form is starting up
        private void TheGame_Load(object sender, EventArgs e)
        {
            string res_Achs_filepath = "AchievementFile.txt";
            string filetext;

            filetext = File.ReadAllText(res_Achs_filepath);


            // if achievement was obtained in the past
            if (filetext.Contains("AchievementOne = 1"))
            {
                A1_Obtained = true;
                AchievementCheck();
            }
            else
            {
                A1_Obtained = false;
            }
            
            // if achievement was obtained in the past
            if (filetext.Contains("AchievementTwo = 1"))
            {
                A2_Obtained = true;
                AchievementCheck();
            }
            else
            {
                A2_Obtained = false;
            }
        }

    }
}
