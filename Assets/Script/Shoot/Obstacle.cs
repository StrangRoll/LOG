using Script.Health;
using UnityEngine;
using NotImplementedException = System.NotImplementedException;

namespace Script.Shoot
{
    public class Obstacle: MonoBehaviour, IDamagable
    {
        public DamagableType Type { get; } = DamagableType.Obstacle;

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