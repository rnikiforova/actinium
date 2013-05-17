using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LabirynthGame;
using System.Collections.Generic;

namespace RendererTests
{
    [TestClass]
    public class ScoreBoardTest
    {
        [TestMethod]
        public void ToStringTestOutputCorrect()
        {
           
            Player pl = new Player('*', 5, 5);
            pl.Name = "Al";
            ScoreBoard board = new ScoreBoard();
            board.Players.Add(pl);
            string result = board.ToString();
            string expected = "1 Al -->0";
            Assert.AreEqual(expected, result);
        }
    }
}
