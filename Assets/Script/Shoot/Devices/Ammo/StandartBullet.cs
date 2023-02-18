using Script.Shoot.Devices.Ammo.BulletCollisionTypes;
using Script.Shoot.Devices.Ammo.BulletDamageType;
using Script.Shoot.Devices.Ammo.MovementTypes;
using UnityEngine;
using NotImplementedException = System.NotImplementedException;

namespace Script.Shoot.Devices.Ammo
{
    public class StandartBullet : Bullet
    {
        [SerializeField] private int damage;
        [SerializeField] private float speed;

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
    }
}