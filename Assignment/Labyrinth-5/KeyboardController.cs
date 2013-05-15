using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabirynthGame
{
    class KeyboardController : IController
    {
        public Coords MoveLeft()
        {
            Coords coords = new Coords(0, -1);
            return coords;
        }

        public Coords MoveRight()
        {
            return new Coords(0, 1);
        }

        public Coords MoveDown()
        {
            return new Coords(1, 0);
        }

        public Coords MoveUp()
        {
            return new Coords(-1, 0);
        }

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
