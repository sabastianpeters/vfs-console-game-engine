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
		public int Width { get; private set; }
		public int Height { get; private set; }

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


        public void Rect(int x, int y, int width, int height, WorldBlock fill)
        {
            for (int drawX = x; drawX < x + width; drawX++)
            {
                for (int drawY = y; drawY < y + height; drawY++)
                {
                    SetBlockAt(drawX, drawY, fill);
                }
            }
        }

        public void Rect(int x, int y, int width, int height, params WorldBlock[] fill)
        {
            for (int drawX = x; drawX < x + width; drawX++)
            {
                for (int drawY = y; drawY < y + height; drawY++)
                {
                    SetBlockAt(drawX, drawY, fill[Random.Range(0, fill.Length)]);
                }
            }
        }


        public WorldBlock GetBlockAt(int worldX, int worldY)
		{
			if (0 <= worldX && worldX < Width && 0 <= worldY && worldY < Height)
				return blockGrid[worldX][worldY];
			return WorldBlock.deepWaterBlock;
		}

		public void SetBlockAt(int x, int y, WorldBlock block)
		{
			if (0 <= x && x < Width && 0 <= y && y < Height)
				blockGrid[x][y] = block;
		}

		public bool CanWalkAt(Vector2 v)
		{
			return !(GetBlockAt(Mathf.CeilToInt(v.x - 1f), Mathf.RoundToInt(v.y)).isCollidable);
		}

		public World (int width, int height)
		{
			this.Width = width;
			this.Height = height;


			// Initializes the world array with stone blocks
			blockGrid = new WorldBlock[width][];
			for(int x = 0; x < width; x++)
			{
				blockGrid[x] = new WorldBlock[height];

				for (int y = 0; y < height; y++)
				{
					blockGrid[x][y] = WorldBlock.deepWaterBlock;
				}
			}

            blockGrid[0][0]  = new WorldBlock(false, new Spit('X', Color.Background.Red));
		}
	}
}
