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
	// A console cordinated (x = column, y = row)
	struct Coord
	{
		public int x;
		public int y;

		// Coord for top left of screen
		public static Coord TopLeft {
			get {
				return new Coord(0, 0);
			}
		}

		// Coord for top right of screen
		public static Coord TopRight {
			get {
				return new Coord(ConsoleRenderer.Width, 0);
			}
		}

		// Coord for bottom left of screen
		public static Coord BottomLeft {
			get {
				return new Coord(0, ConsoleRenderer.Height - 1);
			}
		}

		// Coord for bottom right of screen
		public static Coord BottomRight {
			get {
				return new Coord(ConsoleRenderer.Width, ConsoleRenderer.Height - 1);
			}
		}

		public static Coord Up {
			get {
				return new Coord(0, -1);
			}
		}

		public static Coord Down {
			get {
				return new Coord(0, 1);
			}
		}

		public static Coord Left {
			get {
				return new Coord(-1, 0);
			}
		}

		public static Coord Right {
			get {
				return new Coord(1, 0);
			}
		}

		public static Coord zero {
			get {
				return new Coord(0, 0);
			}
		}



		public static Coord operator +(Coord c1, Coord c2)
		{
			return new Coord(c1.x + c2.x, c1.y + c2.y);
		}
		public static Coord operator -(Coord c1, Coord c2)
		{
			return new Coord(c1.x - c2.x, c1.y - c2.y);
		}
		public static Coord operator *(Coord c, int n)
		{
			return new Coord(c.x * n, c.y * n);
		}
		public static Coord operator /(Coord c, int n)
		{
			return new Coord(c.x / n, c.y / n);
		}

		public Coord(int x, int y)
		{
			this.x = x;
			this.y = y;
		}
	}
}
