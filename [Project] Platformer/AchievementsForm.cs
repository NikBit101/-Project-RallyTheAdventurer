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
    public partial class AchievementsForm : Form
    {
        public AchievementsForm()
        {
            InitializeComponent();

            // don't let the user change form's size
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            // star's background transparency
            pictureboxsix.Controls.Add(pb_AchStar);
            //pb_AchStar.Location = new Point(115, 125);
            pb_AchStar.BackColor = Color.Transparent;
            pb_AchStar.Visible = false;

            // star's background transparency
            pictureboxsix.Controls.Add(pb_AchStar3);
           //pb_AchStar3.Location = new Point(559, 152);
            pb_AchStar3.BackColor = Color.Transparent;
            pb_AchStar3.Visible = false;
            
            // star's background transparency
            pictureboxsix.Controls.Add(pb_AchStar4);
            //pb_AchStar4.Location = new Point(982, 152);
            pb_AchStar4.BackColor = Color.Transparent;
            pb_AchStar4.Visible = false;


            // star's background transparency
            pictureBox2.Controls.Add(pb_AchStar2);
            pb_AchStar2.Location = new Point(225, 120);
            pb_AchStar2.BackColor = Color.Transparent;
            pb_AchStar2.Visible = false;


            // star's background transparency
            pictureBox2.Controls.Add(pb_AchStar5);
            pb_AchStar5.Location = new Point(650, 120);
            pb_AchStar5.BackColor = Color.Transparent;
            pb_AchStar5.Visible = false;
        }


        private int intTime;

        public string res_Achs_filepath = "AchievementFile.txt";
        private void AchievementsForm_Load(object sender, EventArgs e)
        {
            string filetext = File.ReadAllText(res_Achs_filepath);

            // check first achievement (1st trophy)
            if (filetext.Contains("AchievementOne = 0")) 
            {
                pb_AchStar.Enabled = false;
                pb_AchStar.Visible = false;
            }
            else
            {
                pb_AchStar.Enabled = true;
                pb_AchStar.Visible = true;
            }
            
            // check second achievement (2nd trophy)
            if (filetext.Contains("AchievementTwo = 0")) 
            {
                pb_AchStar2.Enabled = false;
                pb_AchStar2.Visible = false;
            }
            else
            {
                pb_AchStar2.Enabled = true;
                pb_AchStar2.Visible = true;
            }
            
            // check third achievement (Normal mode complete)
            if (filetext.Contains("AchievementThree = 0")) 
            {
                pb_AchStar3.Enabled = false;
                pb_AchStar3.Visible = false;
            }
            else
            {
                pb_AchStar3.Enabled = true;
                pb_AchStar3.Visible = true;
            }
            
            // check fourth achievement (Bonus mode complete)
            if (filetext.Contains("AchievementFour = 0")) 
            {
                pb_AchStar4.Enabled = false;
                pb_AchStar4.Visible = false;
            }
            else
            {
                pb_AchStar4.Enabled = true;
                pb_AchStar4.Visible = true;
            }


            // check if time for completing the game is less than 5 minutes
            string json = Properties.Resources.TimeScore;
            dynamic jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
            intTime = jsonObj["Time"];
            if (intTime > 0 && intTime < 300 && FormProvider.CGT_Form.btn_BonusMode.Enabled)
            {
                pb_AchStar5.Enabled = true;
                pb_AchStar5.Visible = true;
            }
            else
            {
                pb_AchStar5.Enabled = false;
                pb_AchStar5.Visible = false;
            }

            // check if all other achievements were obtained, display final one
            if (pb_AchStar.Visible && 
                pb_AchStar2.Visible && 
                pb_AchStar3.Visible && 
                pb_AchStar4.Visible && 
                pb_AchStar5.Visible)
            {
                pb_AchStar8.Enabled = true;
                pb_AchStar8.Visible = true;
            }
        }
    }
}
