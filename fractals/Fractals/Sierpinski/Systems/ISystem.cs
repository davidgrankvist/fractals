using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fractals.Sierpinski.Systems
{
    internal interface ISystem
    {
        public void Initialize();

        public void Update();
    }
}
