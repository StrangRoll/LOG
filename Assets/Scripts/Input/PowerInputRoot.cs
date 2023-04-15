using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace Script.Input
{
    public class PowerInputRoot : MonoBehaviour
    {
        [Inject] private PlayerInput _playerInput;
        
        public event UnityAction FirstPower;
        public event UnityAction SecondPower;

        private void Awake()
        {
            _playerInput.Player.FirstPower.performed += ctx => OnFirstPower();
            _playerInput.Player.SecondPower.performed += ctx => OnSecondPower();
        }

        private void OnSecondPower()
        {
            FirstPower?.Invoke();
        }

        private void OnFirstPower()
        {
            SecondPower?.Invoke();
        }
    }
}