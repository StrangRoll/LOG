using System;
using UI.Script;
using UnityEngine;
using Zenject;

namespace Script.System
{
    public class GameStartInput : MonoBehaviour
    {
        [SerializeField] private ButtonClickReader playButton;
        [SerializeField] private CameraChanger cameraChanger;

        [Inject] private IsGameControl _isGameControl;

        private void OnEnable()
        {
            playButton.ButtonClicked += OnPlayButtonClicked;
        }

        private void OnDisable()
        {
            playButton.ButtonClicked -= OnPlayButtonClicked;
        }

        private void OnPlayButtonClicked()
        {
            _isGameControl.EnterGame();
            cameraChanger.ActivateGameCamera();
        }
    }
}