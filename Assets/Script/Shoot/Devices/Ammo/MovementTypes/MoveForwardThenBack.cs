using DG.Tweening;
using UnityEngine;
using NotImplementedException = System.NotImplementedException;

namespace Script.Shoot.Devices.Ammo.MovementTypes
{
    public class MoveForwardThenBack : IBulletMover
    {
        private Transform _bulletTransform;
        private Vector3 _originalPosition;
        private float _duration;
        private float _distance;
        private Sequence _hitAnimation;


        public MoveForwardThenBack(Transform bulletBulletTransform, float distance, float speed)
        {
            _bulletTransform = bulletBulletTransform;
            _duration = distance / speed;
            _distance = distance;
            CreateAnimation();
        }

        public void MoveEachFrame()
        {
            return;
        }

        public void StartMove()
        {
            _hitAnimation.Restart();
        }

        public void StopMove()  
        {
            _hitAnimation.Pause();
        }

        private void CreateAnimation()
        {
            _originalPosition = _bulletTransform.localPosition;
            _hitAnimation = DOTween.Sequence().SetAutoKill(false);
            
            var targetPosition = _originalPosition + Vector3.forward * _distance;
            _hitAnimation.Append(_bulletTransform.DOLocalMove(targetPosition, _duration));
            _hitAnimation.Append(_bulletTransform.DOLocalMove(_originalPosition, _duration));
            _hitAnimation.Pause();
        }
    }
}