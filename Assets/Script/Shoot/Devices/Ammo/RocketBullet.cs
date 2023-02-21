using System.Collections;
using NTC.Global.Pool;
using Script.Shoot.Devices.Ammo.BulletCollisionTypes;
using Script.Shoot.Devices.Ammo.BulletDamageType;
using Script.Shoot.Devices.Ammo.MovementTypes;
using UnityEngine;
using NotImplementedException = System.NotImplementedException;

namespace Script.Shoot.Devices.Ammo
{
    public class RocketBullet : Bullet
    {

        [SerializeField] private float speed;
        [SerializeField] private int damage;
        [SerializeField] private float exploseTime;
        [SerializeField] private Collider exploseCollider;

        private ExploseDelegateContainer.ExploseDelegate _explose;
        private WaitForSeconds _waitExploseEnd;

        protected override void SetMovementType()
        {
            bulletMover = new MoveForward(transform, speed);
        }

        protected override void SetDamageType()
        {
            bulletDamager = new StandartDamager(damage);
        }

        protected override void SetCollisionType()
        {
            _explose = Explose;
            _waitExploseEnd = new WaitForSeconds(exploseTime);
            bulletCollisionType = new ExploseAndDespawn(_explose);
        }

        private void Explose(BulletCollector bulletCollector)
        {
            StartCoroutine(Explosion(bulletCollector));
        }

        private IEnumerator Explosion(BulletCollector bulletCollector)
        {
            exploseCollider.enabled = true;
            yield return _waitExploseEnd;
            exploseCollider.enabled = false;
            bulletCollector.UnRegister(this);
            NightPool.Despawn(this);
        }
    }
}