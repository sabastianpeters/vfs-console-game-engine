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
	// a reference to an currently running coroutine
	class Coroutine
	{
		public IEnumerator enumerator; /// a reference to the current enumerator 


		// ## CONSTRUCTOR ##

		public Coroutine (IEnumerator enumerator)
		{
			this.enumerator = enumerator;
		}
	}
}
