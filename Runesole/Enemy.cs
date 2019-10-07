using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Runesole
{
	class Enemy : GameObject
	{
		void Start ()
		{
			sprite = SpriteManager.enemy;
		}

		void Update ()
		{
			position += (Player.main.position - position) * 0.1f;
		}
	}
}
