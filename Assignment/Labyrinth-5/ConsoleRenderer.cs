using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabirynthGame
{
    public class ConsoleRenderer : IRenderer
    {
        /// <summary>
        /// The method prints the labyrinth matrix to the console
        /// </summary>
        /// <param name="field">Field object</param>
        public string Render(IField field)
        {
            StringBuilder sb = new StringBuilder();

            for (int row = 0; row < field.Size; row++)
            {
                for (int col = 0; col < field.Size; col++)
                {
                    sb.AppendFormat("{0,2}", field[row, col]);
                }
                sb.AppendLine();
            }

            return sb.ToString();
        }
    }
}
