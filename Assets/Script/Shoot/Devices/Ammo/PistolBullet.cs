using UnityEngine;

namespace Script.Shoot.Devices.Ammo
{
    public class PistolBullet : global::Script.Shoot.Devices.Ammo.Bullet
    {
        public override void Move()
        {
            transform.Translate(Vector3.forward * (speed * Time.deltaTime));
        }
    }
}
