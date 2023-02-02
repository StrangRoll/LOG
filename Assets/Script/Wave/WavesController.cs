using System.Collections;
using Script.Spawn;
using UnityEngine;
using UnityEngine.Events;
using Zenject;
using Random = UnityEngine.Random;

namespace Script.Wave
{
    public class WavesController: MonoBehaviour
    {
        [SerializeField] private WaveChanger waveChanger;
        [SerializeField] private float timeBetweenWaves;
        [SerializeField] private int enemiesCount;
        [SerializeField] private int deltaEnemiesCount;
        [SerializeField] private int increaseEnemiesCountStep;

        [Inject] private Vector3[] _spawnPositions;
        [Inject] private EnemySpawner _enemySpawner;

        private WaitForSeconds _waitNextWave;
        private Coroutine _waveChangeCoroutine = null;
        private int _currentWave = 0;

        public event UnityAction<float, float, float> WaveChanged;


        private void Awake()
        {
            _waitNextWave = new WaitForSeconds(timeBetweenWaves);
            NewWave();
        }

        private void OnEnable()
        {
            _enemySpawner.AllEnemiesDied += OnAllEnemiesDied;
        }
        
        private void OnDisable()
        {
            _enemySpawner.AllEnemiesDied -= OnAllEnemiesDied;
        }

        private void OnAllEnemiesDied()
        {
            NewWave();
        }

        private void NewWave()
        {
            _currentWave++;
            
            if (_waveChangeCoroutine is not null)
                StopCoroutine(_waveChangeCoroutine);

            var enemysCountToSpawn = Random.Range(enemiesCount - deltaEnemiesCount, enemiesCount + deltaEnemiesCount);
            enemiesCount += increaseEnemiesCountStep;
            Vector3[] newEnemiesSpawnPositions = new Vector3[enemysCountToSpawn];
            
            for (var i = 0; i < enemysCountToSpawn; i++)
                newEnemiesSpawnPositions[i] = _spawnPositions[Random.Range(0, _spawnPositions.Length)];
            
            waveChanger.NextWave(enemysCountToSpawn, newEnemiesSpawnPositions);
            _waveChangeCoroutine = StartCoroutine(WaveChangeCoroutine());
            WaveChanged?.Invoke(_currentWave, _currentWave + 1, timeBetweenWaves);
        }

        private IEnumerator WaveChangeCoroutine()
        {
            yield return _waitNextWave;
            _waveChangeCoroutine = null;
            NewWave();
        }
    }
}