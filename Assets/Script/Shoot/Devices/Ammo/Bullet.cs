using Script.Interfaces;
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

        public abstract void Move();
    }
}
