using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabirynthGame
{
    public class Player : GameObject
    {
        public Player(char symbol, int row, int col)
            : base(symbol, row, col)
        {
            
        }

        public void Update(Coords coords)
        {
            this.Row += coords.Row;
            this.Col += coords.Col;
        }
    }
}
