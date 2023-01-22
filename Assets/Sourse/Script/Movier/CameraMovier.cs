using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

public class CameraMovier : MonoBehaviour
{
    [SerializeField] private Vector3 offset;

    [Inject] private PlayerMover _playerMover;

    private void Awake()
    {
        MoveCamera();
    }

    private void LateUpdate()
    {
        MoveCamera();
    }

    private void MoveCamera()
    {
        transform.position = _playerMover.transform.position + offset;
    }
}
