using UnityEngine;
using UnityEngine.Events;
using NotImplementedException = System.NotImplementedException;

namespace Script.Shoot.Devices.Ammo.BulletEffectTypes
{
    public class TrailWithExploseEffect : IBulletEffect
    {
        private FollowingEffect _followingEffect;
        private OnCollisionEffect _collisionEffect;

        public TrailWithExploseEffect(ParticleSystem trailEffect, ParticleSystem exploseEffect, 
            ref UnityAction exploseEvent)
        {
            _followingEffect = new FollowingEffect(trailEffect);
            _collisionEffect = new OnCollisionEffect(exploseEffect, ref exploseEvent);
            PlayEffect();
        }
        
        public void PlayEffect()
        {
            _followingEffect.PlayEffect();
        }
    }
}