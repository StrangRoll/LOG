using UnityEngine;
using DG.Tweening;
using NotImplementedException = System.NotImplementedException;

namespace Script.Shoot.Devices.Ammo.MovementTypes
{
    public class RotateAndExplose : IBulletMover
    {
        private readonly Vector3 _endRotation;
        private readonly float _hitDuration;
        private readonly float _returnDuration;
        private readonly float _hitDelay;
        private readonly Transform _bulletTransform;
        private readonly Collider _explosionCollider;
        private readonly float _bounceHeight;
        private Sequence _hitAnimation;


        public RotateAndExplose(Transform bulletTransform, float hitDuration, float hitDelay, float bounceHeight, float returnDuration, 
            Vector3 endRotation, Collider explosionCollider)
        {
            _bulletTransform = bulletTransform;
            _endRotation = endRotation;
            _hitDuration = hitDuration;
            _hitDelay = hitDelay;
            _returnDuration = returnDuration;
            _explosionCollider = explosionCollider;
            _bounceHeight = bounceHeight;
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
            _hitAnimation = DOTween.Sequence().SetAutoKill(false);
            _hitAnimation.Append(_bulletTransform.DOLocalRotate(_endRotation, _hitDuration).SetRelative(true).SetEase(Ease.InQuad));
            _hitAnimation.AppendCallback(ActivateExplosion);
            _hitAnimation.Append(_bulletTransform.DOLocalMoveY(_bounceHeight, _hitDelay / 2f).SetEase(Ease.OutBounce));
            _hitAnimation.Append(_bulletTransform.DOLocalMoveY(0f, _hitDelay / 2f).SetEase(Ease.InOutSine));
            _hitAnimation.AppendCallback(DeactivateExplosion);
            _hitAnimation.Append(_bulletTransform.DOLocalRotate(_endRotation * (-1), _returnDuration).SetRelative(true).SetEase(Ease.OutQuad));
            _hitAnimation.Pause();
        }

        private void ActivateExplosion()
        {
            _explosionCollider.enabled = true;
        }

        private void DeactivateExplosion()
        {
            _explosionCollider.enabled = false; 
        }
    }
}