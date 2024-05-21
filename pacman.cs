using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pac
{
    public class Pacaman
    {
        protected int x;
        protected int y;
        protected char[,] maze;
        protected int score;

        public Pacaman(int x, int y, char[,] maze)
        {
            this.x = x;
            this.y = y;
            this.maze = maze;
            this.score = 0;
        }

        public virtual void draw()
        {
            Console.SetCursorPosition(x, y);
            Console.Write('C');
        }

        public void Move(ConsoleKey key)
        {
            int newX = x;
            int newY = y;

            switch (key)
            {
                case ConsoleKey.UpArrow:
                case ConsoleKey.W:
                    newY--;
                    break;
                case ConsoleKey.DownArrow:
                case ConsoleKey.S:
                    newY++;
                    break;
                case ConsoleKey.LeftArrow:
                case ConsoleKey.A:
                    newX--;
                    break;
                case ConsoleKey.RightArrow:
                case ConsoleKey.D:
                    newX++;
                    break;
            }

            // Check if the new position is within the bounds of the maze
            if (newX >= 0 && newX < maze.GetLength(1) && newY >= 0 && newY < maze.GetLength(0))
            {
                if (maze[newY, newX] == '.')
                {
                    score++; // Increment the score
                    maze[newY, newX] = ' '; // Remove the dot from the maze
                }

                if (maze[newY, newX] != '#')
                {
                    // Update Pacman's position
                    x = newX;
                    y = newY;
                }
            }
        }


        public int GetScore()
        {
            return score;
        }

        public int GetX()
        {
            return x;
        }

        public int GetY()
        {
            return y;
        }
    }


    class DrawPacman : Pacaman
    {
        public DrawPacman(int x, int y, char[,] maze) : base(x, y, maze)
        {
        }

        public override void draw()
        {
            // Specific implementation for drawing Pacman
            int pacmanCenterX = x + (Console.WindowWidth - maze.GetLength(1)) / 2;
            Console.SetCursorPosition(pacmanCenterX, y);
            Console.Write('C');
        }
    }
}
