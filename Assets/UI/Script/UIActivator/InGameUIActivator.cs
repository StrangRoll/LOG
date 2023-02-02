using Script.GameEntitie;
using UnityEngine;
using Zenject;

namespace UI.Script.UIActivator
{
    public class InGameUIActivator: MonoBehaviour
    {
        [SerializeField] private RectTransform inGameUI;
        
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
            inGameUI.gameObject.SetActive(false);
        }
    }
}