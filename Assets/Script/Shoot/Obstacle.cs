using Script.Health;
using UnityEngine;

namespace Script.Shoot
{
    public class Obstacle: MonoBehaviour, IDamagable
    {
        public DamagableType Type { get; } = DamagableType.Obstacle;

        public void TakeDamage(int damage)
        {
            return;
        }
    }
}