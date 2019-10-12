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
	struct Vector2
	{
		public readonly float x;
		public readonly float y;

		// ## comonly used vectors ##

		// Vector (0, 0)
		public static Vector2 zero { get { 
			return new Vector2(0, 0);
		} }

		// Vector (1, 1)
		public static Vector2 one { get { 
			return new Vector2(1, 1);
		} }

		// Vector (-1, 0)
		public static Vector2 left { get { 
			return new Vector2(-1, 0);
		} }

		// Vector (1, 0)
		public static Vector2 right { get { 
			return new Vector2(1, 0);
		} }

		// Vector (0, 1)
		public static Vector2 up { get { 
			return new Vector2(0, 1);
		} }

		// Vector (0, -1)
		public static Vector2 down { get { 
			return new Vector2(0, -1);
		} }


		// basic constructor
		public Vector2(float x, float y)
		{
			this.x = x;
			this.y = y;
		}

		// Squared distance between 2 vectors (faster than Distance())
		public static float SqrDistance(Vector2 v1, Vector2 v2)
		{
			float dx = v2.x - v1.x;
			float dy = v2.y - v1.y;
			return dx * dx + dy * dy;
		}

		// Distance between 2 vectors
		public static float Distance (Vector2 v1, Vector2 v2)
		{
			return Mathf.Sqrt(SqrDistance(v1, v2));
		}

		public Vector2 Normalize ()
		{
			return this / Vector2.Distance(Vector2.zero, this);
		}


		public static Vector2 operator +(Vector2 v1, Vector2 v2)
		{
			return new Vector2(v1.x + v2.x, v1.y + v2.y);
		}
		public static Vector2 operator -(Vector2 v1, Vector2 v2)
		{
			return new Vector2(v1.x - v2.x, v1.y - v2.y);
		}
		public static Vector2 operator *(Vector2 v, float n)
		{
			return new Vector2(v.x * n, v.y * n);
		}
		public static Vector2 operator /(Vector2 v, float n)
		{
			return new Vector2(v.x / n, v.y / n);
		}

		public override string ToString()
		{
			return $"Vector2({x}, {y})";
		}
	}
}
