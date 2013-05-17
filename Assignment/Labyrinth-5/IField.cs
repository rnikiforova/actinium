using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabirynthGame
{
    /// <summary>
    /// Interface which is inherited from the 
    /// </summary>
    public interface IField
    {
        int Size { get; }

        void AddObject(GameObject gameObject);

        void RemoveObject(Coords coords);

        bool IsPositionAvailable(Coords coords);

        char this[int row, int col] { get; set; }        
    }
}
