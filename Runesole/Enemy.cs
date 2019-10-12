using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Runesole.Engine;

namespace Runesole
{
    class Enemy : LivingEntitiy
    {
		public override void Attack(LivingEntitiy target)
		{
			// if the target is in range of our attack range, attack them
			if (target.IsInRange(position, attackRange))
				target.TakeDamage(attackDmg * Time.deltaTime * damageMultiplier);
		}
	}
}
