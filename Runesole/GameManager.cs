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

            for (int i = 0; i < 10; i++)
			{
				MeleeEnemy enemy = EnemyManager.SpawnEnemy<MeleeEnemy>(Random.Range(7, 153), Random.Range(7, 73));
				enemy.OnDeath += () => m_player.AddExp(2f);
			}

            for (int i = 0; i < 10; i++)
			{
				RangedEnemy enemy = EnemyManager.SpawnEnemy<RangedEnemy>(Random.Range(7, 153), Random.Range(7, 73));
				enemy.OnDeath += () => m_player.AddExp(2f);
			}
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
            m_mainWorld.Rect(3, 3, width - 3, height - 3, WorldBlock.waterBlock);
            m_mainWorld.Rect(7, 7, width - 7, height - 7, WorldBlock.water);
            m_mainWorld.Rect(10, 10, width - 10, height - 10, WorldBlock.sand);
            m_mainWorld.Rect(15, 15, width - 15, height - 15, WorldBlock.cutGrass);
            m_mainWorld.Rect(22, 22, width - 22, height - 22, WorldBlock.grass1);
            m_mainWorld.Rect(23, 23, width - 23, height - 23,
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


            world = m_mainWorld;
        }
	}
}
