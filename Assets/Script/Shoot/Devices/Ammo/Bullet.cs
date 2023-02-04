using System;
using NTC.Global.Pool;
using Script.Health;
using Script.Mover;
using UnityEngine;

namespace Script.Shoot.Devices.Ammo
{
    public abstract class Bullet : MonoBehaviour, IMovable
    {
        [SerializeField] protected int damage;
        [SerializeField] protected float speed;

        protected DamagableType[] _despawnObjects = null;

        private DamagableType[] _targets = null;
        private BulletCollector _bulletCollector;

        private void Start()
        {
            if (_targets == null)
                Debug.LogError("Bullet targets not set.");

            if (_despawnObjects == null)
                Debug.LogError("Bullet despawn objects not set.");
        }

        private void Update()
        {
            Move();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out IDamagable component) == false) 
                return;
            
            if (Array.IndexOf(_targets, component.Type) != -1)
                component.TakeDamage(damage);

            if (Array.IndexOf(_despawnObjects, component.Type) != -1)
            {
                _bulletCollector.UnRegister(this);
                NightPool.Despawn(this);
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

        public abstract void Move();
    }
}
