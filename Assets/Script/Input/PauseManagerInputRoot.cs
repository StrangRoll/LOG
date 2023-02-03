using Script.Pause;
using UI.Script;
using UnityEngine;
using Zenject;
using NotImplementedException = System.NotImplementedException;

namespace Script.Input
{
    public class PauseManagerInputRoot: MonoBehaviour
    {
        [Inject] private PlayerInput _playerInput;
        [Inject] private PauseManager pauseManager;

        [SerializeField] private ButtonClickReader _pauseButton;

        private void OnEnable()
        {
            _pauseButton.ButtonClicked += OnPauseButtonClicked;
        }

        private void OnDisable()
        {
            _pauseButton.ButtonClicked -= OnPauseButtonClicked;
        }

        private void Awake()
        {
            _playerInput.Pause.Pause.performed += ctx => OnPause();
        }

        private void OnPause()
        {
            pauseManager.ChangePauseState();
        }

        private void OnPauseButtonClicked()
        {
            pauseManager.ChangePauseState();
        }
    }
}