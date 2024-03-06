using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace _Project__Platformer
{
    public partial class Stats : Form
    {
        // Getter & setter to uncover the existing 'MainMenu' form
        public Form StatFormRef { get; set; } 

        // maximum available name slots
        private const int MaxNames = 16;

        // store name slots into this array
        private Label[] names_array = new Label[MaxNames + 1];

        // invoke a 'file reader' class
        private _Project__Platformer.StatsLoad HighScore;

        public string strName;

        public Stats()
        {
            InitializeComponent();

            // read highscores file
            string argnewPath = "HScores.txt";
            HighScore = new StatsLoad(ref argnewPath);

            // show high scores in a textbox
            var argTxtBox = this.textBox1;
            HighScore.ShowHighScores(ref argTxtBox);
            this.textBox1 = argTxtBox;

            /* store each name slot into an array
            names_array[0] = name1;
            names_array[1] = name2;
            names_array[2] = name3;
            names_array[3] = name4;
            names_array[4] = name5;
            names_array[5] = name6;
            names_array[6] = name7;
            names_array[7] = name8;
            names_array[8] = name9;
            names_array[9] = name10;
            names_array[10] = name11;
            names_array[11] = name12;
            names_array[12] = name13;
            names_array[13] = name14;
            names_array[14] = name15;
            names_array[15] = name16;
            */
        }

        // perform operations for name slots here
        public void DisplayName(string TB_name)
        {
            // loop through the array
            for (int i = 0; i < MaxNames; i++)
            {
                // if name slot is empty
                if (names_array[i].Text == "")
                {
                    // store the name into that slot
                    names_array[i].Text = TB_name;

                    // report back success message
                    strName = TB_name;
                    MessageBox.Show("Your name was succesfully stored, " + strName + "!");

                    // exit the loop once the name was stored (avoid duplicated names bug)
                    break;

                }
                // if the name is same
                else if (names_array[i].Text == TB_name)
                {
                    MessageBox.Show("This name is already recorded in statistics.");
                    
                    break;
                }
                // otherwise, name slot is already taken
                else
                {
                    MessageBox.Show("Name's already taken.");

                    continue;
                }
            }
        }

        private void Stats_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormProvider.MainMenu_Form.Show();
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
