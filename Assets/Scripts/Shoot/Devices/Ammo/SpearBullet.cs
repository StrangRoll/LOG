using NTC.Global.Pool;
using Script.Shoot.Devices.Ammo.BulletCollisionTypes;
using Script.Shoot.Devices.Ammo.BulletDamageType;
using Script.Shoot.Devices.Ammo.MovementTypes;
using UnityEngine;
using NotImplementedException = System.NotImplementedException;

namespace Script.Shoot.Devices.Ammo
{
    public class SpearBullet : Bullet, IPoolItem
    {
        [SerializeField] private int damage;
        [SerializeField] private float speed;
        [SerializeField] private float distance;

        private Quaternion _standartRotation;
        private Vector3 _standartPosition;

        private void OnEnable()
        {
            bulletMover.StartMove();
        }
        
        public void OnSpawn()
        {
            _standartRotation = transform.localRotation;
            _standartPosition = transform.localPosition;
            enabled = false;
        }
        
        public void OnDespawn()
        {
            transform.localRotation = _standartRotation;
            transform.localPosition = _standartPosition;
            
            try
            {
                bulletMover.StopMove();
            }
            catch
            {
                // ignored
            }
        }

        protected override void SetMovementType()
        {
            var bulletTransform = transform;
            bulletMover = new MoveForwardThenBack(bulletTransform, distance, speed);
        }

        protected override void SetDamageType()
        {
            bulletDamager = new StandartDamager(damage);
        }

        protected override void SetCollisionType()
        {
            bulletCollisionType = new WithoutDespawn();
        }
    }
}