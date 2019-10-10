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
        const float meleeMeleeAttack = 1f;
        const float meleePlayerDetect = 10f;

        void Start()
        {
            maxHealth = 10f;
            health = 10f;
            attackDmg = 1f;

        }

        void Update()
		{
			sprite = SpriteManager.enemy_melee;

			if (IsInRange(Player.main.position, meleeMeleeAttack))
            {
                // attack player
            }
            else if (IsInRange(Player.main.position, meleePlayerDetect))
            {
                // chase player
                position += (Player.main.position - position) * 2f * Time.deltaTime;
            }
        }

        public override void TakeDamage(float damage)
        {
            base.TakeDamage(damage);
            sprite = SpriteManager.enemy_melee_damaged;
        }
    }
}

