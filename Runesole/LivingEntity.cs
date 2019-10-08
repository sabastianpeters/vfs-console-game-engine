using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Runesole.Engine;

namespace Runesole
{
	class LivingEntitiy : GameObject
	{
        public int health;
        public int maxHealth;
        public int attackDmg;
        public float moveSpeed;

        public event Action OnDeath;

        public void Attack(LivingEntitiy entity)
        {
            entity.TakeDamage(attackDmg);
        }

        public void ResetHealth()
        {

        }

        public void TakeDamage(int damage)
        {

        }

        public void Heal(int hp)
        {

        }

        public bool IsInRange(Vector2 v, float range)
        {
            if (Vector2.SqrDistance(v, position) < range * range)
                return true;
            return false;
        }
    }
}
