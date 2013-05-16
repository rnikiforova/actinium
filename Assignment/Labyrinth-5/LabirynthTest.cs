using System;

namespace LabirynthGame
{
    class LabirynthTest
    {
        static void Main()
        {
            //Labirynth test = new Labirynth();
            //test.PlayGame();

            
            ScoreBoard scoreBoard = new ScoreBoard();
            
            while (true)
            {
                IController keyboard = new KeyboardController();
                IRenderer renderer = new ConsoleRenderer();
                Player player = new Player('0', 3, 3);
            
                Engine engine = new Engine(player, renderer, keyboard, scoreBoard);                
            
                engine.StartGame();
            }
            
        }
    }
}