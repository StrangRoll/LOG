using Script.Health;
using UnityEngine;

// ReSharper disable once IdentifierTypo
namespace Script.GameEntitie
{
    public class Enemy : MonoBehaviour, IDamagable
    {
        public void TakeDamage(int damage)
        {
            Destroy(this);
        }
    }
}