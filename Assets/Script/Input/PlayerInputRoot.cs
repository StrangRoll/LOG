using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace Script.Input
{
    public class PlayerInputRoot : MonoBehaviour
    {
        [Inject] private Camera _mainCamera;
        [Inject] private PlayerInput _playerInput;
        
        private Vector2 _moveDirection = Vector2.zero;
        private bool _isShooting = false;

        public event UnityAction<Vector2> Move;
        public event UnityAction<Vector2> Look;
        public event UnityAction Shoot;

        private void Awake()
        {
            _playerInput.Player.Move.performed += ctx => OnMove();
            _playerInput.Player.Shoot.performed += ctx => OnShoot();
            _playerInput.Player.Look.performed += ctx => OnLook();
            _playerInput.Player.MouseLook.performed += ctx => OnMouseLook();
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

        public void Reset()
        {
            _isShooting = false;
            _moveDirection = Vector2.zero;
        }

        private void OnLook()
        {
            var lookDirection = _playerInput.Player.Look.ReadValue<Vector2>();
            Look?.Invoke(lookDirection);
        }

        private void OnMouseLook()
        {
            var mousePosition = _playerInput.Player.MouseLook.ReadValue<Vector2>();
            mousePosition = _mainCamera.ScreenToViewportPoint(mousePosition);
            mousePosition = ConvertToNormalView(mousePosition);
            Look?.Invoke(mousePosition);
        }

        private Vector2 ConvertToNormalView(Vector2 vector)
        {
            var normalView = vector * 2 - new Vector2(1,1);
            return normalView * (-1);
        }

        private void OnShoot()
        {
            _isShooting = !_isShooting;
        }


        private void OnMove()
        {
            _moveDirection = _playerInput.Player.Move.ReadValue<Vector2>();
        }
    }
}