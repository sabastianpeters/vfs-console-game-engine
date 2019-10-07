using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Runesole.Engine.Graphics;


/*
	Copyright (C) 2019 Sabastian Peters, Yuya Yoshino
*/

namespace Runesole
{
	static class SpriteManager
	{
		// Player Sprites
		public static Sprite player_idle;
		public static Sprite player_attack_right;
		public static Sprite player_attack_left;
		public static Sprite player_attack_up;
		public static Sprite player_attack_down;

		// Enemy Sprites
		public static Sprite enemy;

		// Create all sprites
		public static void GenerateSprites ()
		{
			// Player Sprites
			player_idle = new Sprite(1, 1);
			player_idle.SetSpit(0, 0, new Spit('■', Color.Forground.Blue)); /// head

			player_attack_right = new Sprite(3, 1);
			player_attack_right.SetSpit(0, 0, new Spit('■', Color.Forground.Blue)); /// head
			player_attack_right.SetSpit(1, 0, new Spit('═', Color.Forground.BrightRed));
			player_attack_right.SetSpit(2, 0, new Spit('═', Color.Forground.BrightRed));

			player_attack_left = new Sprite(3, 1, new Coord(2, 0));
			player_attack_left.SetSpit(2, 0, new Spit('■', Color.Forground.Blue)); /// head
			player_attack_left.SetSpit(1, 0, new Spit('═', Color.Forground.BrightRed));
			player_attack_left.SetSpit(0, 0, new Spit('═', Color.Forground.BrightRed));

			player_attack_up = new Sprite(1, 2, new Coord(0, 1));
			player_attack_up.SetSpit(0, 1, new Spit('■', Color.Forground.Blue)); /// head
			player_attack_up.SetSpit(0, 0, new Spit('║', Color.Forground.BrightRed)); /// attack

			player_attack_down = new Sprite(1, 2);
			player_attack_down.SetSpit(0, 0, new Spit('■', Color.Forground.Blue)); /// head
			player_attack_down.SetSpit(0, 1, new Spit('║', Color.Forground.BrightRed)); /// attack



			// Enemy Sprites
			enemy = new Sprite(1, 1);
			enemy.SetSpit(0, 0, new Spit('■', Color.Forground.Red)); /// head

		}
	}
}
