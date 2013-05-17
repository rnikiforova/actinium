using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabirynthGame
{
    /// <summary>
    /// Interface which is inherited from the KeyboardController
    /// </summary>
    public interface IController
    {
        Coords MoveLeft();

        Coords MoveRight();

        Coords MoveDown();

        Coords MoveUp();

        Coords ProcessInput(string input);
    }
}
