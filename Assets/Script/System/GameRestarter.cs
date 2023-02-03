using Script.GameEntitie;
using Script.Spawn;
using UI.Script;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace Script.System
{
    public class GameRestarter : MonoBehaviour
    {
        [SerializeField] private ButtonClickReader restartButton;

        [Inject] private EnemySpawner _enemySpawner;
        [Inject] private Player _player;

        public event UnityAction<bool> GameRestarted;

        private bool _IsGameContinue;

        private void OnEnable()
        {
            restartButton.ButtonClicked += OnRestartButtonClick;
        }

        private void OnDisable()
        {
            restartButton.ButtonClicked -= OnRestartButtonClick;
        }

        private void OnRestartButtonClick()
        {
            _IsGameContinue = false;
            RestartGame();
        }

        private void RestartGame()
        {
            DespawnAllEnemie();
            ResetPlayer();
            GameRestarted?.Invoke(_IsGameContinue);
        }

        private void DespawnAllEnemie()
        { 
            _enemySpawner.DespawnAllEnemies();   
        }

        private void ResetPlayer()
        {
            _player.Reset();
        }
    }
}