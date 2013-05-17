using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LabirynthGame;

namespace RendererTests
{
    [TestClass]
    public class KeyboardControllerTests
    {
        [TestMethod]
        public void MoveLeftTest()
        {
            IController keyboard = new KeyboardController();
            var expected = "0 -1";
            Coords actualCoords = keyboard.MoveLeft();
            var actual = actualCoords.Row + " " + actualCoords.Col;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MoveRightTest()
        {
            IController keyboard = new KeyboardController();
            var expected = "0 1";
            Coords actualCoords = keyboard.MoveRight();
            var actual = actualCoords.Row + " " + actualCoords.Col;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MoveUpTest()
        {
            IController keyboard = new KeyboardController();
            var expected = "-1 0";
            Coords actualCoords = keyboard.MoveUp();
            var actual = actualCoords.Row + " " + actualCoords.Col;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MoveDownTest()
        {
            IController keyboard = new KeyboardController();
            var expected = "1 0";
            Coords actualCoords = keyboard.MoveDown();
            var actual = actualCoords.Row + " " + actualCoords.Col;
            Assert.AreEqual(expected, actual);
        }

    }
}
