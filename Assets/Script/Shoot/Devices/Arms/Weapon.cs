using System.Collections;
using Script.Shoot.Devices.Ammo;
using UnityEngine;

namespace Script.Shoot.Devices.Arms
{
    public abstract class Weapon : MonoBehaviour
    {
        [SerializeField] protected Bullet bullet;
        [SerializeField] protected Transform bulletSpawnPosition;
        [SerializeField] private float reloadTime;

        private bool _isReadyToShoot = true;
        private WaitForSeconds _waitReloading;

        private void Awake()
        {
            _waitReloading = new WaitForSeconds(reloadTime);
        }

        public void Shoot()
        {
            if (_isReadyToShoot == false) return;
        
            // ReSharper disable once Unity.PerformanceCriticalCodeInvocation
            SpawnBullets();
            _isReadyToShoot = false;
            StartCoroutine(Reloading());
        }

        protected abstract void SpawnBullets();

        private IEnumerator Reloading()
        {
            yield return _waitReloading;
            _isReadyToShoot = true;

        }
    }
}