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
        private static World mainWorld;

		static Player player;

		/// Called at start of program
		public static void Start ()
		{
			player = new Player();
			camera = new Camera();

			player.position = new Vector2(80,40);

            CreateWorlds();

            for (int i = 0; i < 10; i++)
			{
                MeleeEnemy enemy1 = new MeleeEnemy();
                enemy1.position = new Vector2(Random.Range(7,153), Random.Range(7, 73));
                enemy1.OnDeath += () => player.AddExp(2f);
			}

            for (int i = 0; i < 10; i++)
            {
                RangedEnemy enemy2 = new RangedEnemy();
                enemy2.position = new Vector2(Random.Range(7, 153), Random.Range(7, 73));
                enemy2.OnDeath += () => player.AddExp(2f);
            }
        }

		/// Called at begining of each frame
		public static void Update ()
		{
			Debug.Draw();
            PlayerUI.Draw(player);
		}

		/// Called at end of each frame
		public static void LateUpdate()
		{
		
		}

        private static void CreateWorlds()
        {
            int width = 160;
            int height = 80;

            mainWorld = new World(width, height);
            mainWorld.Rect(0, 0, width, height, WorldBlock.deepWaterBlock);
            mainWorld.Rect(3, 3, width - 3, height - 3, WorldBlock.waterBlock);
            mainWorld.Rect(7, 7, width - 7, height - 7, WorldBlock.water);
            mainWorld.Rect(10, 10, width - 10, height - 10, WorldBlock.sand);
            mainWorld.Rect(15, 15, width - 15, height - 15, WorldBlock.cutGrass);
            mainWorld.Rect(22, 22, width - 22, height - 22, WorldBlock.grass1);
            mainWorld.Rect(23, 23, width - 23, height - 23,
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


            world = mainWorld;
        }
	}
}
