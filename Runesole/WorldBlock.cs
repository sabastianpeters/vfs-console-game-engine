using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Runesole.Engine.Graphics;

/*
	Copyright (C) 2019 Sabastian Peters, Yuya Yoshino
*/

namespace Runesole.Engine
{
	struct WorldBlock
	{
		// Static reference to blocks
		public static WorldBlock stoneWall;
		public static WorldBlock stone;
		public static WorldBlock grass1;
        public static WorldBlock grass2;
        public static WorldBlock deepWaterBlock; // deep water you cant walk on
        public static WorldBlock waterBlock; // water you cant walk on
        public static WorldBlock water; // water you can walk on
        public static WorldBlock sand;
        public static WorldBlock cutGrass;
        public static WorldBlock door;

        // Struct members
        public bool isCollidable;
		public Spit spit;

		// Constructor for a world block
		public WorldBlock(bool isCollidable, Spit spit)
		{
			this.isCollidable = isCollidable;
			this.spit = spit;
		}

		// An empty block
		public static WorldBlock empty {
			get {
				return new WorldBlock(false, new Spit(' ', Color.Foreground.None, Color.Background.None));
			}
		}



		// Initializes WorldBlocks (generates the block list)
		public static void Init ()
		{
			stoneWall = new WorldBlock(
				true,
				new Spit('▒', Color.Foreground.LightGray, Color.Background.DarkGray)
			);

            deepWaterBlock = new WorldBlock(
                true,
                new Spit(' ', Color.Foreground.None, Color.Background.BrightBlue)
            );

            waterBlock = new WorldBlock(
                true,
                new Spit(' ', Color.Foreground.None, Color.Background.Cyan)
            );

            water = new WorldBlock(
                false,
                new Spit(' ', Color.Foreground.None, Color.Background.BrightCyan)
            );

            sand = new WorldBlock(
                false,
                new Spit(' ', Color.Foreground.None, Color.Background.BrightYellow)
            );

            stone = new WorldBlock(
				false,
				new Spit(' ', Color.Background.DarkGray)
			);

            cutGrass = new WorldBlock(
                false,
                new Spit(' ', Color.Background.BrightGreen)
            );

            grass1 = new WorldBlock(
				false,
				new Spit(' ', Color.Background.Green)
			);

            grass2 = new WorldBlock(
                false,
                new Spit('/', Color.Foreground.BrightGreen, Color.Background.Green)
            );

            door = new WorldBlock(
                false,
                new Spit(' ', Color.Background.Black)
            );
        }
	}
}
