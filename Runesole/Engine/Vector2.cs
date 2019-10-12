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
	
	// 2 Dimensional Vector Struct
	struct Vector2
	{
		
		// ## PUBLIC MEMBERS ##
		public readonly float x;
		public readonly float y;
		

		// ## PUBLIC UTILITY PROPERTIES ## // these are values retrieved often, defining here means shorter code

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



		// ## VECTOR MATH FUNCTIONS ##

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

		// Returns this vector with a magnitude of 1
		public Vector2 Normalize ()
		{
			return this / Vector2.Distance(Vector2.zero, this);
		}


		// ## OPERATOR OVERLOADING ## // makes code significantly more readable

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


		// overrides ToString() to provide more info
		public override string ToString()
		{
			return $"Vector2({x}, {y})";
		}



		// ## CONSTRUCTOR ##
		
		public Vector2(float x, float y)
		{
			this.x = x;
			this.y = y;
		}
	}
}
