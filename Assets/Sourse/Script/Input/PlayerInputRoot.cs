using UnityEngine;
using UnityEngine.Events;

public class PlayerInputRoot : MonoBehaviour
{
    private PlayerInput _playerInput;
    private Vector3 _moveDirection = Vector3.zero;

    public event UnityAction<Vector3> Move;

    private void Awake()
    {
        _playerInput = new PlayerInput();
        _playerInput.Player.Move.performed += ctx => OnMove();
    }

    private void OnEnable()
    {
        _playerInput.Enable();
    }

    private void OnDisable()
    {
        _playerInput.Disable();
    }

    private void FixedUpdate()
    {
        Move?.Invoke(_moveDirection);
    }

    private void OnMove()
    {
        _moveDirection = _playerInput.Player.Move.ReadValue<Vector2>();
    }
}