using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Threading.Tasks;
using Runesole.Engine;
using Runesole.Engine.Graphics;

/*
	Copyright (C) 2019 Sabastian Peters, Yuya Yoshino
*/

namespace Runesole
{
	// A utility class to generally manage the game
	static class GameManager
	{

		// ## PUBLIC METHODS ##

		// What world to draw and camera to use (public so Main() can access)
		public static World world;		/// current world rendering (this allows for multiple)
		public static Camera camera;	/// current camera to render (allows for multiple)
		public static bool IsPaused { get; private set; }


        // ## PRIVATE MEMBERS ##

		private static Player m_player;
        private static World m_mainWorld;




		// ## PUBLIC ENGINE METHODS ##

		/// Called at start of program
		public static void Start ()
		{
			//at the start of the game spawns new player and set camera to player
			m_player = new Player();
			SpawnPlayer();
			camera = new Camera();

            //create the world
            CreateWorlds();

            //spawn new enemies on the map
            EnemyManager.SpawnEnemies();
        }


		/// Called at begining of each frame
		public static void Update ()
		{
			// if player is dead, press repawn button to respawn
			if(m_player.IsDead)
			{
				Debug.Log("Press "+Controls.respawnPlayer.ToString()+" to respawn player");

				if (Input.GetKeyDown(Controls.respawnPlayer))
				{
					SpawnPlayer();
				}
			}

			// lets user know game is paused
			if (IsPaused)
				Debug.Log("Game is paused");
			
			// draws player ui
			PlayerUI.Draw(m_player);
		}

		/// Called at end of each frame
		public static void LateUpdate()
		{
			Debug.Draw();
		}




		// ## PUBLIC METHODS ##

		// Toggles if the game is paused and returns if the game was resumed
		public static bool TogglePause()
		{
			if (IsPaused)
				UnpauseGame();
			else
				PauseGame();

			return IsPaused;
		}

		// Pauses the game
		public static void PauseGame()
		{
			IsPaused = true;
			Time.timeScale = 0;
		}

		// Unpauses the game
		public static void UnpauseGame()
		{
			IsPaused = false;
			Time.timeScale = 1;
		}


		// spawn player - ideally this would be in living entity
		public static void SpawnPlayer()
		{
			m_player.ResetHealth();
			m_player.position = new Vector2(80, 40); ///spawn player at the center of the map
		}




		// ## PRIVATE UTILITY VARIABLES ##

		// creates all worlds to be used in game // if there was more than 1 map & map gen was more complex, a class would be needed
		private static void CreateWorlds()
        {
            int width = 160;
            int height = 80;

            //create the world map 160 by 80
            m_mainWorld = new World(width, height);
            m_mainWorld.Rect(0, 0, width, height, WorldBlock.deepWaterBlock);
            m_mainWorld.Rect(3, 3, width - 6, height - 6, WorldBlock.waterBlock);
            m_mainWorld.Rect(7, 7, width - 14, height - 14, WorldBlock.water);
            m_mainWorld.Rect(10, 10, width - 20, height - 20, WorldBlock.sand);
            m_mainWorld.Rect(15, 15, width - 30, height - 30, WorldBlock.cutGrass);
            m_mainWorld.Rect(22, 22, width - 44, height - 44, WorldBlock.grass1);
            m_mainWorld.Rect(23, 23, width - 46, height - 46,
                WorldBlock.grass1,
                WorldBlock.grass1,
                WorldBlock.grass1,
                WorldBlock.grass1,
                WorldBlock.grass1,
                WorldBlock.grass1,
                WorldBlock.grass1,
                WorldBlock.grass1,
                WorldBlock.grass1,
                WorldBlock.grass1,
                WorldBlock.grass1,
                WorldBlock.grass1,
                WorldBlock.grass1,
                WorldBlock.grass1,
                WorldBlock.grass2);

            CreateRoom();

            world = m_mainWorld;
        }

		//create the room on the map at a random position
		private static void CreateRoom()
        {
            //generates a room randomly in the world
            int posX = Random.Range(25, 135);
            int posY = Random.Range(25, 55);

            m_mainWorld.Rect(posX, posY, 10, 10, WorldBlock.stoneWall);
            m_mainWorld.Rect(posX + 1, posY + 1, 8, 8, WorldBlock.stone);
            m_mainWorld.SetBlockAt(posX, posY + 3, WorldBlock.door);
            m_mainWorld.SetBlockAt(posX, posY + 4, WorldBlock.door);
        }
	}
}
