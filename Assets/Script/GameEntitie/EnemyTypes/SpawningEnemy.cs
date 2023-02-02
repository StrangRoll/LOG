using System.Collections;
using Script.Spawn;
using UnityEngine;
using Zenject;

namespace Script.GameEntitie.EnemyTypes
{
    public class SpawningEnemy: Enemy
    {
        [SerializeField] private float spawnDelay;

        [Inject] private EnemySpawner _enemySpawner;
        
        private WaitForSeconds _waitSpawnDelay;

        private void Start()
        {
            _waitSpawnDelay = new WaitForSeconds(spawnDelay);
            StartCoroutine(SpawnItself());
        }

        private IEnumerator SpawnItself()
        {
            while (true)
            {
                yield return _waitSpawnDelay;
                _enemySpawner.SpawnEnemy(transform.position, true);
            }
        }
    }
}