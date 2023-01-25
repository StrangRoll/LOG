using Script.Health;
using UnityEngine;

namespace Script.Shoot
{
    public class OutOfBound: MonoBehaviour, IDamagable
    {
        public DamagableType Type { get; } = DamagableType.OutOfBound;
        public void TakeDamage(int damage)
        {
            return;
        }
    }
}