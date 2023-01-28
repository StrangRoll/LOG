using NTC.Global.Pool;
using Script.Health;
using UnityEngine;

namespace Script.Shoot.Devices.Arms
{
    public class Machinegun: Weapon
    {
        [SerializeField] private float deltaAngle;

        protected override void SpawnBullets(DamagableType[] targets)
        {
            var newBullet = NightPool.Spawn(bullet, bulletSpawnPosition.position,
                bullet.transform.rotation * bulletSpawnPosition.rotation);
            var rotation = Random.Range(-deltaAngle, deltaAngle);
            newBullet.transform.Rotate(Vector3.up, rotation);
            newBullet.Init(targets);
        }
    }
}