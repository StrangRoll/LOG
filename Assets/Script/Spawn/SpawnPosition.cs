using UnityEngine;

namespace Script.Spawn
{
    public class SpawnPosition: MonoBehaviour
    {
        [SerializeField] private float height;
        
        public float Height => height;
        public Vector3 Position => transform.position;
    }
}