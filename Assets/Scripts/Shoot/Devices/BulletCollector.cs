using System.Collections.Generic;
using NTC.Global.Pool;
using Script.Shoot.Devices.Ammo;
using Script.System;
using UnityEngine;
using Zenject;

namespace Script.Shoot.Devices
{
    public class BulletCollector : MonoBehaviour
    {
        [Inject] private GameRestarter _gameRestarter;
        
        private List<Bullet> _bullets = new List<Bullet>();

        private void OnEnable()
        {
            _gameRestarter.GameRestarted += OnGameRestarted;
        }

        private void OnDisable()
        {
            _gameRestarter.GameRestarted -= OnGameRestarted;
        }

        private void OnGameRestarted(bool arg0)
        {
            var bulletsToRemove = new Bullet[_bullets.Count];

            for (var i = 0; i < _bullets.Count; i++)
            {
                bulletsToRemove[i] = _bullets[i];
            }

            foreach (var bullet in bulletsToRemove)
            {
                _bullets.Remove(bullet);
                NightPool.Despawn(bullet);
            }
        }

        public void Register(Bullet bullet)
        {
            _bullets.Add(bullet);
        }

        public void UnRegister(Bullet bullet)
        {
            try
            {
                _bullets.Remove(bullet);
            }
            catch 
            {
                Debug.LogError("Try to remove a bullet that is not registered.");
            }
        }
        
        
    }
}