using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Runesole
{
    class RangedEnemy : LivingEntitiy
    {
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
