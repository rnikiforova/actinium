using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LabirynthGame;

namespace RendererTests
{
    [TestClass]
    public class LabyrinthTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ConstructorTestArgumentIsNotZero()
        {
            Labyrinth lab = new Labyrinth(0);
            int a = lab.Size;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ConstructorTesArgumnetIsNotNegative()
        {
            Labyrinth lab = new Labyrinth(-1);
            int a = lab.Size;
        }
    }
}
