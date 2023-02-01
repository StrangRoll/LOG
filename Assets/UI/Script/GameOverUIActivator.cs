using Script.GameEntitie;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI.Script
{
    public class GameOverUIActivator: MonoBehaviour
    {
        [SerializeField] private Image _gameOverImage;

        [Inject] private Player _player;

        private void OnEnable()
        {
            _player.PlayerDead += OnPlayerDead;
        }

        private void OnDisable()
        {
            _player.PlayerDead -= OnPlayerDead;
        }

        private void OnPlayerDead()
        {
            _gameOverImage.gameObject.SetActive(true);
        }
    }
}