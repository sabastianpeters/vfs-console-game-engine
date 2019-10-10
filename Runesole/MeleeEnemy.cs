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

			if (IsInRange(Player.main.position, attackRange - 0.1f))
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
            sprite = SpriteManager.enemy_melee_damaged;
        }
    }
}

