using NTC.Global.Pool;
using Script.Shoot.Devices.Ammo.BulletCollisionTypes;
using Script.Shoot.Devices.Ammo.BulletDamageType;
using Script.Shoot.Devices.Ammo.BulletEffectTypes;
using Script.Shoot.Devices.Ammo.MovementTypes;
using UnityEngine;
using UnityEngine.Serialization;
using NotImplementedException = System.NotImplementedException;

namespace Script.Shoot.Devices.Ammo
{
    public class StandartBullet : Bullet
    {
        [SerializeField] private int damage;
        [SerializeField] private float speed;
        [SerializeField] private ParticleSystem shootEffect;
        [SerializeField] private Vector3 effectPosition;
        [SerializeField] private Vector3 effectRotation;

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
            bulletCollisionType = new OnlyDespawn();
        }

        protected override void SetBulletEffect()
        {
            bulletEffect = new NotFollowingEffect(shootEffect, transform, 
                effectPosition, effectRotation);
            bulletEffect.PlayEffect();
        }
    }
}