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
		
		private static Action drawQueue;
		
		// ## CONST UTILITY VARIABLES ## // Make it easier to change values
		private const Color.Foreground DEFAULT_FG = Color.Foreground.White;
		private const Color.Background DEFAULT_BG = Color.Background.None;


		// ## PUBLIC METHODS ##

		// Draws queued up draw calls
		public static void Draw ()
		{		
			/// draws any queued calls and clears list
			if (drawQueue != null)
				drawQueue();
			drawQueue = null;
		}


		// ## PUBLIC DRAW METHODS ## // These add draw calls to the UI queue

		// draws a string starting from left of string
		public static void StringLeft (Coord pos, string s, Color.Foreground fg = DEFAULT_FG, Color.Background bg = DEFAULT_BG)
		{
			drawQueue += () => {                /// adds draw call to queue
				_drawString(pos, s, fg, bg);
			};
		}

		// draws a string starting from center of string
		public static void StringCenter(Coord pos, string s, Color.Foreground fg = DEFAULT_FG, Color.Background bg = DEFAULT_BG)
		{
			pos.x -= s.Length / 2;              /// draws from center of string
			drawQueue += () => {                /// adds draw call to queue
				_drawString(pos, s, fg, bg);
			};
		}

		// draws a string starting from right of string
		public static void StringRight(Coord pos, string s, Color.Foreground fg = DEFAULT_FG, Color.Background bg = DEFAULT_BG)
		{
			pos.x -= s.Length;					/// draws from right of string
			drawQueue += () => {				/// adds draw call to queue
				_drawString(pos, s, fg, bg);
			};
		}
		


		// ## PRIVATE UTITLITY METHODS ## // Things to make drawing easier

		// draws a string with left formatting at the given position
		private static void _drawString(Coord pos, string s, Color.Foreground fg, Color.Background bg)
		{
			// Exits if y is out of range
			if(!(0 <= pos.y && pos.y < ConsoleRenderer.Height))
				return;

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
	}
}
