using Script.GameEntitie;
using Script.System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI.Script.UIActivator
{
    public class GameOverUIActivator: MonoBehaviour
    {
        [SerializeField] private Image gameOverImage;
        [SerializeField] private ButtonClickReader exitButton;

        [Inject] private Player _player;
        [Inject] private GameRestarter _gameRestarter;

        private void OnEnable()
        {
            _player.PlayerDead += OnPlayerDead;
            _gameRestarter.GameRestarted += OnGameRestarted;
            exitButton.ButtonClicked += OnExitButtonClick;
        }

        private void OnDisable()
        {
            _player.PlayerDead -= OnPlayerDead;
            _gameRestarter.GameRestarted -= OnGameRestarted;
            exitButton.ButtonClicked -= OnExitButtonClick;
        }

        private void OnExitButtonClick()
        {
            Deactivate();
        }

        private void OnGameRestarted(bool isGameContinue)
        {
            Deactivate();
        }

        private void OnPlayerDead()
        {
            Activate();
        }

        private void Activate()
        {
            gameOverImage.gameObject.SetActive(true);
        }

        private void Deactivate()
        {
            gameOverImage.gameObject.SetActive(false);
        }
    }
}