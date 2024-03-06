using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System.Windows.Forms;

namespace _Project__Platformer
{
    public class StatsLoad
    {
        public class HighScoreClass
        {
            public string Name { get; set; }
            public int Score { get; set; }
        }

        public const int MaxEntries = 9;
        int counter = 0;
        private string strPath = "";
        private List<HighScoreClass> HighScores;

        // Constructor
        public StatsLoad(ref string newPath)
        {
            strPath = newPath;
            HighScores = new List<HighScoreClass>();
            ReadFileLine();
        }

        public void ShowHighScores(ref TextBox TxtBox)
        {
            // Show the entire list of highscores in the given GUI control.
            TxtBox.Text = "";
            foreach (var HighScore in HighScores)
                TxtBox.Text += HighScore.Name + Constants.vbTab + Constants.vbTab + Strings.Format(HighScore.Score, "0000") + Constants.vbCrLf;
        }

        public void ReadFileLine()
        {
            string[] strLine;

            StreamReader file = new StreamReader("HScores.txt");
            while (!file.EndOfStream)
            {
                strLine = file.ReadLine().Split(',');
                NewHighScore(Conversions.ToInteger(strLine[1]), ref strLine[0]);
            }

            file.Close();
            return;
        }

        public void NewHighScore(int intScore, ref string strName)
        {
            if (HighScores.Count < MaxEntries)
            {
                // There are no entries on the highscore, just add this one and bug out.
                // Create a new entry
                var newEntry = new HighScoreClass() { Name = strName, Score = intScore };

                // Insert the new entry above the one we found that has a lower score.
                HighScores.Add(newEntry);
                return;
            }
        }

        //
        public void StoreScore()
        {
            StreamWriter file = new StreamWriter("HScores.txt");
            foreach (var Highscore in HighScores)
                file.WriteLine(Highscore.Name + "," + Highscore.Score.ToString());
            file.Close();
            return;
        }

        public void InsertNewHighScore(ref string strname, int intScore)
        {
            if (HighScores.Count < MaxEntries)
            {
                // There are no entries on the highscore, just add this one and bug out.
                // Create a new entry
                var newEntry = new HighScoreClass() { Name = strname, Score = intScore };

                // Insert the new entry above the one we found that has a lower score.
                HighScores.Add(newEntry);
                StoreScore();
                return;
            }

            // Go through all the existing high scores from the top.
            foreach (var HighScore in HighScores)
            {

                // Found where the new score should be inserted.
                if (HighScore.Score < intScore)
                {

                    // Create a new entry
                    var newEntry = new HighScoreClass() { Name = strname, Score = intScore };

                    // Insert the new entry above the one we found that has a lower score.
                    HighScores.Insert(HighScores.IndexOf(HighScore), newEntry);
                    
                    // Trim the list to the maximum number of entries.  It means lose the bottom one.
                    if (HighScores.Count > MaxEntries)
                    {
                        HighScores.RemoveAt(MaxEntries);
                    }

                    // Save and bug out.
                    StoreScore();
                    return;
                }
            }
        }
    }
}
