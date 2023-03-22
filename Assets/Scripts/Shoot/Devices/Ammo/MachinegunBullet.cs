using Script.Shoot.Devices.Ammo.BulletCollisionTypes;
using Script.Shoot.Devices.Ammo.BulletDamageType;
using Script.Shoot.Devices.Ammo.BulletEffectTypes;
using Script.Shoot.Devices.Ammo.MovementTypes;
using UnityEngine;
using UnityEngine.Serialization;
using NotImplementedException = System.NotImplementedException;

namespace Script.Shoot.Devices.Ammo
{
    public class MachinegunBullet : Bullet
    {
        [SerializeField] private int damage;
        [SerializeField] private float minSpeed;
        [SerializeField] private float maxSpeed;
        private ParticleSystem shootEffect;

        protected override void SetMovementType()
        {
            var speed = Random.Range(minSpeed, maxSpeed + 1);
            bulletMover = new MoveForward(transform, speed);
        }

        protected override void SetDamageType()
        {
            bulletDamager = new StandartDamager(damage);
        }

        protected override void SetCollisionType()
        {
            bulletCollisionType = new OnlyDespawn();
        }

        protected override void SetBulletEffect()
        {
            bulletEffect = new NotFollowingEffect(shootEffect, transform, shootEffect.transform.localPosition);
        }
    }
}