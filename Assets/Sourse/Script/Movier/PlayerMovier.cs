using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovier : MonoBehaviour, IMovable
{
    [SerializeField] private PlayerInputRoot _inputRoot;
    [SerializeField] private float _speed;

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
        _controller.SimpleMove(_move * _speed);
    }

    private void OnMove(Vector3 moveDirection)
    {
        var _move = new Vector3(moveDirection.x, 0 , moveDirection.y);
        Move();
    }
}
