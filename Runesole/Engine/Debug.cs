using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Runesole.Engine.Graphics;

namespace Runesole.Engine
{
	static class Debug
	{
		private static FramerateCounter fps = new FramerateCounter();
		private static int currentLine;

		public static void Draw ()
		{
			currentLine = 0;
			fps.Update();
			
			// Log player position & fps
			Log($"Position: {Player.main.position.x}, {Player.main.position.y}");
			Log($"{fps.value} FPS ({Time.deltaTime * 1000}ms)");
		}

		public static void Log (string s)
		{
			UI.String(Coord.BottomLeft + (Coord.Up * currentLine++), s, Color.Forground.White, Color.Background.Black);
		}
	}
}
