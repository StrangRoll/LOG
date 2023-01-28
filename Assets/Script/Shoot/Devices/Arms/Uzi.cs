using System.Collections;
using NTC.Global.Pool;
using Script.Health;
using UnityEngine;
using UnityEngine.Serialization;

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

        protected override void SpawnBullets(DamagableType[] targets)
        {
            StartCoroutine(BurstOfShots(targets));
        }

        private IEnumerator BurstOfShots(DamagableType[] targets)
        {
            for (int i = 0; i < bulletCount; i++)
            {
                var newBullet = NightPool.Spawn(bullet, bulletSpawnPosition.position,
                    bullet.transform.rotation * bulletSpawnPosition.rotation);

                newBullet.Init(targets);
                yield return _waitNextShot;
            }
        }
    }
}