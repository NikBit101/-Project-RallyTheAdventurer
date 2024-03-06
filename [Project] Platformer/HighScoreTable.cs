using System.Collections.Generic;
using System.Windows.Forms;
//using Microsoft.VisualBasic;
//using Microsoft.VisualBasic.CompilerServices;

namespace _Project__Platformer
{
    public class HighScoreTable
    {
        public class HighScoreClass
        {
            public string Name { get; set; }
            public int Score { get; set; }
        }

        private const int MaxEntries = 5;
        private List<HighScoreClass> HighScores;
        private string strPath = "";

        public List<HighScoreClass> GetHighScores
        {
            get
            {
                return HighScores;
            }
        }

        public void ShowHighScores(ref RichTextBox TxtBox)
        {
            // Show the entire list of highscores in the given GUI control.
            TxtBox.Text = "";
            foreach (var HighScore in HighScores)
                TxtBox.Text += Strings.Format(HighScore.Score, "000000") + Constants.vbTab + HighScore.Name + Constants.vbCrLf;
        }

        private void InitTable()
        {
            // Initialise default scores.  These must be in the correct order as the list is not sorted.
            HighScores = null; // dispose of the existing highscores.
            HighScores = new List<HighScoreClass>() { new HighScoreClass() { Name = "Jane", Score = 1038 }, new HighScoreClass() { Name = "Chris", Score = 999 }, new HighScoreClass() { Name = "Whisky", Score = 400 }, new HighScoreClass() { Name = "Hamish", Score = 25 }, new HighScoreClass() { Name = "Zoe", Score = 1 } };
        }


        // Constructor
        public HighScoreTable(ref string newPath)
        {
            strPath = newPath;
            HighScores = new List<HighScoreClass>();
            LoadTable();
        }

        public object IsThisAHighScore(int newScore)
        {
            if (HighScores[HighScores.Count - 1].Score < newScore)
            {
                // The lowest highscore is less than the newscore.
                return true;
            }

            return false;
        }

        public void InsertNewHighScore(int intScore, ref string strname)
        {
            if (HighScores.Count < MaxEntries)
            {
                // There are no entries on the highscore, just add this one and bug out.
                // Create a new entry
                var newEntry = new HighScoreClass() { Name = strname, Score = intScore };

                // Insert the new entry above the one we found that has a lower score.
                HighScores.Add(newEntry);
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
                    SaveTable();
                    return;
                }
            }
        }

        private void LoadTable()
        {
            string[] strLine;
            System.IO.StreamReader file;
            file = My.MyProject.Computer.FileSystem.OpenTextFileReader(strPath);
            while (!file.EndOfStream)
            {
                strLine = file.ReadLine().Split(',');
                InsertNewHighScore(Conversions.ToInteger(strLine[0]), ref strLine[1]);
            }

            file.Close();
            InitTable();
        }

        private void SaveTable()
        {
           
            System.IO.StreamWriter file;
            file = My.MyProject.Computer.FileSystem.OpenTextFileWriter(strPath, false);
            foreach (var HighScore in HighScores)
                file.WriteLine(HighScore.Score.ToString() + "," + HighScore.Name);
            file.Close();
            return;
        
        }
    }
}