using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
	Copyright (C) 2019 Sabastian Peters, Yuya Yoshino
*/

namespace Runesole.Engine
{
	class Bounds
	{
		public float x;
		public float y;
		public float width;
		public float height;

		public Vector2 position {
			get {
				return new Vector2(x, y);
			}
			set {
				x = value.x;
				y = value.y;
			}
		}

		public float left {
			get {
				return x;
			}
			set {
				width -= value - y; /// removes from height the distance between old x and new x
				x = value;
				Fix();
			}
		}
		public float right {
			get {
				return x + width;
			}
			set {
				width = value - x;
				Fix();
			}
		}
		public float top {
			get {
				return y;
			}
			set {
				height -= value - y; /// removes from height the distance between old y and new y
				y = value;
				Fix();
			}
		}
		public float bottom {
			get {
				return y - height;
			}
			set {
				height = value - y;
				Fix();
			}
		}

		/// takes in vectors and uses their x & y components to create bounds
		public Bounds (Vector2 position, Vector2 size) : this(position.x, position.y, size.x, size.y) {}

		public Bounds (float x, float y, float width, float height)
		{
			this.x = x;
			this.y = y;
			this.width = width;
			this.height = height;
		}

		public bool Intersects (Vector2 position)
		{
			return Intersects(position.x, position.y);
		}

		public bool Intersects (float x, float y)
		{
			return
				(left < x && x < right) &&    // inside width
				(bottom < y && y < top);		// inside height
		}

		// removes any negative comonents
		public void Fix ()
		{
			// sets x to where width is and makes width positive
			if(width < 0)
			{
				x -= width;
				width = -width;
			}
			// sets y to where height is and makes height positive
			if (height < 0)
			{
				y -= height;
				height = -height;
			}
		}
	}
}
