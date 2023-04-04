using UnityEngine;
using UnityEngine.AI;

namespace Mover.EntityMovier
{
    public class EnemySpeedChanger : MonoBehaviour
    {
        
        [SerializeField] private float minSpeed;
        [SerializeField] private float deltaSpeed;
        [SerializeField] private float standartSpeed;
        [SerializeField] private NavMeshAgent _agent;

        public void SetSpeed(int waveNumber)
        {
            waveNumber--;
            var speed = minSpeed + waveNumber * deltaSpeed;
            _agent.speed = Mathf.Clamp(speed, minSpeed, standartSpeed);
        }
    }
}