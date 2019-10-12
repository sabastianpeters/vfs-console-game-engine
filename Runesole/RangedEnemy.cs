using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Runesole.Engine;

namespace Runesole
{
    class RangedEnemy : Enemy
    {
        float rangeRunaway = 5f;
        float rangePlayerDetect = 20f;

        void Start()
        {
            //set the stats for the ranged enemies at the beginning of the game
            maxHealth = 5f;
            health = 5f;
            attackDmg = 2f;
			moveSpeed = 4f;
			attackRange = 5;

		}

        void Update()
		{
			sprite = SpriteManager.enemy_ranged;

			Vector2 newPos = position;

            if (IsInRange(Player.main.position, attackRange - 2f)) //if the player is in range of 5 chars runaway
            {
				// run away
				newPos += (Player.main.position - position).Normalize() * -moveSpeed * Time.deltaTime;
			}
            else if (IsInRange(Player.main.position, attackRange)) //if the player is in range attack
            {
                // attack player
            }
            else if (IsInRange(Player.main.position, rangePlayerDetect)) //if the player is in range of view chase player
            {
				// chase player
				newPos += (Player.main.position - position).Normalize() * moveSpeed * Time.deltaTime;
            }


			// walk to new pos if we can
			if (CanWalkTo(newPos))
			{
				position = newPos;
			}
		}

        public override void TakeDamage(float damage)
        {
            base.TakeDamage(damage);
            sprite = SpriteManager.enemy_ranged_damaged;
        }
    }
}
