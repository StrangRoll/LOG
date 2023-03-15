using NTC.Global.Pool;
using Script.Health;

namespace Script.Shoot.Devices.Ammo.BulletCollisionTypes
{
    public class OnlyDespawn : IBulletCollisionType
    {
        public void OnCollision(Bullet bullet, IDamagable bulletCollisionType, BulletCollector bulletCollector)
        { 
            bulletCollector.UnRegister(bullet);
            NightPool.Despawn(bullet);
        }
    }
}