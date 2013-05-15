using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabirynthGame
{
    public interface IRenderer
    {
        void Render();

        void AddObject(GameObject gameObject);

        void RemoveObject(Coords coords);

        bool IsGameOver(GameObject coords);
    }
}
