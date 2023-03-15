using System.Collections;
using NTC.Global.Pool;
using Script.Health;
using UnityEngine;
using UnityEngine.Serialization;
using NotImplementedException = System.NotImplementedException;

namespace Script.Shoot.Devices.Arms
{
    public class Uzi : Weapon
    {
        [SerializeField] private float timeBetweenBullets;
        [SerializeField] private int bulletCount;

        private WaitForSeconds _waitNextShot;

        protected override void DoWithParentAwake()
        {
            _waitNextShot = new WaitForSeconds(timeBetweenBullets);
        }

        protected override void SpawnBullets(DamagableType[] targets, BulletCollector bulletCollector)
        {
            StartCoroutine(BurstOfShots(targets, bulletCollector));
        }

        protected override void DoAfterReloading()
        {
            return;
        }

        private IEnumerator BurstOfShots(DamagableType[] targets, BulletCollector bulletCollector)
        {
            for (int i = 0; i < bulletCount; i++)
            {
                var newBullet = NightPool.Spawn(bullet, bulletSpawnPosition.position,
                    bullet.transform.rotation * bulletSpawnPosition.rotation);

                newBullet.Init(targets, bulletDespawnObjects, bulletCollector);
                yield return _waitNextShot;
            }
        }
    }
}