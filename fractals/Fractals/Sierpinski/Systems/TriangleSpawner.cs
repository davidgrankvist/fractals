using System.Linq;
using System.Numerics;

namespace Fractals.Sierpinski.Systems
{
	internal class TriangleSpawner : ISystem
	{
		private readonly SimulationContext context;

		private const int maxTriangles = 5000;

		public TriangleSpawner(SimulationContext context)
		{
			this.context = context;
		}
		public void Initialize()
		{
			var initialTriangle = CreateInitialTriangle();
			context.Triangles.Add(initialTriangle);
		}

		public void Update()
		{
			PruneTriangles();
			ExpandFractal();
		}

		private static Triangle CreateInitialTriangle()
		{
			var side = SimulationConstants.TRIANGLE_SIDE;
			var halfBottom = side / 2;
			var height = MathF.Sqrt(side * side - halfBottom * halfBottom);

			var top = new Vector2(SimulationConstants.WINDOW_WIDTH / 2f, 0);
			var left = new Vector2(top.X - halfBottom, top.Y + height);
			var right = new Vector2(top.X + halfBottom, top.Y + height);

			var initialTriangle = new Triangle(top, left, right);
			return initialTriangle;
		}

		private void PruneTriangles()
		{
			context.Triangles.RemoveAll(IsOutsideViewbox);
		}

		private static bool IsOutsideViewbox(Triangle triangle)
		{
			return triangle.Left.Y < 0 || triangle.Left.X > SimulationConstants.WINDOW_WIDTH;
		}

		private void ExpandFractal()
		{
			if (context.Triangles.Count > maxTriangles)
			{
				return;
			}

			var trianglesToAdd = new List<Triangle>();

			for (int i = context.Triangles.Count - 1; i >= 0; i--)
			{
				var triangle = context.Triangles[i];
				if (triangle.IsExpanded)
				{
					break;
				}

				trianglesToAdd.AddRange(triangle.GenerateChildren());
			}

			context.Triangles.AddRange(trianglesToAdd);
		}
	}
}
