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

	// A spit is inbetween a sprite and a pixel. Pixels make up spits, and spits makeup sprites
	// Spit (TM) 2019 Yuya Yoshino, Sabastian Peters

	// A char with color information
	struct Spit
	{
		public char character;	/// the char to draw
		public Color.Forground forgroundColor;
		public Color.Background backgroundColor;

		private const Color.Forground defaultForgroundColor = Color.Forground.White;
		private const Color.Background defaultBackgroundColor = Color.Background.None;

		public void Draw (int x, int y)
		{
			ConsoleRenderer.SetChar(x, y, character);
			ConsoleRenderer.SetColor(x, y, forgroundColor);
			ConsoleRenderer.SetColor(x, y, backgroundColor);
		}

		// Various constructors to create a spit with different params

		public Spit (char c)
		{
			this.character = c;
			this.forgroundColor = defaultForgroundColor;
			this.backgroundColor = defaultBackgroundColor;
		}

		public Spit(char c, Color.Forground fgColor)
		{
			this.character = c;
			this.forgroundColor = fgColor;
			this.backgroundColor = defaultBackgroundColor;
		}

		public Spit(char c, Color.Background bgColor)
		{
			this.character = c;
			this.forgroundColor = defaultForgroundColor;
			this.backgroundColor = bgColor;
		}


		public Spit(char c, Color.Background bgColor, Color.Forground fgColor) : this(c, fgColor, bgColor) { }

		public Spit(char c, Color.Forground fgColor, Color.Background bgColor)
		{
			this.character = c;
			this.forgroundColor = fgColor;
			this.backgroundColor = bgColor;
		}

	}
}
