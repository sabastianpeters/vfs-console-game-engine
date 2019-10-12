using System.Collections;
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

        public float experience = 0f;
        public float maxExperience = 10f;
        public int level = 1;


        void Start()
		{
            //sets all stats at the beginning of the game
            level = 1;
            maxHealth = 15;
			ResetHealth();
            attackDmg = 2;
			attackRange = 2f;
            moveSpeed = 7f;

			if (main == null)
				main = this; // if no main player, become the main one

			CoroutineManager.Call(RegenHealth());
		}

		void Update ()
		{
            //update player every sec
            sprite = SpriteManager.player_idle; /// by default draws base player
			
			// only runs player controls when game isn't paused
			if(!GameManager.IsPaused)
			{
				DoMovement();
				RegenHealth();
				DoAttack();
			}

			Camera.main.position = position;

        }

        public IEnumerator RegenHealth()
        {
			while(true)
			{
				yield return new WaitForSeconds(1f);
				health += level / 10f;
				yield return null;
			}
        }

        void DoAttack()
        {
			for(int i = 0; i < EnemyManager.enemyList.Count; i++)
			{
				// Attacks enemy and if enemy is in range of player, attack the player
				Enemy enemy = EnemyManager.enemyList[i];

				// Player attack
				if (Input.GetKeyDown(Controls.attack) || Input.GetKey(Controls.attack)) //checks for attack key input
				{
					sprite = SpriteManager.player_attack;
					Attack(enemy);
				}

				if(!enemy.IsDead) //checks if the enemy is dead if not, attack player
				{
					enemy.Attack(this); /// attack player
				}
			}
        }

        void DoMovement()
        {
            float x = 0, y = 0;

            if (Input.GetKey(Controls.moveUp)) //if W key pressed move up
            {
                y++;
            }
            if (Input.GetKey(Controls.moveDown)) //if S key pressed move down
            {
                y--;
            }
            if (Input.GetKey(Controls.moveLeft)) //if A key pressed move left
            {
                x--;
            }
            if (Input.GetKey(Controls.moveRight)) //if D key pressed move right
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


                x *= Time.deltaTime * moveSpeed;
                y *= Time.deltaTime * moveSpeed;

                Vector2 newPos = new Vector2(position.x + x, position.y + y);
				if(CanWalkTo(newPos))
				{
					position = newPos;
				}
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
            base.moveSpeed += 0.02f;
        }
    }
}
