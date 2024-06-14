using System;
using System.IO;
using System.Threading;

namespace pac
{
    /* The HighScoreManager class in C# manages the high score, updates it if a new score is higher, and
    saves it to a file. */
    class HighScoreManager
    {
        private static int highScore = 0;
        private static string highScoreFilePath = "highscore.txt";

        public static int GetHighScore()
        {
            return highScore;
        }


        /// The UpdateHighScore function in C# updates the high score if the new score is higher and
        /// saves it to a file.

        /// The `newScore` parameter is an integer value representing the score
        /// that needs to be checked and potentially updated as the new high score.
        public static void UpdateHighScore(int newScore)
        {
            if (newScore > highScore)
            {
                highScore = newScore;
                SaveHighScoreToFile();
            }
        }


        /// The function `SaveHighScoreToFile` saves the high score to a file in C#.

        private static void SaveHighScoreToFile()
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(highScoreFilePath))
                {
                    writer.WriteLine(highScore);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error saving high score: " + ex.Message);
            }
        }

        public static  void LoadHighScoreFromFile()
        {
            try
            {
                if (File.Exists(highScoreFilePath))
                {
                    using (StreamReader reader = new StreamReader(highScoreFilePath))
                    {
                        string scoreStr = reader.ReadLine();
                        if (int.TryParse(scoreStr, out int loadedScore))
                        {
                            highScore = loadedScore;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading high score: " + ex.Message);
            }
        }

        
       
    }
}
