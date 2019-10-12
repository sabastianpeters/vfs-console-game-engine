using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Runesole.Engine;

namespace Runesole
{
	// A living entity gameobject (health, speed, damage)
	class LivingEntitiy : GameObject
	{

		// ## PUBLIC MEMBERS ##
		public float health = 1;
		public float maxHealth = 1;
		public float attackDmg = 1;
		public float moveSpeed = 1;
		public float attackRange = 1;
        public float damageMultiplier = 1;

		public event Action OnDeath;	/// event called when entity diess
		public bool IsDead { get; protected set; } /// is entity currently dead?

		// attacks a target if they are in range of our attack range
		public virtual void Attack(LivingEntitiy target)
		{
			if(target.IsInRange(position, attackRange))
				target.TakeDamage(attackDmg*damageMultiplier);

		}

		//set health to maxiumium health
		public virtual void ResetHealth()
		{
            health = maxHealth;
			IsDead = false;
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
        
        // returns if the position is within the range of the entity
		public virtual bool IsInRange(Vector2 v, float range)
		{
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

