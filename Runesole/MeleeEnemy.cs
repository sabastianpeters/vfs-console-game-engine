using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Runesole
{
    class MeleeEnemy : LivingEntitiy
    {
        void Start()
        {
            sprite = SpriteManager.enemy_melee;
        }

        void Update()
        {
            position += (Player.main.position - position) * 0.1f;
        }
    }
}

