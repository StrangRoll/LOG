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
            if (!collision.gameObject.TryGetComponent(out IDamagable component))
                return;
            
            Debug.Log("Enemy Hit");

            if (component.Type != DamagableType.Player)
                return;
            
            Debug.Log("Player Collision");
            component.TakeDamage(Damage);
        }

        public void TakeDamage(int damage)
        {
            EnemyDie?.Invoke(this);
            Destroy(gameObject);
        }
    }
}