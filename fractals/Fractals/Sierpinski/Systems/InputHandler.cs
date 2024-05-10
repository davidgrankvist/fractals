using Raylib_cs;

namespace Fractals.Sierpinski.Systems
{
	internal class InputHandler : ISystem
	{
		private readonly SimulationContext context;

		public InputHandler(SimulationContext context)
		{
			this.context = context;
		}
		public void Initialize()
		{
		}

		public void Update()
		{
			if (Raylib.IsKeyPressed(KeyboardKey.D))
			{
				context.DebugMode = !context.DebugMode;
			}
		}
	}
}
