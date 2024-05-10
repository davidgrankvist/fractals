using Fractals.Sierpinski.Systems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fractals.Sierpinski
{
	internal class SimulationContext
	{
		public List<Triangle> Triangles { get; private set; }

		public SimulationContext()
		{
			Triangles = new List<Triangle>();
		}
	}
}
