using System;

namespace LabirynthGame
{
    class LabirynthTest
    {
        static void Main()
        {
            //Labirynth test = new Labirynth();
            //test.PlayGame();

            IController keyboard = new KeyboardController();
            IRenderer renderer = new ConsoleRenderer(7);
            Player player = new Player('*', 3, 3);
            Engine engine = new Engine(player, renderer, keyboard);
            engine.StartGame();  
        }
    }
}