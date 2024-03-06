using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _Project__Platformer
{
    public class TutFile
    {
        // tutorial file
        public string res_Tut_filepath = "TutEnabled.txt";
        string t_filetext;

        public bool TisComplete;

        // method for checking a tutorial progress
        public void Tut_filecheck()
        {
            // read contents from the file
            t_filetext = File.ReadAllText(res_Tut_filepath);

            // if tutorial is not completed
            if (t_filetext.Contains("0"))
            {
                TisComplete = false;
            }
            else
            {
                TisComplete = true;
            }

        }
    }
}
