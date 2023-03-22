using UnityEngine;
using NotImplementedException = System.NotImplementedException;

namespace Script.Shoot.Devices.Ammo.BulletEffectTypes
{
    public class NotFollowingEffect : IBulletEffect
    {
        private ParticleSystem _shootEffect;
        private Transform _bulletTransform;
        private Vector3 _startPosition;

        public NotFollowingEffect(ParticleSystem shootEffect, Transform bulletTransform, 
            Vector3 startPosition)
        {
            _shootEffect = shootEffect;
            _bulletTransform = bulletTransform;
            _startPosition = startPosition;
        }
        
        public void PlayEffect()
        {
            _shootEffect.transform.parent = null;
            _shootEffect.gameObject.SetActive(true);
            _shootEffect.Play();
        }

        public void OnBulletDespawn()
        {
            var shootTransform = _shootEffect.transform;
            shootTransform.parent = _bulletTransform;
            shootTransform.localPosition = _startPosition;
        }
    }   
}