using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabirynthGame
{
    public class GameObject
    {
        public GameObject(char symbol, int row, int col)
        {
            this.Symbol = symbol;
            this.Row = row;                
            this.Col = col;            
        }
        
        // VALIDATION
        public char Symbol { get; set; }        
        public int Row { get; set; }
        public int Col { get; set; }
    }
}
