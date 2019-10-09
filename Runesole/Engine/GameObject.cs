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
		
		private Action start;
		private Action update;

		public static void CallStartEvent ()
		{
			foreach(GameObject gameObject in gameObjectList)
				gameObject.start();
		}

		public static void CallUpdateEvent()
		{
			foreach (GameObject gameObject in gameObjectList)
				gameObject.update();
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
			start = _RegisterEvent("Start");
			update = _RegisterEvent("Update");

			// adds new game object to gameobject list
			gameObjectList.Add(this);
		}

		private Action _RegisterEvent (string methodName)
		{
			// Tries to get a method with the given name, exits if not found
			MethodInfo method = GetType().GetMethod(methodName, BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
			if (method == null)
				return DoNothing;

			/// delegate use to speed up reflection came from: https://blogs.msmvps.com/jonskeet/2008/08/09/making-reflection-fly-and-exploring-delegates/
			return (Action)Delegate.CreateDelegate(typeof(Action), this, method); 
		}

		// An empty method that's called when an event doesn't exist in a gameobject
		private void DoNothing () {}






		// Destory the gameobject
		public void Destroy ()
		{
			gameObjectList.Remove(this); /// removes the gameobject from the list, so its not drawn or updated
		}

	}
}
