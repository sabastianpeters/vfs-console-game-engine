using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Runesole.Engine
{	
	// a reference to an currently running coroutine
	class Coroutine
	{
		public IEnumerator enumerator;

		public Coroutine (IEnumerator enumerator)
		{
			this.enumerator = enumerator;
		}
	}
}
