using Script.Shoot.Devices.Ammo.BulletDamageType;
using Script.Shoot.Devices.Ammo.MovementTypes;
using UnityEngine;
using NotImplementedException = System.NotImplementedException;

namespace Script.Shoot.Devices.Ammo
{
    public class MachinegunBullet : Bullet
    {
        [SerializeField] private int damage;
        [SerializeField] private float minSpeed;
        [SerializeField] private float maxSpeed;

        protected override void SetMovementType()
        {
            var speed = Random.Range(minSpeed, maxSpeed + 1);
            bulletMover = new MoveForward(transform, speed);
        }

        protected override void SetDamageType()
        {
            bulletDamager = new StandartDamager(damage);
        }
    }
}