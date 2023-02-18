using UnityEngine;

namespace Script.Shoot.Devices.Ammo.MovementTypes
{
    public class MoveForward : IBulletMover
    {
        private Transform _transform;
        private float _speed;
        
        public MoveForward(Transform bulletTransform, float speed)
        {
            _transform = bulletTransform;
            _speed = speed;
        }
        
        public void Move()
        {
            _transform.Translate(Vector3.left * (_speed * Time.deltaTime));
        }
    }
}