using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabirynthGame
{
    /// <summary>
    /// Player class 
    /// </summary>
    public class Player : GameObject
    {
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

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="symbol">char symbol</param>
        /// <param name="row">row</param>
        /// <param name="col">col</param>
        public Player(char symbol, int row, int col)
            : base(symbol, row, col)
        {
            Coords initCoords = new Coords(row, col);
            this.InitCoords = initCoords;
        }               

        /// <summary>
        /// Updates the coordinates and every time when the method is called it updates the players moves
        /// </summary>
        /// <param name="coords">Coordinates</param>
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
              
        public Coords InitCoords { get; set; }
    }
}
