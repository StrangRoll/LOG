using Script.Pause;
using UnityEngine;
using Zenject;
using NotImplementedException = System.NotImplementedException;

namespace Script.Input
{
    public class PauseManagerInputRoot: MonoBehaviour
    {
        [Inject] private PlayerInput _playerInput;
        [Inject] private PauseManager pauseManager;

        private void Awake()
        {
            _playerInput.Pause.Pause.performed += ctx => OnPause();
        }

        private void OnPause()
        {
            pauseManager.ChangePauseState();
        }
    }
}