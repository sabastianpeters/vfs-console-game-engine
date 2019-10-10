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
            CreateRoom();

            SpawnMobs();
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

        private static void SpawnMobs()
        {
            //spawns melee enemies
            for (int i = 0; i < 10; i++)
            {
                MeleeEnemy enemy1 = new MeleeEnemy();
                enemy1.position = new Vector2(Random.Range(7, 153), Random.Range(7, 73));
                enemy1.OnDeath += () => player.AddExp(2f);
            }
            //spawns ranged enemies
            for (int i = 0; i < 10; i++)
            {
                RangedEnemy enemy2 = new RangedEnemy();
                enemy2.position = new Vector2(Random.Range(7, 153), Random.Range(7, 73));
                enemy2.OnDeath += () => player.AddExp(2f);
            }
        }

        //creates the map
        private static void CreateWorlds()
        {
            int width = 160;
            int height = 80;

            mainWorld = new World(width, height);
            mainWorld.Rect(0, 0, width, height, WorldBlock.deepWaterBlock);
            mainWorld.Rect(3, 3, width - 6, height - 6, WorldBlock.waterBlock);
            mainWorld.Rect(7, 7, width - 14, height - 14, WorldBlock.water);
            mainWorld.Rect(10, 10, width - 20, height - 20, WorldBlock.sand);
            mainWorld.Rect(15, 15, width - 30, height - 30, WorldBlock.cutGrass);
            mainWorld.Rect(22, 22, width - 44, height - 44, WorldBlock.grass1);
            mainWorld.Rect(23, 23, width - 46, height - 46,
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

        private static void CreateRoom()
        {
            int posX = Random.Range(25, 135);
            int posY = Random.Range(25, 55);

            mainWorld.Rect(posX, posY, 10, 10, WorldBlock.stoneWall);
            mainWorld.Rect(posX + 1, posY + 1, 8, 8, WorldBlock.stone);
            mainWorld.SetBlockAt(posX, posY + 3, WorldBlock.stone);
            mainWorld.SetBlockAt(posX, posY + 4, WorldBlock.stone);
        }
	}
}
