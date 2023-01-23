using Script.Input;
using Script.Shoot;
using Script.Shoot.Devices.Arms;
using UnityEngine;
using Zenject;

// ReSharper disable once IdentifierTypo
namespace Script.GameEntitie
{
    public class Player: MonoBehaviour, IAttacker
    {
        [SerializeField] private Weapon[] allWeapons;
        
        [Inject] private PlayerInputRoot _inputRoot;

        private Weapon _currentWeapon;

        private void OnEnable()
        {
            _inputRoot.Shoot += OnShoot;
        }

        private void Awake()
        {
            _currentWeapon = allWeapons[0];
        }

        private void OnDisable()
        {
            _inputRoot.Shoot -= OnShoot;
        }

        public void Attack()
        {
            try
            {
                _currentWeapon.Shoot();
            }
            catch 
            {
                Debug.LogError("Try to Invoke method 'Shoot' in current weapon, but it doesn't exist");
            }
        }

        private void OnShoot()
        {
            Attack();
        }
    }
}