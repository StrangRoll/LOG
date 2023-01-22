using UnityEngine;

namespace Script.Shoot.Devices.Ammo
{
    public class MovingForwardBullet : Bullet
    {
        public override void Move()
        {
            transform.Translate(Vector3.left * (speed * Time.deltaTime));
        }
    }
}
