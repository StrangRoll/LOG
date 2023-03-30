using UnityEngine;
using NotImplementedException = System.NotImplementedException;

namespace Script.Shoot.Devices.Ammo.BulletEffectTypes
{
    public class NotFollowingEffect : IBulletEffect
    {
        private ParticleSystem _shootEffect;
        private Transform _bulletTransform;
        private Vector3 _startPosition;
        private Vector3 _startRotation;

        public NotFollowingEffect(ParticleSystem shootEffect, Transform bulletTransform, 
            Vector3 startPosition, Vector3 startRotation)
        {
            _shootEffect = shootEffect;
            _bulletTransform = bulletTransform;
            _startPosition = startPosition;
            _startRotation = startRotation;
            ChangeParent(bulletTransform, startPosition, startRotation);
        }
        
        public void PlayEffect()
        {
            _shootEffect.transform.localPosition = _startPosition;
            _shootEffect.transform.localRotation =  Quaternion.LookRotation(_startRotation);
            _shootEffect.transform.parent = null;
            _shootEffect.gameObject.SetActive(true);
            _shootEffect.Play();
        }
        
        private void ChangeParent(Transform bulletTransform, 
            Vector3 effectPosition, Vector3 effectRotation)
        {
            var shootTransform = _shootEffect.transform;
            shootTransform.parent = bulletTransform;
            shootTransform.localPosition = effectPosition;
            shootTransform.localRotation =  Quaternion.LookRotation(effectRotation);
        }
    }   
}