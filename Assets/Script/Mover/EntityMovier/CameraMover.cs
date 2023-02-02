using Script.Mover.Player;
using UnityEngine;
using Zenject;

namespace Script.Mover.EntityMovier
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
