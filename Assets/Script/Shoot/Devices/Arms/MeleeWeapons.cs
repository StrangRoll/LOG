using NTC.Global.Pool;
using Script.Health;
using Script.Shoot.Devices.Ammo;
using UnityEngine;
using NotImplementedException = System.NotImplementedException;

namespace Script.Shoot.Devices.Arms
{
    public class MeleeWeapons : Weapon
    {
        private bool _isBulletInit = false;
        private Bullet _meeleBullet = null;
        
        protected override void DoWithParentOnEnable()
        {
            if (_meeleBullet != null) 
                NightPool.Despawn(_meeleBullet);

            _meeleBullet = NightPool.Spawn(bullet, transform);

            _meeleBullet.transform.localPosition = bulletSpawnPosition.localPosition;
            _meeleBullet.transform.localRotation = bullet.transform.localRotation * bulletSpawnPosition.localRotation;
            _meeleBullet.transform.localScale = bullet.transform.localScale;
        }
        
        protected override void SpawnBullets(DamagableType[] targets, BulletCollector bulletCollector)
        {
            if (_isBulletInit == false)
            {
                _meeleBullet.Init(targets, bulletDespawnObjects, bulletCollector);
                _isBulletInit = true;
            }
            
            _meeleBullet.enabled = true;
        }

        protected override void DoAfterReloading()
        {
            _meeleBullet.enabled = false;
        }
    }
}