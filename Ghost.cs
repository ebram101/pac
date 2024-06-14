    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace pac
{/* The Ghost class represents a ghost entity in a maze game with a draw method to display it on
    the console. */

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


        /// The MoveGhost function randomly moves a ghost character in a maze while ensuring the move is
        /// valid based on the IsValidMove function.

        /// The MoveGhost function in C# is used to move a ghost character in a game.

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


        /// The IsValidMove function checks if a given position is within the bounds of a maze and is
        /// not a wall ('#').

        /// The `newX` parameter represents the new x-coordinate of a potential
        /// move in a maze.
        /// The 'newy' represents the new y-coordinate of a potential move in a maze.

        /// The `IsValidMove` method is returning a boolean value, which indicates whether the move
        /// to the new coordinates `(newX, newY)` is valid within the constraints of the maze.

        private bool IsValidMove(int newX, int newY)
            {
                return newX >= 0 && newX < maze.GetLength(1) && newY >= 0 && newY < maze.GetLength(0) && maze[newY, newX] != '#';
            }
        }
    }
