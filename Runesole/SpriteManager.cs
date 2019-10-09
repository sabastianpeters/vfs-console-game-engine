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
        public static Sprite player_attack;

		// Enemy Sprites
		public static Sprite enemy_ranged;
        public static Sprite enemy_melee;

        // Create all sprites
        public static void GenerateSprites ()
		{
			// Player Sprites
			player_idle = new Sprite(1, 1);
			player_idle.SetSpit(0, 0, new Spit(' ', Color.Background.Blue)); /// head

            player_attack = new Sprite(3, 3, new Coord(1, 1));
            player_attack.SetSpit(1, 1, new Spit(' ', Color.Background.Blue));
            player_attack.SetSpit(2, 1, new Spit('%', Color.Forground.BrightRed));
            player_attack.SetSpit(2, 2, new Spit('%', Color.Forground.BrightRed));
            player_attack.SetSpit(0, 0, new Spit('%', Color.Forground.BrightRed));
            player_attack.SetSpit(0, 1, new Spit('%', Color.Forground.BrightRed));
            player_attack.SetSpit(0, 2, new Spit('%', Color.Forground.BrightRed));
            player_attack.SetSpit(1, 2, new Spit('%', Color.Forground.BrightRed));
            player_attack.SetSpit(2, 0, new Spit('%', Color.Forground.BrightRed));
            player_attack.SetSpit(1, 0, new Spit('%', Color.Forground.BrightRed));


            // Melee Enemy Sprites
            enemy_melee = new Sprite(1, 1);
			enemy_melee.SetSpit(0, 0, new Spit(' ', Color.Background.Red)); /// head

            // Ranged Enemy Sprites
            enemy_ranged = new Sprite(1, 1);
            enemy_ranged.SetSpit(0, 0, new Spit(' ', Color.Background.Magenta)); /// head

        }
    }
}
