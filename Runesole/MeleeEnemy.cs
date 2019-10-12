using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Runesole.Engine;

namespace Runesole
{
    class MeleeEnemy : Enemy
    {
        float rangePlayerDetect = 20f;

        void Start()
        {
            //sets the stats of the enemy at the start of the game
            maxHealth = 10f;
            health = 10f;
            attackDmg = 1f;
			moveSpeed = 8f;
            attackRange = 1;
        }

        void Update()
		{
			sprite = SpriteManager.enemy_melee;

			Vector2 newPos = position;

			if (IsInRange(Player.main.position, attackRange - 0.1f)) //if the player is in attack range, attack player
            {
                // attack player
            }
            else if (IsInRange(Player.main.position, rangePlayerDetect)) //if the player is in view range of melee enemy, chase player
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
            sprite = SpriteManager.enemy_melee_damaged;
        }
    }
}

