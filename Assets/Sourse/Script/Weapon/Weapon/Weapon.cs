using System.Collections;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected Bullet _bullet;
    [SerializeField] private float _reloadTime;

    private bool _isReadyToShoot = true;
    private WaitForSeconds _waitReloading;

    private void Awake()
    {
        _waitReloading = new WaitForSeconds(_reloadTime);
    }

    public void Shoot()
    {
        if (_isReadyToShoot)
        {
            SpawnBullets();
            StartCoroutine(Reloadinng());
        }
    }

    public abstract void SpawnBullets();

    private IEnumerator Reloadinng()
    {
        yield return _waitReloading;
        _isReadyToShoot = true;
    }
}
