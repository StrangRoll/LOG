using NTC.Global.Pool;
using Script.GameEntitie;
using Script.GameEntitie.EnemyTypes;
using Script.Mover;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using Zenject;
using Random = UnityEngine.Random;

namespace Script.Spawn
{
    public class EnemySpawner : MonoBehaviour
    {
        [Inject] private DiContainer _diContainer;

        [SerializeField] private Enemy[] enemiePrefabs;
        [SerializeField] private SpawningEnemy spawningEnemiePrefab;

        public void SpawnEnemy(Vector3 spawnPosition, bool spawnSpawningEnemie = false)
        {
            var enemyToSpawn = spawnSpawningEnemie ? spawningEnemiePrefab : enemiePrefabs[Random.Range(0, enemiePrefabs.Length)];
            var newEnemy = NightPool.Spawn(enemyToSpawn, spawnPosition, Quaternion.identity);
            _diContainer.InjectGameObject(newEnemy.gameObject);
        }
    }
}
