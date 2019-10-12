using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*
	Copyright (C) 2019 Sabastian Peters, Yuya Yoshino
*/

// I know convention is to have multiple files for each class. In this case i believe keeping it in one file helps readability

namespace Runesole.Engine
{
	// ## PARENT ABSTRACT CLASS ##
	
	// A YieldInstruction class
	abstract class YieldInstruction /// this could also be an interface (IYieldInstruction) - I followed Unity's style
	{
		// ## ABSTRACT MEMBERS ## // what the child needs to implement
		public abstract bool keepWaiting { get; }
	}



	// ## CHILD CLASSES (YIELD INSTRUCTION IMPLEMENTATIONS) ##

	// Waits while a condition becomes true
	class WaitWhile : YieldInstruction
	{
		private Func<bool> predicate;

		public override bool keepWaiting {
			get {
				return predicate();			/// waits while condition is true
			}
		}

		public WaitWhile(Func<bool> predicate)
		{
			this.predicate = predicate;
		}
	}

	// Waits until a condition becomes true
	class WaitUntil : YieldInstruction
	{
		private Func<bool> predicate;

		public override bool keepWaiting {
			get {
				return !predicate();         /// waits until condition is true
			}
		}

		public WaitUntil(Func<bool> predicate)
		{
			this.predicate = predicate;
		}
	}

	// Waits for a given amount of in game time 
	class WaitForSeconds : YieldInstruction
	{
		private float targetTime;

		public override bool keepWaiting {
			get {
				return Time.time < targetTime; /// waits until current game time is past target game time
			}
		}

		public WaitForSeconds (float duration)
		{
			targetTime = Time.time + duration;
		}
	}

	// Waits for a given amount of real time 
	class WaitForSecondsRealtime : YieldInstruction
	{
		private float targetTime;

		public override bool keepWaiting {
			get {
				return Time.unscaledTime < targetTime; /// waits until current real time is past target real time
			}
		}

		public WaitForSecondsRealtime(float duration)
		{
			targetTime = Time.unscaledTime + duration;
		}
	}
}
