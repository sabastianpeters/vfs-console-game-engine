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

		// ## PUBLIC MEMBERS ##
		public Vector2 position;	/// position of gameobject
		public Sprite sprite;		/// what to draw for gameobject

		// ## PRIVATE MEMBERS ##
		private Action start;	/// this game object's start event
		private Action update;  /// this game object's update event


		// ## PUBLIC METHODS ##

		// Destory the gameobject // ideally, Create() would exist too
		public void Destroy()
		{
			destroyGameObjectList.Add(this); /// adds to a list to be destroyed
		}


		// ## PRIVATE UTILITY METHODS ##

		// Creates an Action Delegate based off this game object's method that starts with provided methodName
		private void _GetEvent(string methodName, out Action action)
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
		private void DoNothing() { } /// An empty method that's called when an event doesn't exist in a gameobject



		// ## CONSTRUCTOR ##

		/// Protected constructor (prevents external classes from creating gameobjects, but child classes can still be created)
		protected GameObject ()
		{
			position = Vector2.zero;
			sprite = new Sprite(0, 0);

			// Registers events
			_GetEvent("Start", out start);
			_GetEvent("Update", out update);

			// adds new game object to gameobject list
			if(Program.mainLoopStarted)
				addingGameObjectList.Add(this);	/// if main loop started, wait until end to add
			else
				gameObjectList.Add(this);		/// otherwise add right away
		}







		// ## STATIC UTILITY VARIABLES ## 

		public static List<GameObject> gameObjectList = new List<GameObject>();			/// list of game objects in world to loop over // if i added scenes, it should have gone there (root GO and loop through children)
		private static List<GameObject> destroyGameObjectList = new List<GameObject>();	/// list of GOs to destroy at end of frame
		private static List<GameObject> addingGameObjectList = new List<GameObject>();  /// list of GOs to create at end of frame

		// Calls start event on all gameobjects
		public static void __CallStartEvent()
		{
			foreach (GameObject gameObject in gameObjectList)
				gameObject.start();
		}

		// Calls update event on all gameobjects
		public static void __CallUpdateEvent()
		{
			foreach (GameObject gameObject in gameObjectList)
				gameObject.update();
		}

		// Draws all gameobjects
		public static void __DrawGameObjects(Camera camera)
		{
			for (int i = gameObjectList.Count - 1; 0 <= i; i--)
			{
				GameObject gameObject = gameObjectList[i];
				Camera.main.Draw(gameObject.position.x, gameObject.position.y, gameObject.sprite);
			}
		}

		// Destroys GOs in destroy queue
		public static void __DestroyGameObjects()
		{
			/// while there are objects to destory, destroy them
			while (destroyGameObjectList.Count > 0)
			{
				gameObjectList.Remove(destroyGameObjectList[0]); /// removes the gameobject from the list, so its not drawn or updated
				destroyGameObjectList.RemoveAt(0);
			}
		}

		// Adds GOs in create queue
		public static void __AddGameObjects()
		{
			/// while there are objects to add, add them
			while (addingGameObjectList.Count > 0)
			{
				gameObjectList.Add(addingGameObjectList[0]); /// adds the gameobject to the list, so its drawn and updated
				addingGameObjectList.RemoveAt(0);
			}
		}

	}
}
