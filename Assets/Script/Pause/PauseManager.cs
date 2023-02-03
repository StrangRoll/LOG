using System;
using System.Collections.Generic;
using Script.GameEntitie;
using Script.System;
using UnityEngine;
using Zenject;

namespace Script.Pause
{
    public class PauseManager: MonoBehaviour, IPausable
    {
        [Inject] private Player _player;
        [Inject] private GameRestarter _gameRestarter;
        
        private List<IPausable> _pausablesList = new List<IPausable>();
        
        public bool IsPause { get; private set; }

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

        public void Pause(bool isPause)
        {
            IsPause = isPause;

            Time.timeScale = IsPause ? 0 : 1;

            foreach (var pausable in _pausablesList)
            {
                pausable.Pause(isPause);
            }

        }

        public void ChangePauseState()
        {
            Pause(!IsPause);
        }

        private void OnGameRestarted(bool arg0)
        {
            Pause(false);
        }

        private void OnPlayerDead()
        {
            Pause(true);
        }

        private void Register(IPausable pausable)
        {
            _pausablesList.Add(pausable);
        }

        private void Unregister(IPausable pausable)
        {
            try
            {
                _pausablesList.Remove(pausable);
            }
            catch
            {
                Debug.LogError("Unable to remove pausable from list");
            }
        }
    }
}