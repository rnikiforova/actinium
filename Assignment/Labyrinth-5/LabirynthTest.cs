using System;

namespace LabirynthGame
{
    /// <summary>
    /// Initialize the game
    /// </summary>
    class LabirynthTest
    {
        static void Main()
        {
            Console.WriteLine("Welcome to “Labirinth” game. Please try to escape. Use 'top' to view the top");
            Console.WriteLine("scoreboard, 'restart' to start a new game and 'exit' to quit the game.");

            ScoreBoard scoreBoard = new ScoreBoard();
            while (true)
            {
                IController keyboard = new KeyboardController();
                IRenderer renderer = new ConsoleRenderer();
                Player player = new Player('*', 3, 3);
                Engine engine = new Engine(player, renderer, keyboard, scoreBoard);                
            
                engine.StartGame();
            }
        }
    }
}