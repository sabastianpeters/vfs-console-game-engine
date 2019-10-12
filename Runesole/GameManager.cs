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
	static class GameManager
	{

		// What world to draw and camera to use (public so Main() can access)
		public static World world;
		public static Camera camera;
		public static bool IsPaused { get; private set; }


        // Different worlds
        private static World m_mainWorld;
		private static Player m_player;

		/// Called at start of program
		public static void Start ()
		{
            //at the start of the game create new player and set camera to player
			m_player = new Player();
			camera = new Camera();

            //spawn player at the center of the map
			m_player.position = new Vector2(80,40);

            //create the world
            CreateWorlds();

            //spawn new enemies on the map
            EnemyManager.SpawnEnemies();

            m_player.OnDeath += () => 
            {
                //ask user if they want to restart

               
            };
        }


		/// Called at begining of each frame
		public static void Update ()
		{

			if (Input.GetKeyDown(Controls.pauseGame))
				//TogglePause();
				UI.Prompt(
					"hey", 
					(option) => {
						switch(option)
						{
							case 0:
								world.SetBlockAt(50, 50, WorldBlock.door);
								break;

							case 1:
								world.SetBlockAt(50, 50, WorldBlock.sand);
								break;
						}
					},
					"Yes",
					"No"
				);
				

			if (IsPaused)
				Debug.Log("Game is paused");
				
			PlayerUI.Draw(m_player);
		}

		/// Called at end of each frame
		public static void LateUpdate()
		{
			Debug.Draw();
		}

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

            //create the room on the map
            CreateRoom();

            world = m_mainWorld;
        }

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


		// Toggles if the game is paused and returns if the game was resumed
		public static bool TogglePause ()
		{
			if(IsPaused)
				UnpauseGame();
			else
				PauseGame();

			return IsPaused;
		}

		// Pauses the game
		public static void PauseGame ()
		{
			IsPaused = true;
			Time.timeScale = 0;
		}

		// Unpauses the game
		public static void UnpauseGame ()
		{
			IsPaused = false;
			Time.timeScale = 1;
		}
	}
}
