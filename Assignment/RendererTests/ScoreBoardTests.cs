using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LabirynthGame;
using System.Collections.Generic;

namespace RendererTests
{
    [TestClass]
    public class ScoreboardTests
    {
        //[TestMethod]
        //public void AddTest()
        //{
        //    Player player = new Player('*', 3, 3);
        //    player.Name = "adad";
        //    ScoreBoard scoreBoard = new ScoreBoard();

        //    //scoreBoard.Add(player);

        //    var players = scoreBoard.Players;
        //    var currPlayers = new List<Player>();
        //    currPlayers.Add(player);

        //    var expected = true;
        //    var actual = false;

        //    for (int i = 0; i < players.Count; i++)
        //    {
        //        if (players[i] != currPlayers[i])
        //        {
        //            actual = false;
        //        }

        //    }

        //    actual = true;

        //    Assert.AreEqual(expected, actual);

        //}

        [TestMethod]
        public void ToStringTest()
        {
            Player player = new Player('*', 3, 3);
            player.Name = "Player name";
            ScoreBoard scoreBoard = new ScoreBoard();

            scoreBoard.Players.Add(player);

            var expected = string.Format("{0} {1} --> {2}\r\n", 1, scoreBoard.Players[0].Name, 0);
            var actual = scoreBoard.ToString();

            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void LabTest()
        {
            IField lab = new Labyrinth(7);

            var expected = 7;
            var actual = lab.Size;

            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void RemoveObjectTest()
        {
            IField lab = new Labyrinth(7);

            lab.RemoveObject(new Coords(3, 3));

            var expected = '-';
            var actual = lab[3, 3];

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddObjectTest()
        {
            IField lab = new Labyrinth(7);
            GameObject obj = new GameObject('$', 3, 3);
            lab.AddObject(obj);

            var expected = '$';
            var actual = lab[3, 3];

            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void AddObjectFailTest()
        {
            Labyrinth lab = new Labyrinth(7);
            GameObject obj = new GameObject('$', 0, 1);

            char[,] testMatrix = new char[,] {
                 {'-', 'X', '-', 'X'},
                 {'-', '-', '-', 'X'},                 
                 {'X', 'X', '-', '-'} , 
                 {'X', 'X', '-', '-'}  
            };

            lab.TestMatrix(testMatrix);
            lab.AddObject(obj);

            var expected = 'X';
            var actual = lab[0, 1];

            Assert.AreEqual(expected, actual);

        }


        // Before send: testMatrix in Labyrint
        [TestMethod]
        public void RenderTest()
        {
            Labyrinth lab = new Labyrinth(4);

            char[,] testMatrix = new char[,] {
                 {'-', 'X', '-', 'X'},
                 {'-', '-', '-', 'X'},                 
                 {'X', 'X', '-', '-'} , 
                 {'X', 'X', '-', '-'}  
            };

            lab.TestMatrix(testMatrix);


            ConsoleRenderer renderer = new ConsoleRenderer();
            var actual = renderer.Render(lab);
            var expected = " - X - X\r\n - - - X\r\n X X - -\r\n X X - -\r\n";

            Assert.AreEqual(expected, actual);
        }

    }
}
