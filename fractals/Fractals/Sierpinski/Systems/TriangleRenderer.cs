using Raylib_cs;

namespace Fractals.Sierpinski.Systems
{
	internal class TriangleRenderer : ISystem
	{
		private readonly SimulationContext context;
		private const float maxFadedSide = 70f;

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
			var color = Color.Black;
			// fade in triangles to prevent a flash when a new batch of triangles is generated
			color.A = GetAlpha(triangle);

			Raylib.DrawTriangleLines(triangle.Top, triangle.Left, triangle.Right, color);
		}

		private static byte GetAlpha(Triangle triangle)
		{
			var side = triangle.Right.X - triangle.Left.X;
			var opacity = GetOpacity(side);
			var alpha = (byte)(opacity * byte.MaxValue);

			return alpha;
		}

		private static float GetOpacity(float side)
		{
			return MathF.Min(side / maxFadedSide, 1f);
		}
	}
}
