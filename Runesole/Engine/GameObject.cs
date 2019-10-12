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

		private static List<GameObject> destroyGameObjectList = new List<GameObject>();
		private static List<GameObject> addingGameObjectList = new List<GameObject>();

		private static bool shouldQueueAddedGameObjects = false;

		private Action start;
		private Action update;

		public static void __CallStartEvent ()
		{
			foreach(GameObject gameObject in gameObjectList)
				gameObject.start();
			shouldQueueAddedGameObjects = true;
		}

		public static void __CallUpdateEvent()
		{
			foreach (GameObject gameObject in gameObjectList)
				gameObject.update();
		}

		public static void __DrawGameObjects (Camera camera)
		{
			for(int i = gameObjectList.Count-1; 0 <= i; i--)
			{
				GameObject gameObject = gameObjectList[i];
				Camera.main.Draw(gameObject.position.x, gameObject.position.y, gameObject.sprite);
			}
		}

		public static void __DestroyGameObjects ()
		{
			/// while there are objects to destory, destroy them
			while (destroyGameObjectList.Count > 0)
			{
				gameObjectList.Remove(destroyGameObjectList[0]); /// removes the gameobject from the list, so its not drawn or updated
				destroyGameObjectList.RemoveAt(0);
			}
		}

		public static void __AddGameObjects ()
		{
			/// while there are objects to add, add them
			while (addingGameObjectList.Count > 0)
			{
				gameObjectList.Add(addingGameObjectList[0]); /// adds the gameobject to the list, so its drawn and updated
				addingGameObjectList.RemoveAt(0);
			}
		}


		/// Protected constructor (prevents external classes from creating gameobjects, but child classes can still be created)
		protected GameObject ()
		{
			position = Vector2.zero;
			sprite = new Sprite(0, 0);

			// Registers events
			_GetEvent("Start", out start);
			_GetEvent("Update", out update);

			// adds new game object to gameobject list
			if(shouldQueueAddedGameObjects)
				addingGameObjectList.Add(this);
			else
				gameObjectList.Add(this);
		}

		private void _GetEvent (string methodName, out Action action)
		{
			// Tries to get a method with the given name, exits if not found
			MethodInfo method = GetType().GetMethod(methodName, BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
			if (method == null)
			{
				action = DoNothing;
				return;
			}

			/// delegate use to speed up reflection came from: https://blogs.msmvps.com/jonskeet/2008/08/09/making-reflection-fly-and-exploring-delegates/
			action = (Action)Delegate.CreateDelegate(typeof(Action), this, method); 
		}

		// An empty method that's called when an event doesn't exist in a gameobject
		private void DoNothing () {}






		// Destory the gameobject
		public void Destroy ()
		{
			destroyGameObjectList.Add(this); /// adds to a list to be destroyed
		}

	}
}
