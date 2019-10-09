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

        public float experience = 0f;
        public float maxExperience = 10f;
        public int level;


        void Start()
		{
            level = 1;
            health = 10;
            maxHealth = 10;
            attackDmg = 2;
            moveSpeed = 1f;

			if (main == null)
				main = this; // if no main player, become the main one
		}

		void Update ()
		{
            sprite = SpriteManager.player_idle; /// by default draws base player

            DoMovement();
            DoAttack();
            Camera.main.position = position;
		}

        void DoAttack()
        {
			
            if (Input.GetKeyDown(Controls.attack) || Input.GetKey(Controls.attack))
			{
				sprite = SpriteManager.player_attack;
			}
        }

        void DoMovement()
        {
            float x = 0, y = 0;

            if (Input.GetKey(Controls.moveUp))
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
                if ((int)Mathf.Abs(x) == 0 && (int)Mathf.Abs(y) == 0)
                {
                    x *= 0.707f;
                    y *= 0.707f;
                }


                x *= Time.deltaTime * walkSpeed;
                y *= Time.deltaTime * walkSpeed;

                position = new Vector2(position.x + x, position.y + y);
            }
        }

        public void AddExp (float gainedExperience)
        {
            experience += gainedExperience;
            while ((experience) >= maxExperience) /// if the current exp and exp gained is equal to or greater then the max exp, level up
            {
                experience = experience - maxExperience;
                LevelUp();
                maxExperience = maxExperience * 1.1f;
            }
        }

        void LevelUp ()
        {
            level++;
            maxHealth += 2;
            attackDmg += 1;
            moveSpeed += 0.02f;
        }
    }
}
