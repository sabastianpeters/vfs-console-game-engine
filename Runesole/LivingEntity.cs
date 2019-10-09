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
        public float health;
        public float maxHealth;
        public float attackDmg;
        public float moveSpeed;

        public event Action OnDeath;

        public void Attack(LivingEntitiy entity)
        {
            entity.TakeDamage(attackDmg);
        }

        public void ResetHealth()
        {
            health = maxHealth;
        }

        public void TakeDamage(float damage)
        {
            health -= damage;
            if(health < 1f)
            {
                OnDeath();
                this.Destroy();
            }
        }

        public void Heal(float hp)
        {
            health += hp;
            if(health > maxHealth)
            {
                health = maxHealth;
            }
        }

        public bool IsInRange(Vector2 v, float range)
        {
            if (Vector2.SqrDistance(v, position) < range * range)
                return true;
            return false;
        }
    }
}
