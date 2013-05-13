using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabirynthGame
{
    public class Player
    {
        public const string symbol = "*";
        private int x;
        private int y;

        public Player(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        // TODO - Validation
        public int X { get; set; }

        // TODO - Validation
        public int Y { get; set; }       
        
    }
}
