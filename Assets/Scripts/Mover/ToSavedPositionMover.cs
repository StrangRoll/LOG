using UnityEngine;

namespace Script.Mover
{
    public class ToSavedPositionMover
    {
        private Vector3 _startPosition;
        private Transform _transform;

        public void Init(Transform transform, Vector3 position)
        {
            _transform = transform;
            _startPosition = position;
        }

        public void ChangePosition()
        {
            _transform.position = _startPosition;
        }
    }
}