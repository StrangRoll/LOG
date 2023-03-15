using Script.Health;
using UnityEngine;

namespace Script.GameEntitie.EnemyTypes
{
    public class Killbox : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out IDamagable component) == false)
                return;
            
            component.Kill();
        }
    }
}