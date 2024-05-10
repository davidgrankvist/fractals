using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;

namespace Fractals.Sierpinski.Systems
{
	internal class TriangleRenderer : ISystem
	{
		private readonly SimulationContext context;

		public TriangleRenderer(SimulationContext context)
		{
			this.context = context;
		}

		public void Initialize()
		{
		}

		public void Update()
		{
			foreach (Triangle triangle in context.Triangles)
			{
				RenderTriangle(triangle);
			}
		}
		private static void RenderTriangle(Triangle triangle)
		{
			Raylib.DrawTriangleLines(triangle.Top, triangle.Left, triangle.Right, Color.Black);
		}
	}
}
