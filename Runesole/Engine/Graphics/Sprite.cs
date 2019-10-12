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
		public readonly Coord origin;	/// where to start drawing the sprite, based off top-left (0, 0)
		public readonly int width;		/// width of the sprite
		public readonly int height;		/// height of the sprite
		public Spit[] spitList;			/// list of spits to draw sprite. row by row
			

		public void Draw (Coord screenPos)
		{

			Coord drawPos = screenPos - origin; /// draws from origin offset
			
			int _spriteX = 0, _spriteY = 0; // sprite-relative draw coord

			/// ensures we only draw on screen
			if(drawPos.x < 0)
			{
				_spriteX = -drawPos.x; /// ensures we start drawing at the right place
			}
			if (drawPos.y < 0)
			{
				_spriteY = -drawPos.y; /// ensures we start drawing at the right place
			}
			int drawWidth = Math.Min(width, ConsoleRenderer.Width - drawPos.x);
			int drawHeight = Math.Min(height, ConsoleRenderer.Height - drawPos.y);

			// Loops through visible spits and draws them
			for(int spriteX = _spriteX; spriteX < drawWidth; spriteX++)
				for (int spriteY = _spriteY; spriteY < drawHeight; spriteY++)
					GetSpit(spriteX, spriteY).Draw(drawPos.x + spriteX, drawPos.y + spriteY);
		}

		public Spit GetSpit (int spriteX, int spriteY)
		{
			return spitList[(spriteY * width) + spriteX];
		}

		public void SetSpit(int spriteX, int spriteY, Spit spit)
		{
			spitList[(spriteY * width) + spriteX] = spit;
		}



		public Sprite (int width, int height) : this(width, height, new Coord(0, 0)) { }

		public Sprite (int width, int height, Coord origin)
		{
			this.origin = origin;
			this.width = width;
			this.height = height;

			this.spitList = new Spit[width * (1 + height)];
			for (int i = 0; i < spitList.Length; i++)
				spitList[i] = new Spit(' ', Color.Forground.None);      /// inializes array with blank spaces
		}

		public Sprite(Sprite sprite)
		{
			this.origin = new Coord(sprite.origin.x, sprite.origin.y);
			this.width = sprite.width;
			this.height = sprite.height;

			this.spitList = new Spit[sprite.spitList.Length];
			sprite.spitList.CopyTo(this.spitList, 0);
		}
	}
}
