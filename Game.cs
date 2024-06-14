using System;
using System.Threading;

namespace pac
{
    /* The Game class in C# contains properties and methods for managing a game with a maze, Pacman,
    ghosts, score tracking, and game state. */
    class Game
    {
        private Maze maze;
        private Pacman pacman;
        private Ghost[] ghosts;
        private int score = 0;
        private int highScore = 0;
        private bool gameRunning;
        private Thread gameThread;

        /* The `public Game()` constructor in the `Game` class is initializing a new instance of the
        `Maze` class and assigning it to the private `maze` field within the `Game` class. This
        means that every time a new `Game` object is created, it will also create a new `Maze`
        object for that game instance. */
        /* The code you provided is a C# implementation of a simple Pacman game. Here's a breakdown of
        what the code is doing: */
        public Game()
        {
            maze = new Maze();
        }

        public void Run()
        {
            HighScoreManager.LoadHighScoreFromFile();
            highScore = HighScoreManager.GetHighScore();

            while (true)
            {
                DrawMenu();
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
                        continue;
                    default:
                        Console.WriteLine("Are you sure you want to leave?");
                        Console.WriteLine("Press any key to exit...");
                        Console.ReadKey();
                        return;
                }

                if (gameRunning)
                {
                    InitializeGame();
                    gameThread = new Thread(GameLoop);
                    gameThread.Start();

                    while (gameRunning)
                    {
                        Console.Clear();
                        maze.Draw();
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
                        }
                        else if (IsGameWon())
                        {
                            gameRunning = false;
                            Console.WriteLine("You have won!");
                        }
                    }

                    gameThread.Join();
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

        private void GameLoop()
        {
            while (gameRunning)
            {
                Console.Clear();
                maze.Draw();
                pacman.draw();
                foreach (var ghost in ghosts)
                {
                    ghost.draw();
                    ghost.MoveGhost();
                }

                if (IsGameOver(pacman.GetX(), pacman.GetY()))
                {
                    gameRunning = false;
                }
                else if (IsGameWon())
                {
                    gameRunning = false;
                    Console.WriteLine("You have won!");
                }

                Thread.Sleep(150); // Control the game loop speed
            }
        }

        private void InitializeGame()
        {
            maze = new Maze();
            pacman = new Pacman(1, 1, maze.GetLayout());
            ghosts = new Ghost[]
            {
                new Ghost(10, 5, maze.GetLayout()),
                new Ghost(5, 7, maze.GetLayout())
            };
            score = 0;
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
            return score == maze.CountDots();
        }
    }
}
