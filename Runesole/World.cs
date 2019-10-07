using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Runesole.Engine;
using Runesole.Engine.Graphics;

/*
	Copyright (C) 2019 Sabastian Peters, Yuya Yoshino
*/

namespace Runesole
{
	class World
	{

		private WorldBlock[][] blockGrid; 
		private int width;
		private int height;

		public void Draw (Camera camera)
		{

			// Creates a sprite the size of the console and sets origin to the center (so we can draw from camera position)
			Sprite worldSprite = new Sprite(ConsoleRenderer.Width, ConsoleRenderer.Height, new Coord(ConsoleRenderer.Width/2, ConsoleRenderer.Height/2));

			Coord screenOrigin = camera.WorldtoScreen(0, 0); /// finds the screen pos of world origin (always 0,0 and builds up-right)
			for(int x = 0; x < worldSprite.width; x++)
			{
				for (int y = 0; y < worldSprite.height; y++)
				{

					worldSprite.SetSpit(
						x, 
						y,
						// gets world data 
						GetBlockAt(
							x - screenOrigin.x,	/// draws relative to camera and centered, from left of map
							-(y - screenOrigin.y)	/// draws relative to camera, centered, from bottom of map
						).spit
					);
				}
			}

			
			worldSprite.Draw(camera.WorldtoScreen(camera.position));

			// Room Test
			// Sprite room = Rect(40, 20, new Spit(' ', Color.Background.DarkGray), new Spit('▒', Color.Forground.LightGray, Color.Background.DarkGray));
			// Camera.main.Draw(0, 0, room);
		}



		public bool GetCollisionAt (int x, int y)
		{
			return GetBlockAt(x, y).isCollidable;
		}


		public void Rect(int x, int y, int width, int height, WorldBlock fill, WorldBlock wall)
		{

			int drawX = x, drawY = y;

			/// sets top and bottom rows
			for (drawX = x; drawX < width; drawX++)
			{
				SetBlockAt(drawX, 0, wall);
				SetBlockAt(drawX, height-1, wall);
			}


			for (drawY = y+1; drawY < height-1; drawY++)
			{
				drawX = x;
				SetBlockAt(drawX++, drawY, wall); /// left wall
				SetBlockAt(drawX++, drawY, wall); /// left wall

				while (drawX < width-2)
				{
					SetBlockAt(drawX++, drawY, fill); // center fill
				}

				SetBlockAt(drawX++, drawY, wall); /// right wall
				SetBlockAt(drawX++, drawY, wall); /// right wall
			}
			
		}


		public WorldBlock GetBlockAt(int x, int y)
		{
			if (0 <= x && x < width && 0 <= y && y < height)
				return blockGrid[x][y];
			return WorldBlock.empty;
		}

		public void SetBlockAt(int x, int y, WorldBlock block)
		{
			if (0 <= x && x < width && 0 <= y && y < height)
				blockGrid[x][y] = block;
		}


		public World (int width, int height)
		{
			this.width = width;
			this.height = height;
			Random rand = new Random();
			

			// Initializes the world array with stone blocks
			blockGrid = new WorldBlock[width][];
			for(int x = 0; x < width; x++)
			{
				blockGrid[x] = new WorldBlock[height];

				for (int y = 0; y < height; y++)
				{
					blockGrid[x][y] = WorldBlock.stone;
				}
			}

			blockGrid[0][0]  = new WorldBlock(false, new Spit('X', Color.Background.Red));
		}
	}
}
