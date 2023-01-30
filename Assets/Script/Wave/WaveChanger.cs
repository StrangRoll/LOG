using Script.Spawn;
using UnityEngine;
using Zenject;

namespace Script.Wave
{
    public class WaveChanger: MonoBehaviour
    {
        [Inject] private EnemySpawner _spawner;

        public void NextWave(int enemyCount, Vector3[] spawnPositions)
        {
            for (int i = 0; i < enemyCount; i++)
            {
                _spawner.SpawnEnemy(spawnPositions[i]);
            }
        }
    }
}