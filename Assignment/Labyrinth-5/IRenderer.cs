using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabirynthGame
{
    public interface IRenderer
    {
        void Render(IField field);
    }
}
