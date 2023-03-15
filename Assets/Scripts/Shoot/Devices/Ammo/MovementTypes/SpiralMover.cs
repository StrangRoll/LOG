using DG.Tweening;
using UnityEngine;
using NotImplementedException = System.NotImplementedException;

namespace Script.Shoot.Devices.Ammo.MovementTypes
{
    public class SpiralMover : IBulletMover
    {
        private Transform _bulletTransform;
        private float _duration;
        private float _distance;
        private float _deltaDistance;
        private float _deltaTime;
        private Vector3 _center;
        private int _pointPerLoop;
        private int _circleCount;
        private Tween _animation;
        private bool _isReadyToStartMoving;

        public SpiralMover(Transform bulletTransform, float duration, float distance, float deltaDistance, int pointPerLoop, int circleCount, Vector3 startPosition)
        {
            _bulletTransform = bulletTransform;
            _center = startPosition;
            _duration = duration;
            _distance = distance;
            _deltaDistance = deltaDistance;
            _pointPerLoop = pointPerLoop;
            _circleCount = circleCount;
            _isReadyToStartMoving = true;
        }

        public void MoveEachFrame()
        {
            return;
        }

        public void StartMove()
        {
            _isReadyToStartMoving = true;
            Move();
        }

        public void StopMove()
        {
            _animation.Pause();
            _animation.Kill();
            _animation = null;
            _isReadyToStartMoving = false;
        }

        private void Move()
        {
            if (_isReadyToStartMoving == false)
                return;
            
            _isReadyToStartMoving = false;
            var path = CreatePath();
            _animation = _bulletTransform.DOPath(path, _duration, PathType.CatmullRom)
                .SetEase(Ease.Linear)
                .OnComplete(OnAttackEnded);
        }

        private Vector3[] CreatePath()
        {
            var pointCount = _pointPerLoop * _circleCount;
            var pathPoints = new Vector3[pointCount];
             
            var angle = 0f;
            var angleStep = 360f / _pointPerLoop;

            for (var j = 0; j < _circleCount; j++)
            {
                for (var i = 0; i < _pointPerLoop; i++)
                {
                    var x = _center.x + _distance * Mathf.Sin(Mathf.Deg2Rad * angle);
                    var z = _center.z + _distance * Mathf.Cos(Mathf.Deg2Rad * angle);
                    var y = _center.y;

                    pathPoints[j * _pointPerLoop + i] = new Vector3(x, y, z);

                    angle += angleStep;
                    _distance += _deltaDistance;
                }
            }
            
            return pathPoints;
        }

        private void OnAttackEnded()
        {
            StopMove();
        }
    }
}