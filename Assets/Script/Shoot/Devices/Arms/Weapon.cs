using System.Collections;
using Script.Health;
using Script.Shoot.Devices.Ammo;
using UnityEngine;
using Zenject;

namespace Script.Shoot.Devices.Arms
{
    public abstract class Weapon : MonoBehaviour
    {
        [Inject] private BulletCollector _bulletCollector;
        
        [SerializeField] protected Bullet bullet;
        [SerializeField] protected Transform bulletSpawnPosition;
        [SerializeField] private float reloadTime;
        [SerializeField] protected DamagableType[] bulletDespawnObjects;

        private bool _isReadyToShoot = true;
        private WaitForSeconds _waitReloading;
        private Coroutine _reloadingCoroutine;

        private void OnEnable()
        {
            _isReadyToShoot = true;
            DoWithParentOnEnable();
        }

        private void Awake()
        {
            _waitReloading = new WaitForSeconds(reloadTime);
            DoWithParentAwake();
        }

        private void OnDisable()
        {
            if (_reloadingCoroutine != null)
                StopCoroutine(_reloadingCoroutine);
        }

        public void TryShoot(DamagableType[] targets)
        {
            if (_isReadyToShoot == false) return;
        
            // ReSharper disable once Unity.PerformanceCriticalCodeInvocation
            SpawnBullets(targets, _bulletCollector);
            _isReadyToShoot = false;
            _reloadingCoroutine = StartCoroutine(Reloading());
        }
        
        protected virtual void DoWithParentAwake(){}
        
        protected virtual void DoWithParentOnEnable(){}
        
        protected abstract void SpawnBullets(DamagableType[] targets, BulletCollector bulletCollector);

        protected abstract void DoAfterReloading();
            
        private IEnumerator Reloading()
        {
            yield return _waitReloading;
            DoAfterReloading();
            _isReadyToShoot = true;
        }
    }
}
