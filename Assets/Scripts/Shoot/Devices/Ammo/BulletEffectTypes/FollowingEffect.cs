using UnityEngine;
using NotImplementedException = System.NotImplementedException;

namespace Script.Shoot.Devices.Ammo.BulletEffectTypes
{
    public class FollowingEffect : IBulletEffect
    {
        private ParticleSystem _shootEffect;

        public FollowingEffect(ParticleSystem shootEffect)
        {
            _shootEffect = shootEffect;
        }

        public void PlayEffect()
        {
            _shootEffect.Play();
        }
    }
}