using System;
using Script.Health;
using Script.Mover;
using UnityEngine;

// ReSharper disable once IdentifierTypo
namespace Script.GameEntitie
{
    [RequireComponent(typeof(EnemyMover))]
    public abstract class Enemy : MonoBehaviour, IDamagable
    {
        private const int Damage = 1;

        public DamagableType Type { get; } = DamagableType.Enemy;

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent(out Player player))
                player.TakeDamage(Damage);
        }

        public void TakeDamage(int damage)
        {
            Destroy(gameObject);
        }
    }
}