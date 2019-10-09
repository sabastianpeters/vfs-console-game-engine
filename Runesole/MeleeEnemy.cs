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
            maxHealth = 10;
            health = 10;
            attackDmg = 1;

            sprite = SpriteManager.enemy_melee;
        }

        void Update()
        {
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
    }
}

