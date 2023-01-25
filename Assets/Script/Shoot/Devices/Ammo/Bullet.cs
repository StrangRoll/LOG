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

        private DamagableType[] _targets;
        
        private void Update()
        {
            Move();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out IDamagable component))
            {
                if (Array.IndexOf(_targets, component.Type) != -1)
                {
                    NightPool.Despawn(this);
                    component.TakeDamage(damage);
                }
            }
        }

        public void Init(DamagableType[] targets)
        {
            _targets = new DamagableType[targets.Length];

            for (int i = 0; i < targets.Length; i++)
            {
                _targets[i] = targets[i];
            }
        }

        public abstract void Move();
    }
}
