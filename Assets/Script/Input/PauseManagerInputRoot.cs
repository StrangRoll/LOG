using Script.Pause;
using UnityEngine;
using Zenject;
using NotImplementedException = System.NotImplementedException;

namespace Script.Input
{
    public class PauseManagerInputRoot: MonoBehaviour
    {
        [Inject] private PlayerInput _playerInput;
        
        private PauseManager _pauseManager = new PauseManager();

        private void Awake()
        {
            _playerInput.Pause.Pause.performed += ctx => OnPause();
        }

        private void OnPause()
        {
            _pauseManager.ChangePauseState();
        }
    }
}