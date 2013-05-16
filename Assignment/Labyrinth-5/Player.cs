using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabirynthGame
{
    public class Player : GameObject
    {
        private int points;

        public int Points { get; private set; }

        private string name;

        public string Name 
        {
            get
            {
                return this.name;
            }

            set
            {
                if (this.name != null)
                {
                    throw new ArgumentException("Cannot change name");
                }
                
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("You must enter a name");
                }

                this.name = value;
                
            }
        
        }

        public Player(char symbol, int row, int col)
            : base(symbol, row, col)
        {
            Coords initCoords = new Coords(row, col);
            this.InitCoords = initCoords;
        }               

        public void Update(Coords coords)
        {
            this.Row = coords.Row;
            this.Col = coords.Col;
            this.Points++;
        }

        public void Reset()
        {
            this.Row = InitCoords.Row;
            this.Col = InitCoords.Col;
        }
              
        private Coords InitCoords { get; set; }
    }
}
