using Fractals.Sierpinski.Systems;
using Raylib_cs;

namespace Fractals.Sierpinski
{
	internal class SierpinskiSimulation
	{
		private readonly SimulationContext context;
		private readonly List<ISystem> systems;

		public SierpinskiSimulation()
		{
			context = new SimulationContext();
			systems = new List<ISystem>();
		}

		public void Run()
		{
			Initialize();
			RenderLoop();
		}

		private void Initialize()
		{
			systems.Add(new TriangleSpawner(context));
			systems.Add(new TriangleRenderer(context));

			foreach (var system in systems)
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
