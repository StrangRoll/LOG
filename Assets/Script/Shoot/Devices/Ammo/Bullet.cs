using System;
using NTC.Global.Pool;
using Script.Health;
using Script.Shoot.Devices.Ammo.BulletCollisionTypes;
using Script.Shoot.Devices.Ammo.BulletDamageType;
using Script.Shoot.Devices.Ammo.MovementTypes;
using UnityEngine;

namespace Script.Shoot.Devices.Ammo
{
    public abstract class Bullet : MonoBehaviour, IPoolItem
    {
        protected IBulletMover bulletMover;
        protected IBulletDamager bulletDamager;
        protected IBulletCollisionType bulletCollisionType;
        protected DamagableType[] _despawnObjects = null;

        private DamagableType[] _targets = null;
        private BulletCollector _bulletCollector;
        private bool _isActive = true;

        private void Start()
        {
            SetBulletParameters();

            if (_targets == null)
                Debug.LogError("Bullet targets not set.");

            if (_despawnObjects == null)
                Debug.LogError("Bullet despawn objects not set.");
            
            if (bulletMover == null)
                Debug.LogError("Bullet mover not set.");

            if (bulletDamager == null)
                Debug.LogError("Bulllet damager not set");

            if (bulletCollisionType == null)
                Debug.LogError("Bullet collision type not set");
        }

        private void SetBulletParameters()
        {
            SetMovementType();
            SetDamageType();
            SetCollisionType();
        }

        private void Update()
        {
            if (_isActive)
                bulletMover.Move();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out IDamagable component) == false) 
                return;
            
            if (Array.IndexOf(_targets, component.Type) != -1)
                bulletDamager.Damage(component);

            if (Array.IndexOf(_despawnObjects, component.Type) != -1)
            {
                bulletCollisionType.OnCollision(this, component, _bulletCollector);
                _isActive = false;
            }
        }

        public void Init(DamagableType[] targets, DamagableType[] despawnObjects, BulletCollector bulletCollector)
        {
            _bulletCollector = bulletCollector;
            bulletCollector.Register(this);
            _targets = new DamagableType[targets.Length];
            _despawnObjects = new DamagableType[despawnObjects.Length];

            for (int i = 0; i < targets.Length; i++)
            {
                _targets[i] = targets[i];
            }

            for (int i = 0; i < despawnObjects.Length; i++)
            {
                _despawnObjects[i] = despawnObjects[i];
            }
        }

        protected abstract void SetMovementType();

        protected abstract void SetDamageType();

        protected abstract void SetCollisionType();
        
        public void OnSpawn()
        {
            _isActive = true;
        }

        public void OnDespawn()
        {
            _isActive = false;
        }
    }
}
