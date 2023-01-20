using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovier : MonoBehaviour
{
    [SerializeField] private PlayerInputRoot _inputRoot;
    [SerializeField] private float _speed;

    private CharacterController _controller;

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

    private void OnMove(Vector3 moveDirection)
    {
        _controller.SimpleMove(moveDirection * _speed);
    }
}
