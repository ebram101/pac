﻿class Maze
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

    public char[,] GetMaze()
    {
        return maze;
    }

    public void DrawMaze(int score)
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
}