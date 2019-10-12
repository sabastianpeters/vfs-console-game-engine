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
		private static long _time;		/// real time in milliseconds (long)
		private static long _lastTime;	/// real time last frame in milliseconds (long)
		private static Stopwatch _stopwatch; /// stopwatch that keeps track of time

		// Public properties
		public static float time { get; private set; }				/// in game time
		public static float deltaTime { get; private set; }			/// in game delta time
		public static float timeScale;								/// in game time scale
		public static float unscaledTime { get; private set; }      /// real time
		public static float unscaledDeltaTime { get; private set; } /// real delta time

		public static void Update ()
		{
			// updates real time variables
			_time = _stopwatch.ElapsedMilliseconds;
			unscaledTime = _time/1000f;

			// updates scaled time variables
			time += deltaTime;
		}

		public static void LateUpdate()
		{
			unscaledDeltaTime = (_time - _lastTime) / 1000f;
			_lastTime = _time;

			deltaTime = unscaledDeltaTime * timeScale;
		}



		public static void Init ()
		{
			// initialize variables
			_time = 2;
			_lastTime = 0;
			time = 0f;
			deltaTime = 0f;
			timeScale = 1f;
			unscaledTime = 0f;
			unscaledDeltaTime = 0f;


			_stopwatch = new Stopwatch();
			_stopwatch.Start();		
		}
	}
}
