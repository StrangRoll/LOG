using Script.Input;
using UnityEngine;
using Zenject;

namespace Script.Mover
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerMover : MonoBehaviour, IMovable
    {
        [SerializeField] private float speed;

        [Inject] private PlayerInputRoot _inputRoot;
        
        private CharacterController _controller;
        private Vector3 _move;

        private void Awake()
        {
            _controller = GetComponent<CharacterController>();
        }

        private void OnEnable()
        {
            _inputRoot.Move += OnMove;
        }

        private void OnDisable()
        {
            _inputRoot.Move -= OnMove;
        }

        public void Move()
        {
            _controller.SimpleMove(_move * speed);
        }

        private void OnMove(Vector2 moveDirection)
        {
            _move = new Vector3(moveDirection.x, 0 , moveDirection.y);
            Move();
        }
    }
}
