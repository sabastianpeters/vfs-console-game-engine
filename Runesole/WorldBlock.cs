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
		public static WorldBlock grass;

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
				return new WorldBlock(false, new Spit(' ', Color.Forground.None, Color.Background.None));
			}
		}



		// Initializes WorldBlocks (generates the block list)
		public static void Init ()
		{

			stoneWall = new WorldBlock(
				true,
				new Spit('▒', Color.Forground.LightGray, Color.Background.DarkGray)
			);

			stone = new WorldBlock(
				false,
				new Spit(' ', Color.Background.DarkGray)
			);

			grass = new WorldBlock(
				false,
				new Spit(' ', Color.Background.Green)
			);
		}
	}
}
