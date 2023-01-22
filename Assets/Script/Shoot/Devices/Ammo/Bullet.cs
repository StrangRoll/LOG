using System;
using NTC.Global.Pool;
using Script.Mover;
using UnityEngine;

namespace Script.Shoot.Devices.Ammo
{
    public abstract class Bullet : MonoBehaviour, IMovable
    {
        [SerializeField] protected float damage;
        [SerializeField] protected float speed;

        private void Update()
        {
            Move();
        }

        private void OnTriggerEnter(Collider other)
        {
            NightPool.Despawn(this);
        }

        public abstract void Move();
    }
}
