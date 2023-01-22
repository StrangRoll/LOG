using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

namespace Script.Input
{
    public class PlayerInputRoot : MonoBehaviour
    {
        private PlayerInput _playerInput;
        private Vector2 _moveDirection = Vector2.zero;
        private bool _isShooting = false;

        public event UnityAction<Vector2> Move;
        public event UnityAction Shoot;

        private void Awake()
        {
            _playerInput = new PlayerInput();
            _playerInput.Player.Move.performed += ctx => OnMove();
            _playerInput.Player.Shoot.performed += ctx => OnShoot();
        }

        private void OnEnable()
        {
            _playerInput.Enable();
        }

        private void FixedUpdate()
        {
            Move?.Invoke(_moveDirection);
                        
            if (_isShooting)
                Shoot?.Invoke();
        }

        private void OnDisable()
        {
            _playerInput.Disable();
        }

        private void OnShoot()
        {
            _isShooting = !_isShooting;
        }

        private void OnMove()
        {
            _moveDirection = _playerInput.Player.Move.ReadValue<Vector2>() * (-1);
        }
    }
}