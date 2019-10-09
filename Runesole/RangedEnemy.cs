using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Runesole
{
    class RangedEnemy : Enemy
    {
        const float rangeRunaway = 5f;
        const float rangeRangedAttack = 5f;
        const float rangePlayerDetect = 10f;

        void Start()
        {
            maxHealth = 5;
            health = 5;
            attackDmg = 2;

            sprite = SpriteManager.enemy_ranged;
        }

        void Update()
        {
            if (IsInRange(Player.main.position, rangeRunaway))
            {
                // run away
                position += (Player.main.position - position) * -0.07f;
            }
            else if (IsInRange(Player.main.position, rangeRangedAttack))
            {
                // attack player

            }
            else if (IsInRange(Player.main.position, rangePlayerDetect))
            {
                // chase player
                position += (Player.main.position - position) * 0.07f;
            }
        }
    }
}
