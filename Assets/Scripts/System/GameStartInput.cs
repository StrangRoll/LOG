using UI.Script;
using UnityEngine;
using Zenject;

namespace Script.System
{
    public class GameStartInput : MonoBehaviour
    {
        [SerializeField] private ButtonClickReader playButton;

        [Inject] private IsGameControl _isGameControl;

        private void Start()
        {
            _isGameControl.EnterGame();
        }
    }
}