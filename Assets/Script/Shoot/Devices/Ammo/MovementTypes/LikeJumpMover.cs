using UnityEngine;
using NotImplementedException = System.NotImplementedException;

namespace Script.Shoot.Devices.Ammo.MovementTypes
{
    public class LikeJumpMover : IBulletMover
    {
        private Transform _bulletTransform;
        private Vector3 _velocity;
        private float _gravity;

        public LikeJumpMover(Transform bulletTransform, float speedX, float speedY, float angle, float gravity)
        {
            _bulletTransform = bulletTransform;
            _velocity = Quaternion.AngleAxis(angle, bulletTransform.right * (-1)) * bulletTransform.forward;
            _velocity.x *= speedX;
            _velocity.y *= speedY;
            _gravity = gravity;
        }
        
        public void Move()
        {
            _velocity.y -= _gravity * Time.deltaTime;
            var deltaPosition = _velocity * Time.deltaTime;
            _bulletTransform.position += deltaPosition;
            _bulletTransform.LookAt(_bulletTransform.position + deltaPosition);
            _bulletTransform.Rotate(_bulletTransform.up, 90);
        }
    }
}