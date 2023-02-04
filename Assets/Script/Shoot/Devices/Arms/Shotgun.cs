using System.Numerics;
using NTC.Global.Pool;
using Script.Health;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

namespace Script.Shoot.Devices.Arms
{
    public class Shotgun: Weapon
    {
        [SerializeField] private int minBulletCount;
        [SerializeField] private int maxBulletCount;
        [SerializeField] private float deltaAngle;
        
        protected override void SpawnBullets(DamagableType[] targets, BulletCollector bulletCollector)
        {
            var bulletCount = Random.Range(minBulletCount, maxBulletCount);

            for (int i = 0; i < bulletCount; i++)
            {
                var angle = Random.Range(-deltaAngle, deltaAngle);
                var newBullet = NightPool.Spawn(bullet, bulletSpawnPosition.position,
                    bullet.transform.rotation * bulletSpawnPosition.rotation);
                newBullet.transform.Rotate(Vector3.up, angle);
                newBullet.Init(targets, base.bulletDespawnObjects, bulletCollector);
            }
        }
    }
}