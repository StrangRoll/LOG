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
        public DamagableType Type { get; } = DamagableType.Enemy;
        
        public void TakeDamage(int damage)
        {
            Destroy(gameObject);
        }
    }
}