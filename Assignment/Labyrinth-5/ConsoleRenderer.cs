using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabirynthGame
{
    public class ConsoleRenderer : IRenderer
    {
        //public Labyrinth Labyrinth { get; set; }

        public void Render(IField field)
        {
            for (int row = 0; row < field.Size; row++)
            {
                for (int col = 0; col < field.Size; col++)
                {
                    Console.Write("{0,2}", field[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
