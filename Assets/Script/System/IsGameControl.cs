using Script.GameEntitie;
using Script.Wave;
using UnityEngine.Events;
using Zenject;

namespace Script.System
{
    public class IsGameControl
    {
        private readonly WavesController _wavesController;
        private readonly Player _player;

        public event UnityAction GameStarted; 
        
        public IsGameControl(WavesController wavesController, Player player)
        {
            _wavesController = wavesController;
            _player = player;
        }

        public void EnterGame()
        {
            _wavesController.gameObject.SetActive(true);
            _player.gameObject.SetActive(true);
            GameStarted?.Invoke();
        }

        public void ExitGame()
        {
            _wavesController.gameObject.SetActive(false);
            _player.gameObject.SetActive(false);
        }
    }
}