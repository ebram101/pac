    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace pac
    {
        public class Ghost : Entity
        {
            private static readonly Random random = new Random();

            public Ghost(int x, int y, char[,] maze) : base(x, y, maze)
            {
            }

            public override void draw()
            {
                Console.SetCursorPosition(x, y);
                Console.Write('G');
            }

            public void MoveGhost()
            {
                int direction = random.Next(1, 5);
                int newX = x;
                int newY = y;

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
                    x = newX;
                    y = newY;
                }
            }

            private bool IsValidMove(int newX, int newY)
            {
                return newX >= 0 && newX < maze.GetLength(1) && newY >= 0 && newY < maze.GetLength(0) && maze[newY, newX] != '#';
            }
        }
    }
