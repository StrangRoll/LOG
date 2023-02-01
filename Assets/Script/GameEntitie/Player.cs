using NTC.Global.Pool;
using Script.Health;
using Script.Input;
using Script.Shoot;
using Script.Shoot.Devices.Arms;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

// ReSharper disable once IdentifierTypo
namespace Script.GameEntitie
{
    public class Player: MonoBehaviour, IAttacker, IDamagable
    {
        [SerializeField] private Weapon[] allWeapons;
        
        [Inject] private PlayerInputRoot _inputRoot;

        private Weapon _currentWeapon;

        public event UnityAction PlayerDead;

        public DamagableType Type { get; } = DamagableType.Player;
        public DamagableType[] Targets { get; } = new DamagableType[] { DamagableType.Enemy};
        
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

        public void TakeDamage(int damage)
        {
            gameObject.SetActive(false);
            PlayerDead?.Invoke();
        }   

        public void Attack(DamagableType[] targets)
        {
            try
            {
                _currentWeapon.TryShoot(targets);
            }
            catch 
            {
                Debug.LogError("Try to Invoke method 'Shoot' in current weapon, but it doesn't exist");
            }
        }

        private void OnShoot()
        {
            Attack(Targets);
        }
    }
}