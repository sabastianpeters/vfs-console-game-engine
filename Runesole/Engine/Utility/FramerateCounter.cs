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
	class FramerateCounter
	{
		private List<float> _datapointList; /// a set of datapoints to average from
		public int value { get; private set; } /// what is our current fps?
		int _maxDatapoints;	/// how many previous datapoints should we store and average from? arbitrary


		// should call this every frame
		public void Update ()
		{
			float _currentFps = 1 / Time.unscaledDeltaTime; /// what would our fps be if we were running at this ms consistently?

			// adds current fps this frame, unless infinity (then add 0)
			_datapointList.Add(float.IsPositiveInfinity(_currentFps) || float.IsNegativeInfinity(_currentFps) ? 0 : _currentFps);


			// calulates the average of datapoints (average fps)
			float sum = 0;
			foreach (float f in _datapointList)
				sum += f;
			value = (int)(sum / _datapointList.Count);

			/// trims list so only looking at recent data points
			while (_datapointList.Count > _maxDatapoints)
				_datapointList.RemoveAt(0);
		}

		public FramerateCounter (int maxDatapoints = 10)
		{
			_datapointList = new List<float>();
			_maxDatapoints = maxDatapoints;
		}
	}
}
