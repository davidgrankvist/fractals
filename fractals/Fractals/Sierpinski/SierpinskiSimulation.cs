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
			var zoomer = new TriangleZoomer(context);
			var spawner = new TriangleSpawner(context);
			var renderer = new TriangleRenderer(context);

			// init spawner before zoomer to determine the zoom origin
			spawner.Initialize();
			zoomer.Initialize();
			renderer.Initialize();

			/*
			 * update zoomer before spawner so that new triangles are spawned
			 * based on already moved triangles
			 */
			systems.Add(zoomer);
			systems.Add(spawner);
			systems.Add(renderer);
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
