using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabirynthGame
{
    /// <summary>
    /// Interface which is inherited from the ConsoleRender class
    /// </summary>
    public interface IRenderer
    {
        string Render(IField field);
    }
}
