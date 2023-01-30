using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace Script.Mover
{
    public class EnemyMover : MonoBehaviour, IMovable
    {
        [SerializeField] private NavMeshAgent agent;

        [Inject] private PlayerMover _playerMover;
        
        private ToPointMover _toPointMover;
        private Transform _playerTransform;

        private void OnEnable()
        {
            agent.enabled = false;
            agent.enabled = true;
            _toPointMover = new ToPointMover(agent);
            _playerTransform = _playerMover.transform;
        }

        private void Update()
        {
            Move();
        }

        public void Move()
        {
            _toPointMover.MoveToPoint(_playerTransform.position);
        }
    }
}
