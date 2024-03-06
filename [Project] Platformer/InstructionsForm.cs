using System;
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
    public partial class InstructionsForm : Form
    {
        public InstructionsForm()
        {
            InitializeComponent();
        }

        private void btn_GoBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
