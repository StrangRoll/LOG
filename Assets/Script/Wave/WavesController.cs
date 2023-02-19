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

        [Inject] private Vector3[] _spawnPositions;
        [Inject] private EnemySpawner _enemySpawner;
        [Inject] private GameRestarter _gameRestarter;

        private readonly float _timeBetweenWaves = 15;
        private readonly int _deltaEnemiesCount = 1;
        private readonly int _increaseEnemiesCountStep = 1;
        private int _enemiesCount = 3;
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
            _startEnemiesCount = _enemiesCount;
            _waitNextWave = new WaitForSeconds(_timeBetweenWaves);
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
                _enemiesCount -= _increaseEnemiesCountStep;
            }
            
            NewWave();
        }

        private void Reset()
        {
            CurrentWave = 0;
            _enemiesCount = _startEnemiesCount;
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

            var enemysCountToSpawn = Random.Range(_enemiesCount - _deltaEnemiesCount, _enemiesCount + _deltaEnemiesCount);
            _enemiesCount += _increaseEnemiesCountStep;
            Vector3[] newEnemiesSpawnPositions = new Vector3[enemysCountToSpawn];
            
            for (var i = 0; i < enemysCountToSpawn; i++)
                newEnemiesSpawnPositions[i] = _spawnPositions[Random.Range(0, _spawnPositions.Length)];
            
            waveChanger.NextWave(enemysCountToSpawn, newEnemiesSpawnPositions);
            _waveChangeCoroutine = StartCoroutine(WaveChangeCoroutine());
            WaveChanged?.Invoke(CurrentWave, CurrentWave + 1, _timeBetweenWaves);
        }

        private IEnumerator WaveChangeCoroutine()
        {
            yield return _waitNextWave;
            _waveChangeCoroutine = null;
            NewWave();
        }
    }
}