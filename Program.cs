using System;

namespace pac
{
    class Program
    {
        ///
        /// The Main function creates an instance of the Game class and calls its Run method.
        
        /// param name="args">The `args` parameter in the `Main` method is an array of strings that
        /// contains the command-line arguments passed to the program when it is executed. These
        /// arguments can be used to provide input or configuration settings to the program at
        /// runtime.
        static void Main(string[] args)
        {
            Game game = new Game();
            game.Run();
        }
    }
}
