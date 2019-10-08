﻿using System;
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


		static Player player;

		/// Called at start of program
		public static void Start ()
		{
			world = new World(160, 80);
			player = new Player();
			camera = new Camera();

			player.position = Vector2.one * 10;

			world.SetBlockAt(10, 10, WorldBlock.grass);
			world.SetBlockAt(11, 10, WorldBlock.grass);

			for(int i = 0; i < 10; i++)
			{
                MeleeEnemy enemy1 = new MeleeEnemy();
                enemy1.position = new Vector2(i* 2, 0);
                enemy1.OnDeath += () => player.AddExp(2f);
			}

            for (int i = 0; i < 10; i++)
            {
                RangedEnemy enemy2 = new RangedEnemy();
                enemy2.position = new Vector2(i + 3, i * 3);
                enemy2.OnDeath += () => player.AddExp(2f);
            }
        }

		/// Called at begining of each frame
		public static void Update ()
		{
			
		}

		/// Called at end of each frame
		public static void LateUpdate()
		{
		
		}
	}
}
