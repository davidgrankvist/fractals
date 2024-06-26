﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Fractals.Sierpinski.Systems
{
	internal class TriangleZoomer : ISystem
	{
		private readonly SimulationContext context;

        public Vector2 ZoomCenter { get; set; }

        public TriangleZoomer(SimulationContext context)
        {
            this.context = context;
        }

        public void Initialize()
		{
			ZoomCenter = context.Triangles.First().Left;
		}

		public void Update()
		{
			if (!context.ZoomIsActive)
			{
				return;
			}

			foreach (var triangle in context.Triangles)
			{
				SpreadPoints(triangle);
			}
		}

		private void SpreadPoints(Triangle triangle)
		{
			var origin = ZoomCenter;
			var distance = context.ZoomStep;

			triangle.Top = MoveAwayFrom(triangle.Top, origin, distance);
			triangle.Left = MoveAwayFrom(triangle.Left, origin, distance);
			triangle.Right = MoveAwayFrom(triangle.Right, origin, distance);
		}

		private static Vector2 MoveAwayFrom(Vector2 point, Vector2 origin, float distance) 
		{
			/*
			 * No need to normalize here. If we move the point by a fraction of the triangle side
			 * then the fractal symmetry is still maintained.
			 */
			var offsetX = distance * (point.X - origin.X);
			var offsetY = distance * (point.Y - origin.Y);

			return new Vector2(point.X + offsetX, point.Y + offsetY);
		}
	}
}
