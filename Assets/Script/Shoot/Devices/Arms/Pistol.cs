using NTC.Global.Pool;
using Script.Health;

namespace Script.Shoot.Devices.Arms
{
    public class Pistol : Weapon
    {
        protected override void SpawnBullets(DamagableType[] targets, BulletCollector bulletCollector)
        {
            // ReSharper disable once Unity.PerformanceCriticalCodeInvocation
            var newBullet = NightPool.Spawn(bullet, bulletSpawnPosition.position,
                bullet.transform.rotation * bulletSpawnPosition.rotation);

            newBullet.Init(targets, bulletDespawnObjects, bulletCollector);
        }
    }
}
