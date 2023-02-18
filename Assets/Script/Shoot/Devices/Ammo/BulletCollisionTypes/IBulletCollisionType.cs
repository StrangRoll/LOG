using Script.Health;

namespace Script.Shoot.Devices.Ammo.BulletCollisionTypes
{
    public interface IBulletCollisionType
    {
        public void OnCollision(Bullet bullet, IDamagable bulletCollisionType, BulletCollector bulletCollector);
    }
}