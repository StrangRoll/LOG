using UnityEngine;
using Zenject;

public class CameraMovier : MonoBehaviour
{
    [SerializeField] private Vector3 _offset;

    [Inject] private PlayerMovier _playerMovier;

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
        transform.position = _playerMovier.transform.position + _offset;
    }
}
