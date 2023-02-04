using System.Collections;
using Script.Spawn;
using Script.System;
using UnityEngine;
using UnityEngine.Events;
using Zenject;
using NotImplementedException = System.NotImplementedException;
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
        [Inject] private GameRestarter _gameRestarter;

        private WaitForSeconds _waitNextWave;
        private Coroutine _waveChangeCoroutine = null;
        private int _startEnemiesCount;

        public event UnityAction<float, float, float> WaveChanged;

        public int CurrentWave { get; private set; } = 0;

        private void OnEnable()
        {
            _enemySpawner.AllEnemiesDied += OnAllEnemiesDied;
            _gameRestarter.GameRestarted += OnGameRestarted;
        }

        private void Start()
        {
            _startEnemiesCount = enemiesCount;
            _waitNextWave = new WaitForSeconds(timeBetweenWaves);
            gameObject.SetActive(false);
        }

        private void OnDisable()
        {
            _enemySpawner.AllEnemiesDied -= OnAllEnemiesDied;
            _gameRestarter.GameRestarted -= OnGameRestarted;
        }

        private void OnGameRestarted(bool isGameContinue)
        {
            if (isGameContinue == false)
            {
                Reset();
            }
            else
            {
                CurrentWave--;
                enemiesCount -= increaseEnemiesCountStep;
            }
            
            NewWave();
        }

        private void Reset()
        {
            CurrentWave = 0;
            enemiesCount = _startEnemiesCount;
        }

        private void OnAllEnemiesDied()
        {
            NewWave();
        }

        private void NewWave()
        {
            CurrentWave++;
            
            if (_waveChangeCoroutine is not null)
                StopCoroutine(_waveChangeCoroutine);

            var enemysCountToSpawn = Random.Range(enemiesCount - deltaEnemiesCount, enemiesCount + deltaEnemiesCount);
            enemiesCount += increaseEnemiesCountStep;
            Vector3[] newEnemiesSpawnPositions = new Vector3[enemysCountToSpawn];
            
            for (var i = 0; i < enemysCountToSpawn; i++)
                newEnemiesSpawnPositions[i] = _spawnPositions[Random.Range(0, _spawnPositions.Length)];
            
            waveChanger.NextWave(enemysCountToSpawn, newEnemiesSpawnPositions);
            _waveChangeCoroutine = StartCoroutine(WaveChangeCoroutine());
            WaveChanged?.Invoke(CurrentWave, CurrentWave + 1, timeBetweenWaves);
        }

        private IEnumerator WaveChangeCoroutine()
        {
            yield return _waitNextWave;
            _waveChangeCoroutine = null;
            NewWave();
        }
    }
}