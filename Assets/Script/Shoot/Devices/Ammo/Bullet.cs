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

        private void Update()
        {
            Move();
        }

        private void OnTriggerEnter(Collider other)
        {
            NightPool.Despawn(this);

            if (other.TryGetComponent(out IDamagable component))
                component.TakeDamage(damage);
        }

        public abstract void Move();
    }
}
