using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabirynthGame
{
    public class Coords
    {
        public int Col { get; set; }

        public int Row { get; set; }

        public Coords(int row, int col)
        {            
            this.Row = row;
            this.Col = col;
        }
    }
}
