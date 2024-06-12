using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pac
{
    public class Pacman : Entity
    {
        private int score;

        public Pacman(int x, int y, char[,] maze) : base(x, y, maze)
        {
            this.score = 0;
        }

        public override void draw()
        {
            Console.SetCursorPosition(x, y);
            Console.Write('C');
        }

        public virtual void Move(ConsoleKey key)
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

            if (newX >= 0 && newX < maze.GetLength(1) && newY >= 0 && newY < maze.GetLength(0))
            {
                if (maze[newY, newX] == '.')
                {
                    score++; // Increment the score
                    maze[newY, newX] = ' '; // Remove the dot from the maze
                }

                if (maze[newY, newX] != '#')
                {
                    x = newX;
                    y = newY;
                }
            }
           
        }

        public int GetScore() => score;
    }
}
