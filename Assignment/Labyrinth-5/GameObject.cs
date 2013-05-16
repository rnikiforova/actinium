using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabirynthGame
{
    public class GameObject
    {
        private int row;
        private int col;
        private char symbol;

        public GameObject(char symbol, int row, int col)
        {
            this.Symbol = symbol;
            this.Row = row;                
            this.Col = col;            
        }

        public char Symbol
        {
            get
            {
                return this.symbol;
            }

            set
            {
                if ((int)value < 33 || (int)value > 44)
                {

                    string chars = PrintAllowedChars();

                    throw new ArgumentOutOfRangeException(string.Format("Inccorect symbol. You can use: {0}.", chars));
                }
                else
                {
                    this.symbol = value;
                }
            }

        }

        private static string PrintAllowedChars()
        {
            StringBuilder allowerdCharsSb = new StringBuilder();            
           

            for (int charIndex = 33; charIndex < 45; charIndex++)
            {
                allowerdCharsSb.AppendFormat("{0,2}", (char)charIndex);
            }


            return allowerdCharsSb.ToString();
        }        
        
        public int Row 
        {
            get
            {
                return this.row;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Row cannot be negative");
                }
                else
                {
                    this.row = value;
                }
            }
        }

        public int Col 
        {
            get
            {
                return this.col;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Coll cannot be negative");
                }
                else
                {
                    this.col = value;
                }
            }
        
        }
    }
}
