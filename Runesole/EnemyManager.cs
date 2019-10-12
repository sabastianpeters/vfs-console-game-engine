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
				OnEnemyDie();
			};

			return (EnemyType)enemy;
		}

		public static EnemyType SpawnEnemy<EnemyType>(float spawnX, float spawnY) where EnemyType : Enemy, new()
		{
			return SpawnEnemy<EnemyType>(new Vector2(spawnX, spawnY));
		}


		private static void OnEnemyDie ()
		{
            //when an enemy dies checks to see if there is any left
			if(enemyList.Count <= 0)
			{
                //if there is no enemies left spawn 4 more
				SpawnEnemies();
			}
		}


		public static void SpawnEnemies ()
		{
            //spawns 2 melee enemies on the map randomly
			for (int i = 0; i < 2; i++)
			{
				Vector2 spawnPos = Vector2.zero;
				do {
					spawnPos = new Vector2(Random.Range(23, GameManager.world.Width - 23), Random.Range(23, GameManager.world.Height - 23));
				} while (!GameManager.world.CanWalkAt(spawnPos));
				MeleeEnemy enemy = EnemyManager.SpawnEnemy<MeleeEnemy>(spawnPos);
				enemy.OnDeath += () => Player.main.AddExp(2f); ///when the enemy dies give player exp
			}

            //spawns 2 ranged enemies on the map randomly
            for (int i = 0; i < 2; i++)
			{
				Vector2 spawnPos = Vector2.zero;
				do
				{
					spawnPos = new Vector2(Random.Range(23, GameManager.world.Width - 23), Random.Range(23, GameManager.world.Height - 23));
				} while (!GameManager.world.CanWalkAt(spawnPos));
				RangedEnemy enemy = EnemyManager.SpawnEnemy<RangedEnemy>(spawnPos);
				enemy.OnDeath += () => Player.main.AddExp(2f); ///when the enemy dies give player exp
			}
        }
	}
}
