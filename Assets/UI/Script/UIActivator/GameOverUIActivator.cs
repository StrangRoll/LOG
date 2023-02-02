using Script.GameEntitie;
using Script.System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI.Script.UIActivator
{
    public class GameOverUIActivator: MonoBehaviour
    {
        [SerializeField] private Image _gameOverImage;

        [Inject] private Player _player;
        [Inject] private GameRestarter _gameRestarter;

        private void OnEnable()
        {
            _player.PlayerDead += OnPlayerDead;
            _gameRestarter.GameRestarted += OnGameRestarted;
        }

        private void OnDisable()
        {
            _player.PlayerDead -= OnPlayerDead;
            _gameRestarter.GameRestarted -= OnGameRestarted;
        }

        private void OnGameRestarted()
        {
            Deactivate();
        }

        private void OnPlayerDead()
        {
            Activate();
        }

        private void Activate()
        {
            _gameOverImage.gameObject.SetActive(true);
        }

        private void Deactivate()
        {
            _gameOverImage.gameObject.SetActive(false);
        }
    }
}