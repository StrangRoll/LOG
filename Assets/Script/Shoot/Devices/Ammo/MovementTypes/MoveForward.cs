using UnityEngine;
using NotImplementedException = System.NotImplementedException;

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
        
        public void MoveEachFrame()
        {
            _transform.Translate(Vector3.left * (_speed * Time.deltaTime));
        }

        public void StartMove()
        {
            throw new NotImplementedException();
        }

        public void StopMove()
        {
            throw new NotImplementedException();
        }
    }
}