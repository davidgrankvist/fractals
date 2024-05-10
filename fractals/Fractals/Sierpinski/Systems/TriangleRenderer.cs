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
		private readonly List<Triangle> triangles;

        public TriangleRenderer(List<Triangle> triangles)
        {
            this.triangles = triangles;
        }

		public void Initialize()
		{
		}

		public void Update()
		{
			foreach (Triangle triangle in triangles)
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
