using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(CharacterController))]
public class PlayerMover : MonoBehaviour, IMovable
{
    [SerializeField] private PlayerInputRoot inputRoot;
    [SerializeField] private float speed;

    private CharacterController _controller;
    private Vector3 _move;

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
    }

    private void OnEnable()
    {
        inputRoot.Move += OnMove;
    }

    private void OnDisable()
    {
        inputRoot.Move -= OnMove;
    }

    public void Move()
    {
        _controller.SimpleMove(_move * speed);
    }

    private void OnMove(Vector3 moveDirection)
    {
        _move = new Vector3(moveDirection.x, 0 , moveDirection.y);
        Move();
    }
}
