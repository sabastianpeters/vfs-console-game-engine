using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Runesole.Engine;

namespace Runesole
{
	// Utility Class to Manage Enemies in Scene
	static class EnemyManager
	{
		// a list of enemies currently in the world
		public static List<Enemy> enemyList = new List<Enemy>(); /// this should be private, but player needs to access it since I couldn't implement a collision system


		// ## PUBLIC METHODS ##

		// Spawns in enemy at position // using generics allows us to do things with enemy after spawning
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

		// Spawns in enemy at (x, y)
		public static EnemyType SpawnEnemy<EnemyType>(float spawnX, float spawnY) where EnemyType : Enemy, new()
		{
			return SpawnEnemy<EnemyType>(new Vector2(spawnX, spawnY));
		}

		// Spawns in enemies into map pseudo-randomly
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



		// ## PRIVATE UTILITY METHOD ##

		// called for every enemy killed in enemyList
		private static void OnEnemyDie()
		{
			//when an enemy dies checks to see if there is any left
			if (enemyList.Count <= 0)
			{
				//if there is no enemies left spawn 4 more
				SpawnEnemies();
			}
		}

	}
}
