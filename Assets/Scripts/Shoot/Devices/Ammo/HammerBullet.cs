using System;
using System.Collections;
using NTC.Global.Pool;
using Script.Shoot.Devices.Ammo.BulletCollisionTypes;
using Script.Shoot.Devices.Ammo.BulletDamageType;
using Script.Shoot.Devices.Ammo.BulletEffectTypes;
using Script.Shoot.Devices.Ammo.MovementTypes;
using UnityEngine;
using UnityEngine.Events;
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
        [SerializeField] private ParticleSystem exploseEffect;

        private Quaternion _standartRotation;

        public event UnityAction ExplosionHappened;

        private void OnEnable()
        {
            bulletMover.StartMove();
            StartCoroutine(WhaitUntilExplose());
        }

        public void OnSpawn()
        {
            base.OnSpawn();
            _standartRotation = transform.localRotation;
            enabled = false;
        }

        public void OnDespawn()
        {
            base.OnDespawn();
            transform.localRotation = _standartRotation;
            
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

        protected override void SetBulletEffect()
        {
            bulletEffect = new OnCollisionEffect(exploseEffect, ref ExplosionHappened, true, transform);
        }

        private IEnumerator WhaitUntilExplose()
        {
            yield return new WaitForSeconds(hitDuration);
            ExplosionHappened?.Invoke();
        }
    }
}