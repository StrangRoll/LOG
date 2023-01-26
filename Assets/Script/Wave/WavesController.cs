using System.Collections;
using UnityEngine;

namespace Script.Wave
{
    public class WavesController: MonoBehaviour
    {
        [SerializeField] private WaveChanger waveChanger;
        [SerializeField] private float timeBetweenWaves;
        [SerializeField] private Transform spawnTransform;
        [SerializeField] private int enemiesCount;
        [SerializeField] private int deltaEnemiesCount;
        [SerializeField] private int increaseEnemiesCountStep;

        private WaitForSeconds _waitNextWave;
        private Coroutine _waveChangeCoroutine = null;
        
        public int CurrentWave { get; private set; } = 0;

        private void Awake()
        {
            _waitNextWave = new WaitForSeconds(timeBetweenWaves);
            NewWave();
        }

        private void NewWave()
        {
            CurrentWave++;
            
            if (_waveChangeCoroutine is not null)
                StopCoroutine(_waveChangeCoroutine);

            var enemysCountToSpawn = Random.Range(enemiesCount - deltaEnemiesCount, enemiesCount + deltaEnemiesCount);
            enemiesCount += increaseEnemiesCountStep;
            waveChanger.NextWave(enemysCountToSpawn, spawnTransform.position);
            _waveChangeCoroutine = StartCoroutine(WaveChangeCoroutine());
        }

        private IEnumerator WaveChangeCoroutine()
        {
            yield return _waitNextWave;
            _waveChangeCoroutine = null;
            NewWave();
        }
    }
}