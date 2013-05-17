using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabirynthGame
{
    /// <summary>
    /// The class manages the input from the Engine
    /// </summary>
    public class KeyboardController : IController
    {
        /// <summary>
        /// Updates the coordinates and force the objects which use it to move left in a matrix
        /// </summary>
        /// <returns>Coordinates</returns>
        public Coords MoveLeft()
        {
            Coords coords = new Coords(0, -1);
            return coords;
        }
        /// <summary>
        /// Updates the coordinates and force the objects which use it to move right in a matrix
        /// </summary>
        /// <returns>Coordinates</returns>
        public Coords MoveRight()
        {
            return new Coords(0, 1);
        }

        /// <summary>
        /// Updates the coordinates and force the objects which use it to move down in a matrix
        /// </summary>
        /// <returns>Coordinates</returns>
        public Coords MoveDown()
        {
            return new Coords(1, 0);
        }

        /// <summary>
        /// Updates the coordinates and force the objects which use it to move up in a matrix
        /// </summary>
        /// <returns>Coordinates</returns>
        public Coords MoveUp()
        {
            return new Coords(-1, 0);
        }
        /// <summary>
        /// Process the input from the console
        /// </summary>
        /// <param name="input">string</param>
        /// <returns>returns the four methods for each unput string:MoveLeft(), MoveRight(), MoveUp(), MoveDown()</returns>
        public Coords ProcessInput(string input)
        {
            switch (input.ToUpper())
            {
                case "L": return this.MoveLeft();
                case "R": return this.MoveRight();
                case "U": return this.MoveUp();
                case "D": return this.MoveDown();
                default: return new Coords(0, 0);
            }
        }
    }
}
