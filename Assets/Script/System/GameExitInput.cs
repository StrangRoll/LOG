using UI.Script;
using UnityEngine;
using Zenject;

namespace Script.System
{
    public class GameExitInput : MonoBehaviour
    {
        [SerializeField] private ButtonClickReader exitButtonInLose;
        [SerializeField] private ButtonClickReader exitButtonInPause;
        
        [Inject] private IsGameControl _isGameControl;

        private void OnEnable()
        {
            exitButtonInLose.ButtonClicked += OnExitButtonClicked;
            exitButtonInPause.ButtonClicked += OnExitButtonClicked;
        }

        private void OnDisable()
        {
            exitButtonInLose.ButtonClicked -= OnExitButtonClicked;
            exitButtonInPause.ButtonClicked -= OnExitButtonClicked;
        }

        private void OnExitButtonClicked()
        {
            _isGameControl.ExitGame();
        }
    }
}