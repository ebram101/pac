using System;

namespace pac
{
    class Game
    {
        private char[,] maze = {
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

        private Pacman pacman;
        private Ghost[] ghosts;
        private int score = 0;
        private int highScore = 0;

        public void Run()
        {
            HighScoreManager.LoadHighScoreFromFile();
            highScore = HighScoreManager.GetHighScore();

            while (true)
            {
                bool gameRunning = false;
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

                    while (gameRunning)
                    {
                        Console.Clear();
                        DrawMaze();
                        pacman.draw();
                        foreach (var ghost in ghosts)
                        {
                            ghost.draw();
                            ghost.MoveGhost();
                        }

                        ConsoleKeyInfo keyInfo = Console.ReadKey(true);

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
                    }

                    Console.Clear();
                    if (IsGameWon())
                    {
                        Console.WriteLine("Congratulations! You won!");
                    }
                    else
                    {
                        Console.WriteLine("Game over! You touched a ghost!");
                    }

                    if (score > highScore)
                    {
                        highScore = score;
                        HighScoreManager.UpdateHighScore(score);
                    }

                    Console.WriteLine($"Your Score: {score}");
                    Console.WriteLine("Press any key to return to the main menu...");
                    Console.ReadKey();
                }
            }
        }

        private void InitializeGame()
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
            pacman = new Pacman(1, 1, maze);
            ghosts = new Ghost[]
            {
                new Ghost(10, 5, maze),
                new Ghost(5, 7, maze)
            };
            score = 0;
        }

        private void DrawMaze()
        {
            for (int i = 0; i < maze.GetLength(0); i++)
            {
                for (int j = 0; j < maze.GetLength(1); j++)
                {
                    Console.Write(maze[i, j]);
                }
                Console.WriteLine();
            }
            Console.SetCursorPosition(0, maze.GetLength(0) + 2);
            Console.WriteLine($"Score: {score}");
        }

        private void DrawMenu()
        {
            string[] menuItems = new string[]
            {
        "  _______  ",
        " /  ___  \\ ",
        "| /     \\ |",
        "| |     (_|",
        "| \\______/ ",
        " \\_______/  ",
        "",
        "Welcome to Pacman Game!",
        "press: 1. Start Game",
        "press: 2. High Score",
        "press: 3. Exit"
            };

            foreach (string item in menuItems)
            {
                PrintCentered(item);
            }
        }

        static void PrintCentered(string text)
        {
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (text.Length / 2)) + "}", text));
        }

        private bool IsGameOver(int pacmanX, int pacmanY)
        {
            foreach (var ghost in ghosts)
            {
                if (pacmanX == ghost.GetX() && pacmanY == ghost.GetY())
                {
                    return true;
                }
            }
            return false;
        }

        private bool IsGameWon()
        {
            return score == 48;
        }
    }
}
