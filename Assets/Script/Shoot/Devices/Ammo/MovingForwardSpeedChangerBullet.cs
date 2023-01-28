using UnityEngine;
using Random = UnityEngine.Random;

namespace Script.Shoot.Devices.Ammo
{
    public class MovingForwardSpeedChangerBullet : MovingForwardBullet
    {
        [SerializeField] private float minSpeed;
        [SerializeField] private float maxSpeed;
        
        private void Awake()
        {
            var newSpeed = Random.Range(minSpeed, maxSpeed);
            speed = newSpeed;
        }
    }
}