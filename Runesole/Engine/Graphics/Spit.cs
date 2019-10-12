using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*
	Copyright (C) 2019 Sabastian Peters, Yuya Yoshino
*/

// NOTE: A spit is inbetween a sprite and a pixel. Pixels make up spits, and spits makeup sprites

namespace Runesole.Engine.Graphics
{
	// A char with color information
	struct Spit
	{
		
		// ## PUBLIC MEMBERS ##
		public char character;						/// the char to draw (foreground color)
		public Color.Foreground foregroundColor;	/// foreground color
		public Color.Background backgroundColor;	/// background color


		// ## UTILITY CONST VALUES ## // default const values for easy modification later
		private const Color.Foreground DEFAULT_FG = Color.Foreground.White;
		private const Color.Background DEFAULT_BG = Color.Background.None;


		// ## PUBLIC METHODS ##

		// draws the spit at the given coordinates
		public void Draw (int x, int y)
		{
			// sets data of the 3 buffers at provided coords with spit data
			ConsoleRenderer.SetChar(x, y, character);
			ConsoleRenderer.SetColor(x, y, foregroundColor);
			ConsoleRenderer.SetColor(x, y, backgroundColor);
		}


		// ## CONSTRUCTORS ## // various constructors allows a spit to be created with many different params, they all end up calling the last constructor

		public Spit (char c) : this(c, DEFAULT_FG, DEFAULT_BG) { }
		public Spit(char c, Color.Foreground fgColor) : this(c, fgColor, DEFAULT_BG) { }
		public Spit(char c, Color.Background bgColor) : this(c, DEFAULT_FG, bgColor) { }
		public Spit(char c, Color.Background bgColor, Color.Foreground fgColor) : this(c, fgColor, bgColor) { }
		public Spit(char c, Color.Foreground fgColor, Color.Background bgColor)
		{
			this.character = c;
			this.foregroundColor = fgColor;
			this.backgroundColor = bgColor;
		}

	}
}
