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
	static class UI
	{
		private static FramerateCounter fps = new FramerateCounter();
		private static Action draw;

		public static void Draw ()
		{
			fps.Update();

			/// draws any queued calls and clears list
			if (draw != null)
				draw();
			draw = null;
			
			// TODO: Move this to a debug class
			/// Draws FPS and Player Position
			_drawStringRight(Coord.BottomRight, $"Position: {Player.main.position.x}, {Player.main.position.y}");
			_drawString(Coord.TopLeft, $"Delta time: {Time.deltaTime*1000}ms ({fps.value} FPS)");

		}

		public static void String (Coord pos, string s)
		{
			draw += () => {
				_drawString(pos, s);
			};
		}

		public static void StringRight(Coord pos, string s)
		{
			draw += () => {
				_drawStringRight(pos, s);
			};
		}


		private static void _drawString(Coord pos, string s)
		{
			int x = pos.x;
			foreach (char c in s)
			{
				if (ConsoleRenderer.Width <= x)
					break;
				ConsoleRenderer.SetChar(x, pos.y, c);
				ConsoleRenderer.SetColor(x, pos.y, Color.Forground.White);
				ConsoleRenderer.SetColor(x, pos.y, Color.Background.None);
				x++;
			}
		}

		private static void _drawStringRight(Coord pos, string s)
		{
			pos.x -= s.Length;
			UI._drawString(pos, s);
		}
	}
}
