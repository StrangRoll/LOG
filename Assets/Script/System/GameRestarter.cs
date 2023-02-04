using Script.GameEntitie;
using Script.Spawn;
using UI.Script;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
using Zenject;

namespace Script.System
{
    public class GameRestarter : MonoBehaviour
    {
        [SerializeField] private ButtonClickReader restartButton;
        [SerializeField] private ButtonClickReader gameContinueButton;
        [SerializeField] private ButtonClickReader restartFromPauseButton;

        [Inject] private EnemySpawner _enemySpawner;
        [Inject] private Player _player;

        public event UnityAction<bool> GameRestarted;

        private bool _IsGameContinue;

        private void OnEnable()
        {
            restartButton.ButtonClicked += OnRestartButtonClick;
            gameContinueButton.ButtonClicked += OnGameContinueButtonClick;
            restartFromPauseButton.ButtonClicked += OnRestartButtonClick;
        }

        private void OnDisable()
        {
            restartButton.ButtonClicked -= OnRestartButtonClick;
            gameContinueButton.ButtonClicked -= OnGameContinueButtonClick;
            restartFromPauseButton.ButtonClicked -= OnRestartButtonClick;
        }

        private void OnGameContinueButtonClick()
        {
            _IsGameContinue = true;
            RestartGame();
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