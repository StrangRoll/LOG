using UnityEngine;
using Zenject;

namespace Script.Mover
{
    public class CameraMover : MonoBehaviour
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
}
