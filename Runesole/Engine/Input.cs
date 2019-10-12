using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;



/*
	Copyright (C) 2019 Sabastian Peters, Yuya Yoshino
*/

namespace Runesole.Engine
{
	static class Input
	{
		
		// ## PRIVATE UTILITY MEMBERS ##

		// Dictionary <key-code, is-pressed>
		private static Dictionary<Key, bool> _lastKeysPressed;	/// what keys were pressed last frame
		private static Dictionary<Key, bool> _keysPressed;      /// what keys are currently pressed
		private static IEnumerator<Key> _keyEnumerator;			/// a list of keys to enumerate over



		// ## PUBLIC METHODS ##

		public static bool  GetKeyDown (Key key)
		{
			return	!_lastKeysPressed[key] && _keysPressed[key]; /// wasn't pressed, now is
		}

		public static bool GetKey(Key key)
		{
			return _lastKeysPressed[key] && _keysPressed[key]; /// was pressed, still is
		}

		public static bool GetKeyUp(Key key)
		{
			return _lastKeysPressed[key] && !_keysPressed[key]; /// was pressed, now isn't
		}



		// ## PUBLIC ENGINE METHODS ##

		// run at start of frame
		public static void Update()
		{

			/// updates current list of keys pressed
			_keyEnumerator.Reset();
			while (_keyEnumerator.MoveNext())
			{
				Key key = _keyEnumerator.Current;
				_keysPressed[key] = _isKeyPressed(key);
			}
		}

		// run at end of frame
		public static void LateUpdate()
		{
			_lastKeysPressed = new Dictionary<Key, bool>(_keysPressed); /// pushes current key pressed to last key presses for next frame
		}

		// initializes the input class
		public static void Init ()
		{
			// Generates a list of keys to listen to
			List<Key> keysToListenTo = new List<Key>();
			foreach (Key key in (Key[])Enum.GetValues(typeof(Key)))
				keysToListenTo.Add(key); /// all keys are by default not pressed (index is used here in case key exists in list already - was getting error)
			keysToListenTo.Remove((Key)0);

			_keyEnumerator = keysToListenTo.GetEnumerator();


			// listens to key presses from all keys in the "Key" enum
			_keysPressed = new Dictionary<Key, bool>();
			foreach (Key key in keysToListenTo)
				_keysPressed[key] = false; /// all keys are by default not pressed (index is used here in case key exists in list already - was getting error)
			
			_lastKeysPressed = new Dictionary<Key, bool>(_keysPressed); /// creates a copy of dictionary for last keys pressed

			
		}


		// ## PRIVATE UTILITY METHODS ##

		// returns if a given key is currently pressed
		private static bool _isKeyPressed(Key key)
		{
			return (Keyboard.GetKeyStates(key) & KeyStates.Down) > 0;
		}
	}
}
