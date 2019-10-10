using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Runesole.Engine;

namespace Runesole
{
	class EnemyManager
	{
		public static List<Enemy> enemyList = new List<Enemy>();


		// spawns in an enemy of specified type
		public static EnemyType SpawnEnemy<EnemyType> (Vector2 spawnPos) where EnemyType: Enemy, new()
		{
			Enemy enemy = new EnemyType();
			enemyList.Add(enemy);
			enemy.position = spawnPos;

			// removes enemy from list when enemy dies
			enemy.OnDeath += () => {
				enemyList.Remove(enemy);
			};

			return (EnemyType)enemy;
		}

		public static EnemyType SpawnEnemy<EnemyType>(float spawnX, float spawnY) where EnemyType : Enemy, new()
		{
			return SpawnEnemy<EnemyType>(new Vector2(spawnX, spawnY));
		}
	}
}
