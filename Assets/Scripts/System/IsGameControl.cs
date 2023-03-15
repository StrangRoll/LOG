using Script.GameEntitie;
using Script.Loader;
using Script.Wave;
using UnityEngine;
using UnityEngine.Events;

namespace Script.System
{
    public class IsGameControl
    {
        private readonly WavesController _wavesController;
        private readonly Player _player;
        private readonly RectTransform _mainMenu;

        private MainMenuLoader _mainMenuLoader = new MainMenuLoader();
        
        public event UnityAction GameStarted; 
        
        public IsGameControl(WavesController wavesController, Player player, RectTransform mainMenu)
        {
            _wavesController = wavesController;
            _player = player;
            _mainMenu = mainMenu;
        }

        public void EnterGame()
        {
            _wavesController.gameObject.SetActive(true);
            _player.gameObject.SetActive(true);
            _mainMenu.gameObject.SetActive(false);
            GameStarted?.Invoke();
        }

        public void ExitGame()
        {
            _mainMenuLoader.LoadToMainMenu();
        }
    }
}