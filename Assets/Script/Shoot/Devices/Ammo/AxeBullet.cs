using Script.Shoot.Devices.Ammo.BulletCollisionTypes;
using Script.Shoot.Devices.Ammo.BulletDamageType;
using Script.Shoot.Devices.Ammo.MovementTypes;
using UnityEngine;
using NotImplementedException = System.NotImplementedException;

namespace Script.Shoot.Devices.Ammo
{
    public class AxeBullet : Bullet
    {
        [SerializeField] private int damage;
        [SerializeField] private float duration;
        [SerializeField] private float spiralRadius;
        [SerializeField] private float deltaRadius;
        [SerializeField] private int pointPerLoop;
        [SerializeField] private int circleCount;

        private void OnDisable()
        {
            try
            {
                bulletMover.StopMove();
            }
            catch
            {
                // ignored
            }
        }

        protected override void SetMovementType()
        {
            var bulletTransform = transform;
            bulletMover = new SpiralMover(bulletTransform, duration, spiralRadius, deltaRadius, pointPerLoop, circleCount, bulletTransform.position);
            bulletMover.StartMove();
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