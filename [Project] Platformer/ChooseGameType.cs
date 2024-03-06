using System;
using System.IO;
using System.Reflection;
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
    public partial class ChooseGameType : Form
    {

        public ChooseGameType()
        {
            InitializeComponent();

            // don't let the user change form's size
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

        }

        private void btn_Back_Click(object sender, EventArgs e)
        {
            this.Close();
            FormProvider.MainMenu_Form.Show();
        }

        private void btn_NormalMode_Click(object sender, EventArgs e)
        {
            this.Close();
            FormProvider.SML_Form.Show();
        }

        private void ChooseGameType_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }

        private void btn_BonusMode_Click(object sender, EventArgs e)
        {
            this.Close();
            FormProvider.BL_Form.Show();
        }

        public void ReadFile()
        {
            var file = Properties.Resources.SaveFile;

            if (file.Contains("LevelTen = 1"))
            {
                btn_BonusMode.Enabled = true;
            }
        }
       
        private void ChooseGameType_Load(object sender, EventArgs e)
        {
            ReadFile();
        }
    }
}
