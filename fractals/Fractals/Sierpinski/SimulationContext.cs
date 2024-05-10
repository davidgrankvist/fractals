using Fractals.Sierpinski.Systems;
namespace Fractals.Sierpinski
{
	internal class SimulationContext
	{
		public List<Triangle> Triangles { get; private set; }
		public bool ZoomIsActive { get; set; } = true;

		public readonly float ZoomStep = 0.01f;

		public bool DebugMode { get; set; } = false;
		public int Depth { get; set; } = 0;
		public int GeneratedTriangles { get; set; } = 1;
		public int MaxInMemoryCount { get; set; } = 1;

		public SimulationContext()
		{
			Triangles = new List<Triangle>();
		}
	}
}
