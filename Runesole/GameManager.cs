using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Runesole.Engine;

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


        // Different worlds
        private static World m_mainWorld;
		private static Player m_player;

		/// Called at start of program
		public static void Start ()
		{
			m_player = new Player();
			camera = new Camera();

			m_player.position = new Vector2(80,40);

            CreateWorlds();

            EnemyManager.SpawnEnemies();
        }

		/// Called at begining of each frame
		public static void Update ()
		{
			Debug.Draw();
            PlayerUI.Draw(m_player);
		}

		/// Called at end of each frame
		public static void LateUpdate()
		{
		
		}

        private static void CreateWorlds()
        {
            int width = 160;
            int height = 80;

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

			int posX = Random.Range(25, 135);
			int posY = Random.Range(25, 55);

			m_mainWorld.Rect(posX, posY, 10, 10, WorldBlock.stoneWall);
			m_mainWorld.Rect(posX + 1, posY + 1, 8, 8, WorldBlock.stone);
			m_mainWorld.SetBlockAt(posX, posY + 3, WorldBlock.stone);
			m_mainWorld.SetBlockAt(posX, posY + 4, WorldBlock.stone);

			world = m_mainWorld;
        }
	}
}
