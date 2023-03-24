using System;
using UnityEngine;
using UnityEngine.Events;
using NotImplementedException = System.NotImplementedException;

namespace Script.Shoot.Devices.Ammo.BulletEffectTypes
{
    public class OnCollisionEffect : IBulletEffect
    {
        private ParticleSystem _bulletEffect;

        private UnityAction _exposionEvent;
        
        public OnCollisionEffect(ParticleSystem bulletEffect, ref UnityAction exploseEvent)
        {
            _bulletEffect = bulletEffect;
            exploseEvent += OnExplose;
        }

        private void OnExplose()
        {
            PlayEffect();
        }
        
        public void PlayEffect()
        {
            _bulletEffect.transform.rotation = Quaternion.identity;
            _bulletEffect.Play();
        }

        public void OnBulletDespawn()
        {
            return;
        }
    }
}