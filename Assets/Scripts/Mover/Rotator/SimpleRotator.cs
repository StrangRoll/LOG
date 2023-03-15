using UnityEngine;

namespace Script.Mover.Rotator
{
    public class SimpleRotator : MonoBehaviour
    {
        [SerializeField] private Vector3 axis;
        [SerializeField] private float speed;

        private void Update()
        {
            transform.Rotate(axis, speed * Time.deltaTime);
        }
    }
}