using Script.Health;

namespace Script.Shoot
{
    public interface IAttacker
    {
        public void Attack(DamagableType[] targets);
        
        public DamagableType[] Targets { get; }
    }
}