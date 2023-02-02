using System.Collections.Generic;
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
        private List<Enemy> _aliveEnemiesList = new List<Enemy>();

        public event UnityAction AllEnemiesDied;
        
        public void SpawnEnemy(Vector3 spawnPosition, bool spawnSpawningEnemie = false)
        {
            var enemyToSpawn = spawnSpawningEnemie ? spawningEnemiePrefab : enemiePrefabs[Random.Range(0, enemiePrefabs.Length)];
            var newEnemy = NightPool.Spawn(enemyToSpawn, spawnPosition, Quaternion.identity);
            _diContainer.InjectGameObject(newEnemy.gameObject);
            _aliveEnemies++;
            newEnemy.EnemyDie += OnEnemyDie;
            _aliveEnemiesList.Add(newEnemy);
        }

        public void DespawnAllEnemies()
        {
            var enemyToDespawn = new Enemy[_aliveEnemies];
            
            for (int i = 0; i < _aliveEnemies; i++)
            {
                enemyToDespawn[i] = _aliveEnemiesList[i];
            }
            
            foreach (var enemy in enemyToDespawn)
            {
                enemy.Kill();
            }
        }

        private void OnEnemyDie(Enemy enemy)
        {
            _aliveEnemies--;
            enemy.EnemyDie -= OnEnemyDie;
            _aliveEnemiesList.Remove(enemy);
            
            if (_aliveEnemies <= 0)
                AllEnemiesDied?.Invoke();
        }
    }
}
