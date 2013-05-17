using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabirynthGame
{
    /// <summary>
    /// The Coords class holds the coordinates which will be used from the other classes(like Player)
    /// </summary>
    public class Coords
    {
        public int Col { get; set; }
        public int Row { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="row">row</param>
        /// <param name="col">col</param>
        public Coords(int row, int col)
        {            
            this.Row = row;
            this.Col = col;
        }
    }
}
