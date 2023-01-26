using Script.Health;
using UnityEngine;
using UnityEngine.Events;

// ReSharper disable once IdentifierTypo
namespace Script.GameEntitie
{
    public abstract class Enemy : MonoBehaviour, IDamagable
    {
        private const int Damage = 1;

        public event UnityAction<Enemy> EnemyDie;
        
        public DamagableType Type { get; } = DamagableType.Enemy;

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent(out Player player))
                player.TakeDamage(Damage);
        }

        public void TakeDamage(int damage)
        {
            EnemyDie?.Invoke(this);
            Destroy(gameObject);
        }
    }
}