using System.Collections;
using NTC.Global.Pool;
using Script.Shoot.Devices.Ammo.BulletCollisionTypes;
using Script.Shoot.Devices.Ammo.BulletDamageType;
using Script.Shoot.Devices.Ammo.BulletEffectTypes;
using Script.Shoot.Devices.Ammo.MovementTypes;
using UnityEngine;
using NotImplementedException = System.NotImplementedException;

namespace Script.Shoot.Devices.Ammo
{
    public class MineBullet : Bullet
    {
        [SerializeField] private int damage;
        [SerializeField] private float exploseTime;
        [SerializeField] private Collider exploseCollider;
        [SerializeField] private ParticleSystem effect;

        private ExploseDelegateContainer.ExploseDelegate _explose;
        private WaitForSeconds _waitExploseEnd;
        
        protected override void SetMovementType()
        {
            bulletMover = new DontMove();
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

        protected override void SetBulletEffect()
        {
            bulletEffect = new OnCollisionEffect(effect);
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