using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
	Copyright (C) 2019 Sabastian Peters, Yuya Yoshino
*/

namespace Runesole.Engine.Graphics
{
	static class UI
	{
		static FramerateCounter fps = new FramerateCounter();

		public static void Draw ()
		{
			fps.Update();

			StringRight(Coord.BottomRight, $"Position: {Player.main.position.x}, {Player.main.position.y}");
			String(Coord.TopLeft, $"Delta time: {Time.deltaTime*1000}ms ({fps.value} FPS)");
		}


		public static void String(Coord pos, string s)
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

		public static void StringRight(Coord pos, string s)
		{
			pos.x -= s.Length;
			UI.String(pos, s);
		}
	}
}
