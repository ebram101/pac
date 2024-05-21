using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pac
{
    public class Ghost
    {
        private int X;
        private int Y;
        private char[,] maze;
        private static readonly Random rnd = new Random();

        public Ghost(int x, int y, char[,] maze)
        {
            this.X = x;
            this.Y = y;
            this.maze = maze;
        }

        public void Draw()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write('G');
        }

        public void MoveGhost()
        {
            int direction = rnd.Next(1, 5);
            int newX = X;
            int newY = Y;

            switch (direction)
            {
                case 1:
                    newX++;
                    break;
                case 2:
                    newY++;
                    break;
                case 3:
                    newX--;
                    break;
                case 4:
                    newY--;
                    break;
            }

            if (IsValidMove(newX, newY))
            {
                X = newX;
                Y = newY;
            }
        }

        private bool IsValidMove(int newX, int newY)
        {
            return newX >= 0 && newX < maze.GetLength(1) && newY >= 0 && newY < maze.GetLength(0) && maze[newY, newX] != '#';
        }

        public int GetX() => X;
        public int GetY() => Y;
    }
}
