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
	static class Mathf
	{

		// Rounds float down to int
		public static int FloorToInt (float f)
		{
			return (int)f;
		}

		// Rounds float up to int
		public static int CeilToInt(float f)
		{
			return (int)f + 1;
		}

		// Rounds float to int
		public static int RoundToInt (float f)
		{
			return FloorToInt(f + 0.5f);
		}

		// Rounds float down to float
		public static float Floor (float f)
		{
			return (int)f;
		}

		// Rounds float up to float
		public static float Ceil (float f)
		{
			return (int)f + 1;
		}

		// Rounds float to float
		public static float Round(float f)
		{
			return Sign(f) * Floor(Abs(f) + 0.5f);
		}

		// Returns positive version of number
		public static float Abs (float f)
		{
			if(f < 0)
				return -f;
			return f;
		}

		// Returns -1 if less than 0, 1 otherwise
		public static int Sign (float f)
		{
			if(f < 0)
				return -1;
			return 1;
		}

		// Sqaure root
		public static float Sqrt (float f)
		{ 
			return (float)Math.Sqrt((double) f); // very inefficient way of doing it, but easiest for me to implement
		}
	}
}
