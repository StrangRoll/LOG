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
        [Inject] private PauseManager _pauseManager;

        [SerializeField] private ButtonClickReader pauseButton;
        [SerializeField] private ButtonClickReader continueButton;

        private void OnEnable()
        {
            pauseButton.ButtonClicked += OnPauseButtonClicked;
            continueButton.ButtonClicked += OnContinueButtonClicked;
        }

        private void OnDisable()
        {
            pauseButton.ButtonClicked -= OnPauseButtonClicked;
            continueButton.ButtonClicked -= OnContinueButtonClicked;
        }

        private void Awake()
        {
            _playerInput.Pause.Pause.performed += ctx => OnPause();
        }
        
        private void OnContinueButtonClicked()
        {
            _pauseManager.Pause(false);
        }

        private void OnPause()
        {
            _pauseManager.ChangePauseState();
        }

        private void OnPauseButtonClicked()
        {
            _pauseManager.ChangePauseState();
        }
    }
}