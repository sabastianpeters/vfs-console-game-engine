using System;
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
	class Player : LivingEntitiy
	{
		public static Player main;
		
		private const float walkSpeed = 10f;
		private const float runSpeed = 20f;

		public int health = 100;


		void Start()
		{
			if (main == null)
				main = this; // if no main player, become the main one
		}

		void Update ()
		{
			float x = 0, y = 0;

			if(Input.GetKey(Controls.moveUp))
			{
				y++;
			}
			if (Input.GetKey(Controls.moveDown))
			{
				y--;
			}
			if (Input.GetKey(Controls.moveLeft))
			{
				x--;
			}
			if (Input.GetKey(Controls.moveRight))
			{
				x++;
			}


			if (x == 0 && y == 0)
			{
				position = new Vector2(Mathf.Round(position.x), Mathf.Round(position.y));
			}
			else
			{
				// If going on a diagonal, normalize the vector (always same movement speed)
				if((int)Mathf.Abs(x) == 0 && (int)Mathf.Abs(y) == 0)
				{
					x *= 0.707f;
					y *= 0.707f;
				}


				float speed = Input.GetKey(Controls.run) ? runSpeed : walkSpeed;
				x *= Time.deltaTime * speed;
				y *= Time.deltaTime * speed;

				position = new Vector2(position.x + x, position.y + y);
			}


			sprite = SpriteManager.player_idle; /// by default draws base player

			if (Input.GetKeyDown(Controls.attackRight))
				AttackRight();
			if (Input.GetKeyDown(Controls.attackLeft))
				AttackLeft();
			if (Input.GetKeyDown(Controls.attackUp))
				AttackUp();
			if (Input.GetKeyDown(Controls.attackDown))
				AttackDown();
			
			Camera.main.position = position;
		}
		

		void AttackRight ()
		{
			sprite = SpriteManager.player_attack_right;
		}
		void AttackLeft()
		{
			sprite = SpriteManager.player_attack_left;
		}
		void AttackUp()
		{
			sprite = SpriteManager.player_attack_up;
		}
		void AttackDown()
		{
			sprite = SpriteManager.player_attack_down;
		}
	}
}
