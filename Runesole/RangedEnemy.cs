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
        const float rangeRunaway = 5f;
        const float rangeRangedAttack = 5f;
        const float rangePlayerDetect = 10f;

        void Start()
        {
            maxHealth = 5f;
            health = 5f;
            attackDmg = 2f;

            sprite = SpriteManager.enemy_ranged;
        }

        void Update()
        {
            if (IsInRange(Player.main.position, rangeRunaway))
            {
                // run away
                position += (Player.main.position - position) * -1.5f * Time.deltaTime;
            }
            else if (IsInRange(Player.main.position, rangeRangedAttack))
            {
                // attack player

            }
            else if (IsInRange(Player.main.position, rangePlayerDetect))
            {
                // chase player
                position += (Player.main.position - position) * 1.5f * Time.deltaTime;
            }
            TakeDamage(Time.deltaTime * 1f);
        }
    }
}
