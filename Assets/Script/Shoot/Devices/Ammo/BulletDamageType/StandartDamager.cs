using Script.Health;
using NotImplementedException = System.NotImplementedException;

namespace Script.Shoot.Devices.Ammo.BulletDamageType
{
    public class StandartDamager : IBulletDamager
    {
        private int _damage;
        
        public StandartDamager(int damage)
        {
            _damage = damage;
        }

        public void Damage(IDamagable damagableObject)
        {
            damagableObject.TakeDamage(_damage);
        }
    }
}