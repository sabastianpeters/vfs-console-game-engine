using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Runesole.Engine;
using Runesole.Engine.Graphics;


/*
	Copyright (C) 2019 Sabastian Peters, Yuya Yoshino

	A lot of the code is heavily inspired by Unity. Classes and properties are named after them.
	Not sure if it works the same behind the scenes, but for most part it's consistent in code.
*/


namespace Runesole.Engine
{

	static class Program
	{

		[STAThread] /// required to read user input multiple keys at a time
		static void Main(string[] args)
		{
			
			// Displays a loading message for user
			Console.Write("Loading");
			System.Threading.Thread.Sleep(100);

			// Setup console for a game
			NativeFunctions.InitializeConsole();	/// sets up console for use (no clicks, no arrow keys, etc)
			Console.TreatControlCAsInput = true;	/// prevents keyboard inturrupts, only reads input


			// Initialize engine classes
			ConsoleRenderer.Init();
			Input.Init();
			Time.Init();
            Runesole.Engine.Random.Init();

			// Game Setup
			SpriteManager.GenerateSprites();	/// generates sprites
			WorldBlock.Init();					/// generates world blocks
			GameManager.Start();				/// starts the game logic
			GameObject.CallStartEvent();		/// calls start event on all gameobjects
			Console.Clear();					/// clears the screen once everything is loaded

			while (true)
			{
				// updates engine classes
				Time.Update();
				Input.Update();
				ConsoleRenderer.Update();

				// core game
				GameObject.CallUpdateEvent();					/// Preforms game logic on gameobjects
				GameManager.Update();                           /// updates game logic
				GameManager.camera.Update();					///	updates camera
				GameManager.world.Draw(GameManager.camera);		/// draws the world
				GameObject.DrawGameObjects(GameManager.camera);	/// draws game objects
				UI.Draw();										///	draws UI
				ConsoleRenderer.Render();						/// renders everything (UI & world) to console

				// updates engine classes end of frame
				GameManager.LateUpdate();
				Input.LateUpdate();
				Time.LateUpdate();
			}

		}

		static System.Collections.IEnumerator SimpleCoroutine ()
		{
			yield return null;
			
			bool toggled = true;

			while(true)
			{
				float timeStarted = Time.time;
				while (Time.time < timeStarted + 1)
				{
					yield return null;
				}


				UI.String(Coord.BottomLeft, "HEY: "+toggled.ToString());


				toggled = !toggled;
			}
		}
	}
}
