using System.Runtime.InteropServices.JavaScript;

namespace pac
{ 
class Program
{
    static char[,] maze = {
            {'#','#','#','#','#','#','#','#','#','#','#','#'},
            {'#','.','.','.','.','.','.','.','.','.','.','#'},
            {'#','.','#','#','#','#','.','#','#','#','.','#'},
            {'#','.','#',' ',' ',' ',' ','#',' ','#','.','#'},
            {'#','.','#','#','#','#','.','#','#','#','.','#'},
            {'#','.','.','.','.','.','.','.','.','#','.','#'},
            {'#','#','#','#',' ','.','#','#','.','#','.','#'},
            {'#','.','.','#',' ','.','#','#','.','#','.','#'},
            {'#','.','.','#',' ','.','#','.','.','.','.','#'},
            {'#','.','.','.','.','.','.','#','#','#','#','#'},
            {'#','#','#','#','#','#','#','#','#','#','#','#'},
        };

    static int score = 0;
    static int highScore = 0;

    static int[][] ghostPositions = new int[][]
    {
            new int[] {10, 5}, // Ghost 1 initial position
            new int[] {5, 7}   // Ghost 2 initial position
    };

    static void Main(string[] args)
    {
        bool gameRunning = false;
        ConsoleKeyInfo keyInfo;

        Pacaman pacman = new Pacaman(1, 1, maze);
        Ghost[] ghosts = new Ghost[]
        {
                new Ghost(10, 5, maze),
                new Ghost(5, 7, maze)
        };

        do
        {
            DrawMenu();

            bool exitRequest = false;
            char choice = Console.ReadKey().KeyChar;

            switch (choice)
            {
                case '1':
                    gameRunning = true;
                    break;
                case '2':
                    Console.WriteLine($"High Score: {highScore}");
                    Console.WriteLine("Press any key to return...");
                    Console.ReadKey();
                    break;
                default:
                    exitRequest = true;
                    Console.WriteLine("Are you sure you want to leave?");
                    Console.WriteLine("Press any key to exit...");
                    Console.ReadKey();
                    break;
            }

            if (exitRequest)
            {
                break;
            }

            if (gameRunning)
            {
                InitializeGame();

                do
                {
                    Console.Clear();
                    DrawMaze();
                    pacman.draw();
                    foreach (var ghost in ghosts)
                    {
                        ghost.Draw();
                        ghost.MoveGhost();
                    }
                    keyInfo = Console.ReadKey(true);

                    if (keyInfo.Key == ConsoleKey.Escape)
                        break;
                    pacman.Move(keyInfo.Key);
                    score = pacman.GetScore();

                    if (IsGameOver(pacman.GetX(), pacman.GetY()))
                    {
                        gameRunning = false;
                        break;
                    }
                    else if (IsGameWon())
                    {
                        gameRunning = false;
                        Console.WriteLine("You have won!");
                        break;
                    }
                } while (gameRunning);

                Console.Clear();
                if (IsGameWon())
                {
                    Console.WriteLine("Congratulations! You won!");
                }
                else
                {
                    Console.WriteLine("Game over! You touched a ghost!");
                }

                if (IsGameOver(pacman.GetX(), pacman.GetY()) || IsGameWon())
                {
                    if (score > highScore)
                    {
                        highScore = score;
                    }
                }

                Console.WriteLine($"Your Score: {score}");
                Console.WriteLine("Press any key to return to the main menu...");
                Console.ReadKey();
            }
        } while (true);
    }

    static void DrawMenu()
    {
        Console.WriteLine(String.Format("{0," + (Console.WindowWidth / 2 + 7) + "}", "  _______  "));
        Console.WriteLine(String.Format("{0," + (Console.WindowWidth / 2 + 7) + "}", " /  ___  \\ "));
        Console.WriteLine(String.Format("{0," + (Console.WindowWidth / 2 + 7) + "}", "| /     \\ |"));
        Console.WriteLine(String.Format("{0," + (Console.WindowWidth / 2 + 7) + "}", "| |     (_|"));
        Console.WriteLine(String.Format("{0," + (Console.WindowWidth / 2 + 7) + "}", "| \\______/ "));
        Console.WriteLine(String.Format("{0," + (Console.WindowWidth / 2 + 7) + "}", " \\_______/  "));
        Console.WriteLine();

        Console.WriteLine(String.Format("{0," + (Console.WindowWidth / 2 + 7) + "}", "Welcome to Pacman Game!"));
        Console.WriteLine(String.Format("{0," + (Console.WindowWidth / 2 + 7) + "}", "press: 1. Start Game"));
        Console.WriteLine(String.Format("{0," + (Console.WindowWidth / 2 + 7) + "}", "press: 2. High Score"));
        Console.WriteLine(String.Format("{0," + (Console.WindowWidth / 2 + 1) + "}", "press: 3. Exit"));

    }

    /// De InitializeGame-functie zet het doolhof van het spel op en initialiseert de positie en score
    /// van de speler. <summary>
    // de spelere Als hij dood gaat door ghost begint het spel vanaf begin met de maze
    // ik had eerst dat als hij dood ging dat maze niet zo refreshen maar dat  is nu wel zo


    static void InitializeGame()
    {

        maze = new char[,]
        {
        {'#','#','#','#','#','#','#','#','#','#','#','#'},
        {'#','.','.','.','.','.','.','.','.','.','.','#'},
        {'#','.','#','#','#','#','.','#','#','#','.','#'},
        {'#','.','#',' ',' ',' ',' ','#',' ','#','.','#'},
        {'#','.','#','#','#','#','.','#','#','#','.','#'},
        {'#','.','.','.','.','.','.','.','.','#','.','#'},
        {'#','#','#','#',' ','.','#','#','.','#','.','#'},
        {'#','.','.','#',' ','.','#','#','.','#','.','#'},
        {'#','.','.','#',' ','.','#','.','.','.','.','#'},
        {'#','.','.','.','.','.','.','#','#','#','#','#'},
        {'#','#','#','#','#','#','#','#','#','#','#','#'}
        };

    }







    static void DrawMaze()
    {
        for (int y = 0; y < maze.GetLength(0); y++)
        {
            for (int x = 0; x < maze.GetLength(1); x++)
            {
                Console.SetCursorPosition(x, y);
                Console.Write(maze[y, x]);
            }
        }

        Console.WriteLine($"\nScore:{score}");
    }

    /// De DrawPacman-functie stelt de cursorpositie in de console in en schrijft het teken 'C'.
    /* static void DrawPacmann()
     {
         // Calculate the position of Pacman relative to the centered maze
         int pacmanCenterX = pacmanX + (Console.WindowWidth - maze.GetLength(1)) / 2;
         int pacmanCenterY = pacmanY;

         Console.SetCursorPosition(pacmanCenterX, pacmanCenterY);
         Console.Write('C');
     }*/


    /// De DrawGhosts-functie doorloopt een lijst met spookcoördinaten en drukt op elke positie op de
    /// console een 'G'-teken af.
    //Ik kreeg het niet voor elkaar om de ghost zelf te laten bewegen , dus heb ik hiervoor de coördinaten meegeven.

    /*static void DrawGhosts()
    {
        // Calculate the position of each Ghost relative to the centered maze
        int mazeLeftPadding = (Console.WindowWidth - maze.GetLength(1)) / 2;

        foreach (var ghost in ghosts)
        {
            int ghostCenterX = ghost[0] + mazeLeftPadding;
            int ghostCenterY = ghost[1];

            Console.SetCursorPosition(ghostCenterX, ghostCenterY);
            Console.Write("G");
        }
    }*/





    /// De functie MoveGhosts verplaatst geesten willekeurig in een doolhof terwijl ze obstakels
    /// ontwijken.

    /*static void MoveGhosts()
    {
        Random rnd = new Random();

        foreach (var ghost in ghosts)
        {
            int direction = rnd.Next(1, 5);

            int newGhostX = ghost[0];
            int newGhostY = ghost[1];


            switch (direction)
            {
                case 1:
                    newGhostX++;
                    break;
                case 2:
                    newGhostY++;
                    break;
                case 3:
                    newGhostX--;
                    break;
                case 4:
                    newGhostY--;
                    break;
            }
            if (newGhostX >= 0 && newGhostX < maze.GetLength(1) && newGhostY >= 0 && newGhostY < maze.GetLength(0) && maze[newGhostY, newGhostX] != '#')
            {
                // Update the position of the ghost
                ghost[0] = newGhostX;
                ghost[1] = newGhostY;
            }
        }

    }
*/



    /// De functie 'IsGameOver' controleert of de positie van het Pacman-personage overlapt met de
    /// positie van een geest in een spel.

    /// <returns>
    /// De functie IsGameOver() retourneert een Booleaanse waarde: waar als de positie van de pacman
    /// overeenkomt met een van de posities van de geest, en anders onwaar.
    /// </returns>
    static bool IsGameOver(int pacmanX, int pacmanY)
    {
        foreach (var ghost in ghostPositions)
        {
            if (pacmanX == ghost[0] && pacmanY == ghost[1])
            {
                return true;
            }
        }
        return false;
    }



    /// De functie IsGameWon() retourneert true als de score gelijk is aan 48.
    /// want er zijn 48 dots(munten) in de game


    /// <returns>
    /// De functie IsGameWon() retourneert een Booleaanse waarde die aangeeft of het spel gewonnen is
    /// of niet. Het retourneert 'true' als de 'score' gelijk is aan 48, en anders 'false'.
    /// </returns>
    static bool IsGameWon()
    {
        return score == 48;


    }

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
}