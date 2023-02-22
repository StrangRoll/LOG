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
        private bool _isActive = false;


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
            _isActive = false;
        }

        public void Move()
        {
            if (_isActive)
                return;
            
            var attack = DOTween.Sequence();
            attack.Append(_bulletTransform.DOLocalRotate(_endRotation, _hitDuration).SetRelative(true).SetEase(Ease.InQuad));
            attack.AppendCallback(ActivateExplosion);
            attack.Append(_bulletTransform.DOLocalMoveY(_bounceHeight, _hitDelay / 2f).SetEase(Ease.OutBounce));
            attack.Append(_bulletTransform.DOLocalMoveY(0f, _hitDelay / 2f).SetEase(Ease.InOutSine));
            attack.AppendCallback(DeactivateExplosion);
            attack.Append(_bulletTransform.DOLocalRotate(_endRotation * (-1), _returnDuration).SetRelative(true).SetEase(Ease.OutQuad));
            attack.Play();
            _isActive = true;
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