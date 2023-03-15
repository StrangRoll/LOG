using Script.Health;
using NotImplementedException = System.NotImplementedException;

namespace Script.Shoot.Devices.Ammo.BulletCollisionTypes
{
    public class WithoutDespawn : IBulletCollisionType
    {
        public void OnCollision(Bullet bullet, IDamagable bulletCollisionType, BulletCollector bulletCollector)
        {
            return;
        }
    }
}