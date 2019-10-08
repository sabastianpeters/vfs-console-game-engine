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
		public static Sprite enemy_ranged;
        public static Sprite enemy_melee;

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



			// Melee Enemy Sprites
			enemy_melee = new Sprite(1, 1);
			enemy_melee.SetSpit(0, 0, new Spit('■', Color.Forground.Red)); /// head

            // Ranged Enemy Sprites
            enemy_ranged = new Sprite(1, 1);
            enemy_ranged.SetSpit(0, 0, new Spit('■', Color.Forground.Magenta)); /// head

        }
    }
}
