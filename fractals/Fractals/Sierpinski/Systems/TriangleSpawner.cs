﻿using System.Numerics;

namespace Fractals.Sierpinski.Systems
{
    internal class TriangleSpawner : ISystem
    {
        private readonly List<Triangle> triangles;

        public TriangleSpawner(List<Triangle> triangles)
        {
            this.triangles = triangles;
        }

		public void Initialize()
		{
			var initialTriangle = CreateInitialTriangle();
            triangles.Add(initialTriangle);
			// spawn children a couple of times just for testing
			SpawnChildren(initialTriangle);
			foreach (var child in initialTriangle.ComputeChildren())
			{
				SpawnChildren(child);
			}
		}

		public void Update()
		{
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

		private void SpawnChildren(Triangle triangle)
		{
			var children = triangle.ComputeChildren();
			triangles.AddRange(children);
		}
	}
}
