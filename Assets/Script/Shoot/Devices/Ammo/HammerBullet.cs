using System.Collections;
using NTC.Global.Pool;
using Script.Shoot.Devices.Ammo.BulletCollisionTypes;
using Script.Shoot.Devices.Ammo.BulletDamageType;
using Script.Shoot.Devices.Ammo.MovementTypes;
using UnityEngine;
using UnityEngine.Serialization;
using NotImplementedException = System.NotImplementedException;

namespace Script.Shoot.Devices.Ammo
{
    public class HammerBullet : Bullet, IPoolItem
    {
        [SerializeField] private int damage;
        [SerializeField] private float hitDuration;
        [SerializeField] private float hitDelay;
        [SerializeField] private float returnDuration;
        [SerializeField] private float bounceHeight;
        [SerializeField] private Vector3 endRotation;
        [SerializeField] private Collider explosionCollider;

        private WaitForSeconds _waitingForDeactivation;
        private Quaternion _standartRotation;

        private void OnEnable()
        {
            SetMovementType();
        }

        public void OnSpawn()
        {
            _standartRotation = transform.rotation;
        }
        
        public void OnDespawn()
        {
            transform.rotation = _standartRotation;
        }

        protected override void SetMovementType()
        {
            var bulletTransform = transform;
            _waitingForDeactivation = new WaitForSeconds(hitDuration + hitDelay + returnDuration);
            bulletMover = new RotateAndExplose(bulletTransform, hitDuration, hitDelay, bounceHeight, returnDuration, 
                endRotation, explosionCollider);
        }

        protected override void SetDamageType()
        {
            bulletDamager = new StandartDamager(damage);
        }

        protected override void SetCollisionType()
        {
            bulletCollisionType = new WithoutDespawn();
        }

        private IEnumerator DeactivationTimer()
        {
            yield return _waitingForDeactivation;
            enabled = false;
        }
    }
}