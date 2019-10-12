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
	// ANSI Escape Codes: https://en.wikipedia.org/wiki/ANSI_escape_code

	// a container class for ANSI Escape Codes
	static class Color
	{
		public enum Foreground
		{
			None = -1,
			Black = 30,
			DarkGray = 90,
			LightGray = 37,
			White = 97,
			Red = 31,
			Green = 32,
			Yellow = 33,
			Blue = 34,
			Magenta = 35,
			Cyan = 36,
			BrightRed = 91,
			BrightGreen = 92,
			BrightYellow = 93,
			BrightBlue = 94,
			BrightMagenta = 95,
			BrightCyan = 96
		}

		public enum Background
		{
			None = -1,
			Black = 40,
			DarkGray = 100,
			LightGray = 47,
			White = 107,
			Red = 41,
			Green = 42,
			Yellow = 43,
			Blue = 44,
			Magenta = 45,
			Cyan = 46,
			BrightRed = 101,
			BrightGreen = 102,
			BrightYellow = 103,
			BrightBlue = 104,
			BrightMagenta = 105,
			BrightCyan = 106
		}
	}
}
