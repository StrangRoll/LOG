using NTC.Global.Pool;
using Script.GameEntitie;
using UnityEngine;
using Zenject;

namespace Script.Spawn
{
    public class EnemySpawner : MonoBehaviour
    {
        [Inject] private DiContainer _diContainer;
        
        [SerializeField] private Enemy[] enemiePrefabs;

        public void SpawnEnemy(Vector3 spawnPosition, Enemy enemyToSpawn = null)
        {
            enemyToSpawn ??= enemiePrefabs[Random.Range(0, enemiePrefabs.Length)];
            var newEnemy = Instantiate(enemyToSpawn, spawnPosition, Quaternion.identity);
            _diContainer.InjectGameObject(newEnemy.gameObject);
        }
    }
}
