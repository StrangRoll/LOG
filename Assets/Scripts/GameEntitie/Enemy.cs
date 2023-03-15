using NTC.Global.Pool;
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
            if (collision.gameObject.TryGetComponent(out IDamagable component) == false)
                return;
            
            if (component.Type != DamagableType.Player)
                return;
            
            component.TakeDamage(Damage);
        }

        public void Kill()
        {
            TakeDamage(1);
        }

        public void TakeDamage(int damage)
        {
            EnemyDie?.Invoke(this);
            NightPool.Despawn(gameObject);
        }
    }
}