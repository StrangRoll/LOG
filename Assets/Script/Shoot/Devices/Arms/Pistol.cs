using NTC.Global.Pool;

namespace Script.Shoot.Devices.Arms
{
    public class Pistol : Weapon
    {
        protected override void SpawnBullets()
        {
            // ReSharper disable once Unity.PerformanceCriticalCodeInvocation
            var newBullet = NightPool.Spawn(bullet, bulletSpawnPosition.position,
                bullet.transform.rotation * bulletSpawnPosition.rotation);
            
        }
    }
}
