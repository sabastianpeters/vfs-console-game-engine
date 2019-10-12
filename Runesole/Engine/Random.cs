using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
	Copyright (C) 2019 Sabastian Peters, Yuya Yoshino
*/

namespace Runesole.Engine
{
	// Random Number Generator Class
	static class Random
	{
		private static System.Random _rand;

		// returns a float between min (inclusive) and max (exclusive)
		public static float Range (float min, float max)
		{
			return min + ((float)_rand.NextDouble() * max);
		}

		// returns a int between min (inclusive) and max (exclusive)
		public static int Range(int min, int max)
		{
			return _rand.Next(min, max);
		}

        public static void Init()
        {
            _rand = new System.Random();
        }
	}
}
