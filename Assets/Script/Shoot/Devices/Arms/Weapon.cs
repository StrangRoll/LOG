using System.Collections;
using Script.Health;
using Script.Shoot.Devices.Ammo;
using UnityEngine;
using UnityEngine.Serialization;

namespace Script.Shoot.Devices.Arms
{
    public abstract class Weapon : MonoBehaviour
    {
        [SerializeField] protected Bullet bullet;
        [SerializeField] protected Transform bulletSpawnPosition;
        [SerializeField] private float reloadTime;
        [SerializeField] protected DamagableType[] bulletDespawnObjects;

        private bool _isReadyToShoot = true;
        private WaitForSeconds _waitReloading;

        private void Awake()
        {
            _waitReloading = new WaitForSeconds(reloadTime);
            DoWithParentAwake();
        }

        public void TryShoot(DamagableType[] targets)
        {
            if (_isReadyToShoot == false) return;
        
            // ReSharper disable once Unity.PerformanceCriticalCodeInvocation
            SpawnBullets(targets);
            _isReadyToShoot = false;
            StartCoroutine(Reloading());
        }
        
        protected virtual void DoWithParentAwake(){}

        protected abstract void SpawnBullets(DamagableType[] targets);

        private IEnumerator Reloading()
        {
            yield return _waitReloading;
            _isReadyToShoot = true;
        }
    }
}
