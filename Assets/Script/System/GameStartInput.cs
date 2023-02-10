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

        private void Start()
        {
            _isGameControl.EnterGame();
            cameraChanger.ActivateGameCamera();
        }
    }
}