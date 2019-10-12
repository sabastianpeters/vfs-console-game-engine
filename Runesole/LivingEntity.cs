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
		public float health = 1;
		public float maxHealth = 1;
		public float attackDmg = 1;
		public float moveSpeed = 1;
		public float attackRange = 1;

		public event Action OnDeath;
		public bool IsDead { get; private set; }

		public virtual void Attack(LivingEntitiy target)
		{
			// if the target is in range of our attack range, attack them
			if(target.IsInRange(position, attackRange))
				target.TakeDamage(attackDmg);

		}
		public virtual void ResetHealth()
		{
            //set health to maxiumium health
            health = maxHealth;
		}

		public virtual void TakeDamage(float damage)
		{
			health -= damage;

            //if the health of any entity is lower then 1, delete the entity 
			if (health < 1f)
			{
				// calls on death if method added
				if(OnDeath != null)
					OnDeath();
				IsDead = true;
				this.Destroy();
			}
		}

		public virtual void Heal(float hp)
		{
            //heals the health by the float hp
			health += hp;

            //if the health healed is greater then max health, set the health to maxhealth
			if (health > maxHealth)
			{
                ResetHealth();
            }
		}

		public virtual bool IsInRange(Vector2 v, float range)
		{
            //return if the position is within the range of the entity
            return Vector2.SqrDistance(v, position) < range * range;
		}

		protected LivingEntitiy() : base()
		{
            //sets the entity to alive
			IsDead = false;
		}

		protected bool CanWalkTo (Vector2 pos)
		{
            //returns if entity can walk at the block
			return GameManager.world.CanWalkAt(pos);
		}
	}
}

