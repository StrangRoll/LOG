using Script.GameEntitie;
using Script.System;
using UnityEngine;
using Zenject;

namespace UI.Script.UIActivator
{
    public class InGameUIActivator: MonoBehaviour
    {
        [SerializeField] private RectTransform inGameUI;
        [SerializeField] private ButtonClickReader exitButton;
        
        [Inject] private Player _player;
        [Inject] private GameRestarter _gameRestarter;

        private void OnEnable()
        {
            _gameRestarter.GameRestarted += OnGameRestarted;
            _player.PlayerDead += OnPlayerDead;
            exitButton.ButtonClicked += OnExitButtonClick;
        }

        private void OnDisable()
        {
            _gameRestarter.GameRestarted -= OnGameRestarted;
            _player.PlayerDead -= OnPlayerDead;
            exitButton.ButtonClicked -= OnExitButtonClick;
        }

        private void OnExitButtonClick()
        {
            Deactivate();
        }

        private void OnGameRestarted(bool isGameContinue)
        {
            Activate();
        }

        private void OnPlayerDead()
        {
            Deactivate();
        }

        private void Activate()
        {
            inGameUI.gameObject.SetActive(true);
        }

        private void Deactivate()
        {
            inGameUI.gameObject.SetActive(false);
        }
    }
}