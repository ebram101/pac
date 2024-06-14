using System;

namespace pac
{
  /* The Maze class in C# contains a 2D char array representing a maze layout and includes a method to
  reset the layout. */
    class Maze
    {
        private char[,] layout;

        public Maze()
        {
            Reset();
        }

        public char[,] GetLayout()
        {
            return layout;
        }


    /// The Reset function initializes a 2D char array with a specific layout pattern.

        public void Reset()
        {
            layout = new char[,]
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

 
        /// The Draw function iterates through a 2D array and prints its contents to the console.
      
        public void Draw()
        {
            for (int i = 0; i < layout.GetLength(0); i++)
            {
                for (int j = 0; j < layout.GetLength(1); j++)
                {
                    Console.SetCursorPosition(j, i);
                    Console.Write(layout[i, j]);
                }
                
            }
            Console.SetCursorPosition(0, layout.GetLength(0) + 2);
            Console.WriteLine();
        }

       /* The `CountDots` method in the `Maze` class is responsible for counting the number of dots
       ('.') present in the maze layout. Here's a breakdown of how it works: */
        public int CountDots()
        {
            int dotCount = 0;
            for (int i = 0; i < layout.GetLength(0); i++)
            {
                for (int j = 0; j < layout.GetLength(1); j++)
                {
                    if (layout[i, j] == '.')
                    {
                        dotCount++;
                    }
                }
            }
            /* `return dotCount;` is a statement in the `CountDots` method of the `Maze` class. This
            statement is used to return the value of the variable `dotCount` back to the caller of
            the method. In this case, `dotCount` represents the number of dots ('.') present in the
            maze layout. So, when `return dotCount;` is executed, the method will return the total
            count of dots in the maze to the code that called the `CountDots` method. */
            return dotCount;
        }
    }
}
