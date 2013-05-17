using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LabirynthGame;

namespace RendererTests
{
    [TestClass]
    public class PlayerTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void FreeCellCharTest()
        {
            Player testPlayer = new Player('-', 3, 3);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void BlockedCellCharTest()
        {
            Player testPlayer = new Player('X', 3, 3);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void EmptyCharTest()
        {
            Player testPlayer = new Player('\u0000', 3, 3);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NegativeRowTest()
        {
            Player testPlayer = new Player('*', -3, 2);
            Assert.Fail("Had to throw an exception because of invalid row");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NegativeColTest()
        {
            Player testPlayer = new Player('*', 3, -2);
            Assert.Fail("Had to throw an exception because of invalid col");
        }

        [TestMethod]
        public void UpdateTest()
        {
            Player testPlayer = new Player('*', 3, 3);
            testPlayer.Update(new Coords(2, 2));

            var expected = "2 2";
            var actual = testPlayer.Row + " " + testPlayer.Col;

            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void ResetTest()
        {
            Player testPlayer = new Player('*', 3, 3);
            testPlayer.Update(new Coords(2, 2));

            var expected = "3 3";
            testPlayer.Reset();
            var actual = testPlayer.Row + " " + testPlayer.Col;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void EmptyNameTest()
        {
            Player testPlayer = new Player('*', 3, 3);
            testPlayer.Name = string.Empty;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void OnlyOneNameTest()
        {
            Player testPlayer = new Player('*', 3, 3);
            testPlayer.Name = "Raly";
            var currName = testPlayer.Name;
            testPlayer.Name = "Player name";
        }
    }
}
