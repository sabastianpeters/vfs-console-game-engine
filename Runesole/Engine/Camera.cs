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
	class Camera
	{

		// ## PUBLIC FIELDS ##
		public static Camera main { get; private set; }
		public Vector2 position;
		

		// ## PUBLIC METHODS ##
		
		// draws a sprite at the given screen pos
		public void Draw(float x, float y, Sprite sprite)
		{
			sprite.Draw(WorldtoScreen(x, y));
		}

		// Takes a world vector2 and turns it into screen coord // ideally would have ScreenToWorld too
		public Coord WorldtoScreen(Vector2 target)
		{
			return WorldtoScreen(target.x, target.y);
		}

		// Takes a world (x, y) and turns it into screen coord
		public Coord WorldtoScreen (float x, float y)
		{
			return new Coord(
				Mathf.RoundToInt(x - position.x + ConsoleRenderer.Width / 2),
				Mathf.RoundToInt(-(y - position.y) + ConsoleRenderer.Height / 2)  /// y is inverted so its drawn bottom to top, not top to bottom
			);
		}



		// ## CONSTRUCTOR ##

		public Camera ()
		{
			if (main == null)
				main = this; // if a main camera doesn't exist, set it here
		}
	}
}
