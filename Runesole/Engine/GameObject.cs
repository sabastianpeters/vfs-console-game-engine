using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Runesole.Engine;
using Runesole.Engine.Graphics;


/*
	Copyright (C) 2019 Sabastian Peters, Yuya Yoshino
*/

namespace Runesole
{
	// NOTE: These gameobject are not the same as in Unity
	// An object to be drawn by the world and recieve events
	class GameObject
	{
		public Vector2 position;
		public Sprite sprite;

		public static List<GameObject> gameObjectList = new List<GameObject>();
		public static List<Action> startEvent = new List<Action>();
		public static List<Action> updateEvent = new List<Action>();

		public static void CallEvent (List<Action> listeners)
		{
			foreach(Action action in listeners)
				action();
		}

		public static void DrawGameObjects (Camera camera)
		{
			for(int i = gameObjectList.Count-1; 0 <= i; i--)
			{
				GameObject gameObject = gameObjectList[i];
				Camera.main.Draw(gameObject.position.x, gameObject.position.y, gameObject.sprite);
			}
		}

		
		/// Protected constructor (prevents external classes from creating gameobjects, but child classes can still be created)
		protected GameObject ()
		{
			position = Vector2.zero;
			sprite = new Sprite(0, 0);

			// Registers events
			_RegisterEvent("Start", ref startEvent);
			_RegisterEvent("Update", ref updateEvent);

			// adds new game object to gameobject list
			gameObjectList.Add(this);
		}

		private void _RegisterEvent (string methodName, ref List<Action> eventListeners)
		{
			// Tries to get a method with the given name, exits if not found
			MethodInfo method = GetType().GetMethod(methodName, BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
			if (method == null)
				return;

			/// delegate use to speed up reflection came from: https://blogs.msmvps.com/jonskeet/2008/08/09/making-reflection-fly-and-exploring-delegates/
			eventListeners.Add((Action)Delegate.CreateDelegate(typeof(Action), this, method)); 
		}
	}
}
