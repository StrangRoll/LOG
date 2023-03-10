using Script.Health;
using UnityEngine;

namespace Script.Shoot.Devices.Ammo.BulletCollisionTypes
{
    public class ExploseAndDespawn : IBulletCollisionType
    {
        private Collider _exploseCollider;
        private ExploseDelegateContainer.ExploseDelegate _exploseDelegate;

        public ExploseAndDespawn(ExploseDelegateContainer.ExploseDelegate explose)
        {
            _exploseDelegate = explose;
        }

        public void OnCollision(Bullet bullet, IDamagable damagable, BulletCollector bulletCollector)
        {
            if (damagable.Type != DamagableType.OutOfBound)
                CallExploseFunction(bulletCollector);
        }

        private void CallExploseFunction(BulletCollector bulletCollector)
        {
            _exploseDelegate(bulletCollector);
        }
    }
}