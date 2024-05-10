using Fractals.Sierpinski.Systems;
using Raylib_cs;

namespace Fractals.Sierpinski
{
    internal class SierpinskiSimulation
    {
		private readonly List<Triangle> triangles;
		private readonly List<ISystem> systems;

		public SierpinskiSimulation()
        {
            triangles = new List<Triangle>();
            systems = new List<ISystem>();
        }

        public void Run()
        {
            Initialize();
            RenderLoop();
        }

        private void Initialize()
        {
            systems.Add(new TriangleSpawner(triangles));
            systems.Add(new TriangleRenderer(triangles));

            foreach (var system in  systems)
            {
                system.Initialize();
            }
		}

        private void RenderLoop()
        {
            Raylib.InitWindow(SimulationConstants.WINDOW_WIDTH, SimulationConstants.WINDOW_HEIGHT, "Sierpinski");
			Raylib.SetTargetFPS(60);

			while (!Raylib.WindowShouldClose())
            {
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.White);

                foreach (var system in systems)
                {
                    system.Update();
                }

                Raylib.EndDrawing();
            }

            Raylib.CloseWindow();
        }
    }
}
