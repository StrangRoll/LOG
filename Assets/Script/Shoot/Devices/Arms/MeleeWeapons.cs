using NTC.Global.Pool;
using Script.Health;
using Script.Shoot.Devices.Ammo;
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
            
            _meeleBullet = NightPool.Spawn(bullet, bulletSpawnPosition.position,
                bullet.transform.rotation * bulletSpawnPosition.rotation);
            
            _meeleBullet.transform.SetParent(transform);
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