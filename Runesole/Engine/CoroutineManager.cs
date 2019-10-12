using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*
	Copyright (C) 2019 Sabastian Peters, Yuya Yoshino
*/

namespace Runesole.Engine
{
	static class CoroutineManager
	{

		// ## PRIVATE UTILITY MEMBERS ##

		private static List<Coroutine> coroutineList = new List<Coroutine>();		/// a list of coroutines to iterate over
		private static List<Coroutine> tempCoroutineList = new List<Coroutine>();	/// a list of coroutines to iterate over next frame (temp)



		// ## PUBLIC ENGINE METHODS ##

		// iterates over all queued coroutines
		public static void Update ()
		{
			// iterates over each coroutine and moves next
			foreach (Coroutine coroutine in coroutineList)
			{
				/// if current element is an YieldInstruction that says we should wait, skip moving next
				if (coroutine.enumerator.Current is YieldInstruction && ((YieldInstruction)coroutine.enumerator.Current).keepWaiting)
				{
					tempCoroutineList.Add(coroutine);
					continue;
				}

				/// skips coroutines that have no more instructions (not called again)
				if (!coroutine.enumerator.MoveNext())	
					continue;
					

				tempCoroutineList.Add(coroutine);
			}

			// updates coroutine list and resets temp list
			coroutineList = new List<Coroutine>(tempCoroutineList);	
			tempCoroutineList.Clear();
		}


		// ## PUBLIC METHODS ##

		// calls a coroutine using an IEnumerator
		public static void Call (IEnumerator enumerator)
		{
			Call(new Coroutine(enumerator));
		}

		// calls a coroutine
		public static void Call(Coroutine coroutine)
		{
			coroutineList.Add(coroutine);
		}

		// cancles a given coroutine
		public static void Cancel (Coroutine coroutine)
		{
			coroutineList.Remove(coroutine); /// removes the coroutine instance
		}
	}
}
