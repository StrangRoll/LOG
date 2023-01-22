using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected Bullet bullet;
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
        
        SpawnBullets();
        StartCoroutine(Reloading());
    }

    protected abstract void SpawnBullets();

    private IEnumerator Reloading()
    {
        yield return _waitReloading;
        _isReadyToShoot = true;
    }
}
