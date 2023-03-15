using Script.Health;

namespace Script.Shoot.Devices.Ammo.BulletDamageType
{
    public interface IBulletDamager
    {
        public void Damage(IDamagable damagableObject);
    }
}