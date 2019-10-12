using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Runesole.Engine.Graphics;

/*
	Copyright (C) 2019 Sabastian Peters, Yuya Yoshino
*/

namespace Runesole.Engine
{
	// A class to log debug info
	static class Debug
	{
		// ## PRIVATE DEBUG VARIABLES ## // things we want to keep track of
		private static FramerateCounter fps = new FramerateCounter(); 	/// frames per second counter
		private static int currentLine;									/// what line are we drawing to this frame?
			
		public static void Draw ()
		{
			currentLine = 0;
			fps.Update();
			
			// Log player position & fps
			Log($"Position: {Player.main.position.x}, {Player.main.position.y}");
			Log($"{fps.value} FPS ({Time.unscaledDeltaTime * 1000}ms)");
		}

		// Logs some string data to consoles
		public static void Log (string s)
		{
			UI.StringLeft(Coord.BottomLeft + (Coord.Up * currentLine++), s, Color.Foreground.White, Color.Background.Black);
		}
	}
}
