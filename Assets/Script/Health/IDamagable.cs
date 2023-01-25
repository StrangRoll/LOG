using Unity.Collections;

namespace Script.Health
{
    public interface IDamagable
    {
        public DamagableType Type { get; }
        
        public void TakeDamage(int damage);
    }
}