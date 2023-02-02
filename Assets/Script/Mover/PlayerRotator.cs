using Script.Input;
using Script.Mover.Player;
using UnityEngine;
using Zenject;

namespace Script.Mover
{
    public class PlayerRotator: MonoBehaviour
    {
        [Inject] private PlayerInputRoot _inputRoot;
        [Inject] private PlayerMover _playerMover;

        private Transform _playerTransform;

        private void Awake()
        {
            _playerTransform = _playerMover.transform;
        }

        private void OnEnable()
        {
            _inputRoot.Look += OnLook;
        }

        private void OnDisable()
        {
            _inputRoot.Look -= OnLook;
        }

        private void OnLook(Vector2 direction)
        {
            var lookDirection = new Vector3(direction.x, 0, direction.y);
            _playerTransform.LookAt(_playerTransform.position + (Vector3)lookDirection);
        }
    }
}