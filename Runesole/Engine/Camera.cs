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
		
		public Vector2 position;
		public static Camera main { get; private set; }
		
		private Bounds cullBounds; /// the bounds for what to try and draw

		public void Update ()
		{
			cullBounds.x = position.x - ConsoleRenderer.Width / 2; 
			cullBounds.y = position.y + ConsoleRenderer.Height / 2;
			cullBounds.width = ConsoleRenderer.Width;
			cullBounds.height = ConsoleRenderer.Height;
		}
		
		
		public void Draw(float x, float y, Sprite sprite)
		{
			sprite.Draw(WorldtoScreen(x, y));
		}

		public Coord WorldtoScreen(Vector2 target)
		{
			return WorldtoScreen(target.x, target.y);
		}

		public Coord WorldtoScreen (float x, float y)
		{
			return new Coord(
				Mathf.RoundToInt(x - position.x + ConsoleRenderer.Width / 2),
				Mathf.RoundToInt(-(y - position.y) + ConsoleRenderer.Height / 2)  /// y is inverted so its drawn bottom to top, not top to bottom
			);
		}


		public Camera ()
		{
			cullBounds = new Bounds(0, 0, 0, 0);

			if (main == null)
				main = this; // if a main camera doesn't exist, set it here
		}
	}
}
