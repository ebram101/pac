using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* This C# code defines a class named `Pacman` within the `pac` namespace. The `Pacman` class inherits
from another class named `Entity`. Here is a breakdown of what the `Pacman` class does: */
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

    
        /// The function `Move` takes a `ConsoleKey` input and updates the position based on arrow key
        /// inputs.
        
        /// The `ConsoleKey` enumeration represents keys on the keyboard that
        /// can be pressed. In the provided code snippet, the `Move` method takes a `ConsoleKey`
        /// parameter named `key`, which is used to determine the direction in which an object should
        /// move. The method adjusts the `newX`
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

          /* This block of code is part of the `Move` method in the `Pacman` class. It is responsible
          for handling the movement logic of the Pacman character within the maze. Here's a
          breakdown of what it does: */
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

       
        /// The GetScore function in C# returns the value of the score variable.
  
        public int GetScore() => score;
    }
}
