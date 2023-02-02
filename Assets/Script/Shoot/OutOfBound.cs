using Script.Health;
using UnityEngine;
using NotImplementedException = System.NotImplementedException;

namespace Script.Shoot
{
    public class OutOfBound: MonoBehaviour, IDamagable
    {
        public DamagableType Type { get; } = DamagableType.OutOfBound;
        public void TakeDamage(int damage)
        {
            return;
        }

        public void Kill()
        {
            return;
        }
    }
}