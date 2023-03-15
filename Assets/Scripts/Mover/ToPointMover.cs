using UnityEngine;
using UnityEngine.AI;

namespace Script.Mover
{
    public class ToPointMover
    {
        private readonly NavMeshAgent _agent;

        public ToPointMover(NavMeshAgent agent)
        {
            _agent = agent;
        }

        public void MoveToPoint(Vector3 point)
        {
            _agent.SetDestination(point);
        }
    }
}