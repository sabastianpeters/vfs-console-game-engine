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
			health = maxHealth;
		}

		public virtual void TakeDamage(float damage)
		{
			health -= damage;
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
			health += hp;
			if (health > maxHealth)
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

		protected LivingEntitiy() : base()
		{
			IsDead = false;
		}
	}
}

