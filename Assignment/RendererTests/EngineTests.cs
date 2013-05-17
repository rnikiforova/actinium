using System;
using LabirynthGame;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RendererTests
{
    [TestClass]
    public class EngineTests
    {
        [TestMethod]
        public void InitEngineTest()
        {
            Player player = new Player('*', 3, 3);
            IRenderer renderer = new ConsoleRenderer();
            IController controller = new KeyboardController();
            ScoreBoard scoreBoard = new ScoreBoard();

            Engine engine = new Engine(player, renderer, controller, scoreBoard);
        }


        //[TestMethod]
        //public void EngineTestStart()
        //{
        //    using (StringReader stringReader = new StringReader("exit"))
        //    {
        //        Console.SetIn(stringReader);
        //        StringBuilder stringBuilder = new StringBuilder();
        //        using (StringWriter stringWriter = new StringWriter(stringBuilder))
        //        {
        //            Console.SetOut(stringWriter);

        //            Player player = new Player('*', 3, 3);
        //            IRenderer renderer = new ConsoleRenderer();
        //            IController controller = new KeyboardController();
        //            ScoreBoard scoreBoard = new ScoreBoard();

        //            Engine engine = new Engine(player, renderer, controller, scoreBoard);

        //            engine.StartGame();

        //            Assert.AreEqual("Invalid input!\r\n**Press a key to continue**", stringWriter.ToString());
        //        }
        //    }
        //}
    }
}
