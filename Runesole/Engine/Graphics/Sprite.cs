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
	class Sprite
	{
		
		// ## PUBLIC MEMBERS ##

		public readonly Coord origin;	/// where to start drawing the sprite, based off top-left (0, 0)
		public readonly int width;		/// width of the sprite
		public readonly int height;		/// height of the sprite
		public Spit[] spitList;			/// list of spits to draw sprite. row by row
			


		// ## PUBLIC METHODS ##

		// Draws the sprite at the given screen position
		public void Draw (Coord screenPos)
		{

			Coord drawPos = screenPos - origin;	/// draws from origin offset
			int _spriteX = 0, _spriteY = 0;		/// sprite-relative draw coord

			/// if origin is off screen, start drawing when it's on screen
			if(drawPos.x < 0)
				_spriteX = -drawPos.x;
			if (drawPos.y < 0) 
				_spriteY = -drawPos.y;
			
			// how much of the sprite do we need to draw?
			int drawWidth = Math.Min(width, ConsoleRenderer.Width - drawPos.x);
			int drawHeight = Math.Min(height, ConsoleRenderer.Height - drawPos.y);

			// Loops through visible spits and draws them
			for(int spriteX = _spriteX; spriteX < drawWidth; spriteX++)
				for (int spriteY = _spriteY; spriteY < drawHeight; spriteY++)
					GetSpit(spriteX, spriteY).Draw(drawPos.x + spriteX, drawPos.y + spriteY);
		}

		// gets the spit at the provided sprite index (start at top left)
		public Spit GetSpit (int spriteX, int spriteY)
		{
			return spitList[(spriteY * width) + spriteX];
		}

		// sets the spit at the provided sprite index (start at top left)
		public void SetSpit(int spriteX, int spriteY, Spit spit)
		{
			spitList[(spriteY * width) + spriteX] = spit;
		}



		// ## CONSTRUCTORS ## // provide multiple ways to create a sprite

		// constructor to create a new empty sprite
		public Sprite (int width, int height) : this(width, height, new Coord(0, 0)) { }
		public Sprite (int width, int height, Coord origin)
		{
			// sets values
			this.origin = origin;
			this.width = width;
			this.height = height;

			/// inializes spit array with blank spaces
			this.spitList = new Spit[width * (1 + height)];
			for (int i = 0; i < spitList.Length; i++)
				spitList[i] = new Spit(' ', Color.Foreground.None);
		}

		// creates a sprite based on another 
		public Sprite(Sprite sprite)
		{
			// copies base values
			this.origin = new Coord(sprite.origin.x, sprite.origin.y);
			this.width = sprite.width;
			this.height = sprite.height;

			// copies spit array to this new spit array
			this.spitList = new Spit[sprite.spitList.Length];
			sprite.spitList.CopyTo(this.spitList, 0);
		}
	}
}
