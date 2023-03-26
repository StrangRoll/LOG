using System;
using UnityEngine;
using UnityEngine.Events;
using NotImplementedException = System.NotImplementedException;

namespace Script.Shoot.Devices.Ammo.BulletEffectTypes
{
    public class OnCollisionEffect : IBulletEffect
    {
        private ParticleSystem _bulletEffect;
        private Transform _bulletTransform;
        private Vector3 _startPosition;
        private bool _isChangingParentDuringEffect; 
        
        public OnCollisionEffect(ParticleSystem bulletEffect, ref UnityAction exploseEvent,
            bool isChangingParentDuringEffect = false, Transform bulletTransform = null)
        {
            _bulletEffect = bulletEffect;
            _startPosition = bulletEffect.transform.localPosition;
            _bulletTransform = bulletTransform;
            _isChangingParentDuringEffect = isChangingParentDuringEffect;
            exploseEvent += OnExplose;
        }

        private void OnExplose()
        {
            PlayEffect();
        }

        public void PlayEffect()
        {
            var bulletEffectTransform = _bulletEffect.transform;
            bulletEffectTransform.rotation = Quaternion.identity;
            
            if (_isChangingParentDuringEffect)
                bulletEffectTransform.parent = null;
            
            _bulletEffect.Play();
        }

        public void OnBulletDisable()
        {
            if (_isChangingParentDuringEffect == false)
                return;
            
            var bulletEffectTransform = _bulletEffect.transform;
            bulletEffectTransform.parent = _bulletTransform;
            bulletEffectTransform.localPosition = _startPosition;
        }
    }
}