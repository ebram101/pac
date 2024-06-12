using System;
using System.IO;
using System.Threading;

namespace pac
{
    class HighScoreManager
    {
        private static int highScore = 0;
        private static string highScoreFilePath = "highscore.txt";

        public static int GetHighScore()
        {
            return highScore;
        }

        public static void UpdateHighScore(int newScore)
        {
            if (newScore > highScore)
            {
                highScore = newScore;
                SaveHighScoreToFile();
            }
        }

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

        public static void LoadHighScoreFromFile()
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
