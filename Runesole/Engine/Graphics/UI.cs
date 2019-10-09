using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Runesole.Engine.Graphics;

/*
	Copyright (C) 2019 Sabastian Peters, Yuya Yoshino
*/

namespace Runesole.Engine.Graphics
{
	static class UI
	{
		private static Action draw;

		public static void Draw ()
		{		

			/// draws any queued calls and clears list
			if (draw != null)
				draw();
			draw = null;
			

		}

		public static void String (Coord pos, string s, Color.Forground fg = Color.Forground.White, Color.Background bg = Color.Background.None)
		{
			draw += () => {
				_drawString(pos, s, fg, bg);
			};
		}

		public static void StringRight(Coord pos, string s, Color.Forground fg = Color.Forground.White, Color.Background bg = Color.Background.None)
		{
			draw += () => {
				_drawStringRight(pos, s, fg, bg);
			};
		}


		private static void _drawString(Coord pos, string s, Color.Forground fg, Color.Background bg)
		{
			int x = pos.x;
			foreach (char c in s)
			{
				if (ConsoleRenderer.Width <= x)
					break;
				ConsoleRenderer.SetChar(x, pos.y, c);
				ConsoleRenderer.SetColor(x, pos.y, fg);
				ConsoleRenderer.SetColor(x, pos.y, bg);
				x++;
			}
		}

		private static void _drawStringRight(Coord pos, string s, Color.Forground fg, Color.Background bg)
		{
			pos.x -= s.Length;
			_drawString(pos, s, fg, bg);
		}
	}
}
