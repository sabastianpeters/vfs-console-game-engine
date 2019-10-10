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

            if (IsInRange(Player.main.position, attackRange - 2f))
			{
				// run away
				newPos += (Player.main.position - position).Normalize() * -moveSpeed * Time.deltaTime;
			}
			else if(IsInRange(Player.main.position, attackRange)) 
            {
				// attack player
            }
            else if (IsInRange(Player.main.position, rangePlayerDetect))
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
