using NTC.Global.Pool;
using Script.GameEntitie;
using Script.GameEntitie.EnemyTypes;
using UnityEngine;
using UnityEngine.Events;
using Zenject;
using Random = UnityEngine.Random;

namespace Script.Spawn
{
    public class EnemySpawner : MonoBehaviour
    {
        [Inject] private DiContainer _diContainer;

        [SerializeField] private Enemy[] enemiePrefabs;
        [SerializeField] private SpawningEnemy spawningEnemiePrefab;

        private int _aliveEnemies = 0;

        public event UnityAction AllEnemiesDied;
        
        public void SpawnEnemy(Vector3 spawnPosition, bool spawnSpawningEnemie = false)
        {
            var enemyToSpawn = spawnSpawningEnemie ? spawningEnemiePrefab : enemiePrefabs[Random.Range(0, enemiePrefabs.Length)];
            var newEnemy = NightPool.Spawn(enemyToSpawn, spawnPosition, Quaternion.identity);
            _diContainer.InjectGameObject(newEnemy.gameObject);
            _aliveEnemies++;
            newEnemy.EnemyDie += OnEnemyDie;
        }

        private void OnEnemyDie(Enemy enemy)
        {
            _aliveEnemies--;
            enemy.EnemyDie -= OnEnemyDie;
            
            if (_aliveEnemies <= 0)
                AllEnemiesDied?.Invoke();
        }
    }
}
