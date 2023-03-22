using UnityEngine;
using NotImplementedException = System.NotImplementedException;

namespace Script.Shoot.Devices.Ammo.BulletEffectTypes
{
    public class OnCollisionEffect : IBulletEffect
    {
        private ParticleSystem _bulletEffect;
        
        public OnCollisionEffect(ParticleSystem bulletEffect)
        {
            _bulletEffect = bulletEffect;
        }
        
        public void PlayEffect()
        {
            throw new NotImplementedException();
        }

        public void OnBulletDespawn()
        {   
            return;
        }
    }
}