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
	// A class to represent a square bounding box
	class Bounds
	{
		// ## PUBLIC MEMBER ##
		public float x;
		public float y;
		public float width;
		public float height;


		// ## UTILITY PROPERTIES ##

		// property to get and set position (based on top left) of box
		public Vector2 position {
			get {
				return new Vector2(x, y);
			}
			set {
				x = value.x;
				y = value.y;
			}
		}

		// get and set the position of this bound's left side
		public float left {
			get {
				return x;
			}
			set {
				width -= value - y; /// removes from height the distance between old x and new x
				x = value;
				_Fix();
			}
		}
		// get and set the position of this bound's right side
		public float right {
			get {
				return x + width;
			}
			set {
				width = value - x;
				_Fix();
			}
		}
		// get and set the position of this bound's top side
		public float top {
			get {
				return y;
			}
			set {
				height -= value - y; /// removes from height the distance between old y and new y
				y = value;
				_Fix();
			}
		}
		// get and set the position of this bound's bottom side
		public float bottom {
			get {
				return y - height;
			}
			set {
				height = value - y;
				_Fix();
			}
		}


		// ## PUBLIC METHODS ##

		// Returns if bounds intersects with given position (vector2)
		public bool Intersects (Vector2 position)
		{
			return Intersects(position.x, position.y);
		}

		// Returns if bounds intersects with given position (x & y)
		public bool Intersects (float x, float y)
		{
			return
				(left < x && x < right) &&    // inside width
				(bottom < y && y < top);		// inside height
		}



		// ## PRIVATE UTILITY METHODS ##

		// removes any negative comonents
		private void _Fix ()
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


		// ## CONSTRUCTORS ##

		/// takes in vectors and uses their x & y components to create bounds
		public Bounds(Vector2 position, Vector2 size) : this(position.x, position.y, size.x, size.y) { }
		public Bounds(float x, float y, float width, float height)
		{
			this.x = x;
			this.y = y;
			this.width = width;
			this.height = height;
		}
	}
}
