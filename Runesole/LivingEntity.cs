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

        public virtual void Attack(LivingEntitiy entity)
        {
            entity.TakeDamage(attackDmg);
        }

        public virtual void ResetHealth()
        {
            health = maxHealth;
        }

        public virtual void TakeDamage(float damage)
        {
            health -= damage;
            if(health < 1f)
            {
                OnDeath();
                this.Destroy();
            }
        }

        public virtual void Heal(float hp)
        {
            health += hp;
            if(health > maxHealth)
            {
                health = maxHealth;
            }
        }

        public virtual bool IsInRange(Vector2 v, float range)
        {
            if (Vector2.SqrDistance(v, position) < range * range)
                return true;
            return false;
        }
    }
}
