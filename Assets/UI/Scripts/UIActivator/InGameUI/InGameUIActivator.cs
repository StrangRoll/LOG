using Script.GameEntitie;
using Script.System;
using UnityEngine;
using Zenject;

namespace UI.Scripts.UIActivator.InGameUI
{
    public class InGameUIActivator: MonoBehaviour
    {
        [SerializeField] private RectTransform inGameUI;
        
        [Inject] private Player _player;
        [Inject] private GameRestarter _gameRestarter;

        private void OnEnable()
        {
            _gameRestarter.GameRestarted += OnGameRestarted;
            _player.PlayerDead += OnPlayerDead;
        }

        private void OnDisable()
        {
            _gameRestarter.GameRestarted -= OnGameRestarted;
            _player.PlayerDead -= OnPlayerDead;
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