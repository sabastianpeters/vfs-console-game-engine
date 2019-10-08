using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Runesole
{
    class RangedEnemy : LivingEntitiy
    {
        const float rangeRangedAttack = 5f;
        const float rangePlayerDetect = 10f;

        void Start()
        {
            sprite = SpriteManager.enemy_ranged;
        }

        void Update()
        {
            position += (Player.main.position - position) * 0.05f;
        }
    }
}
