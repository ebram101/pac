using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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



        /// De UpdateHighScore-functie werkt de hoogste score bij als de nieuwe score hoger is en slaat
        /// deze op in een bestand.

        //< name="newScore">De parameter `newScore` is een geheel getal dat de score
        // vertegenwoordigt die moet worden gecontroleerd en mogelijk moet worden bijgewerkt als de
        // nieuwe hoogste score.
        public static void UpdateHighScore(int newScore)
        {
            if (newScore > highScore)
            {
                highScore = newScore;
                SaveHighScoreToFile();
            }
        }

        /// De functie `SaveHighScoreToFile` slaat de hoge score op in een bestand in C#.

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


        /// De functie 'LoadHighScoreFromFile' leest de hoogste score uit een bestand en werkt de
        /// variabele 'highScore' bij als het bestand bestaat en de score kan worden geparseerd als een
        /// geheel getal.

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
