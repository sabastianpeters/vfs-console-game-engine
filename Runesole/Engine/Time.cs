using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;


/*
	Copyright (C) 2019 Sabastian Peters, Yuya Yoshino
*/

namespace Runesole.Engine
{
	static class Time
	{
		// Utility variables
		private static long _lastTime;
		private static long _time;
		private static Stopwatch _stopwatch;

		// Public properties
		public static float time { get; private set; }
		public static float deltaTime { get; private set; }

		public static void Update ()
		{
			_time = _stopwatch.ElapsedMilliseconds;
			time = _time/1000f;
		}

		public static void LateUpdate()
		{
			deltaTime = (_time - _lastTime) / 1000f;
			_lastTime = _time;
		}



		public static void Init ()
		{
			// initialize variables
			time = 0.1f;
			_time = 2;
			_lastTime = 0;
			deltaTime = 0.01f;


			_stopwatch = new Stopwatch();
			_stopwatch.Start();		
		}
	}
}
