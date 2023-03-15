using Script.Health;
using Script.Input;
using Script.Mover;
using Script.Shoot;
using Script.Shoot.Devices.Arms;
using Script.Wave;
using UnityEngine;
using UnityEngine.Events;
using Zenject;
using Random = UnityEngine.Random;

// ReSharper disable once IdentifierTypo
namespace Script.GameEntitie
{
    public class Player: MonoBehaviour, IAttacker, IDamagable
    {
        [SerializeField] private Weapon[] allWeapons;
        
        [Inject] private PlayerInputRoot _inputRoot;
        [Inject] private WavesController _wavesController;

        private Weapon _currentWeapon = null;
        private ToSavedPositionMover _positionMover;
        private bool _isReadyToWeaponChange;

        public event UnityAction PlayerDead;
        public event UnityAction<Weapon> WeaponChanged;

        public DamagableType Type { get; } = DamagableType.Player;
        public DamagableType[] Targets { get; } = new DamagableType[] { DamagableType.Enemy};

        private void Awake()
        {
            _positionMover = new ToSavedPositionMover();
            var playerTransform = transform;
            _positionMover.Init(playerTransform, playerTransform.position);
        }

        private void OnEnable()
        {
            _inputRoot.Shoot += OnShoot;
            _wavesController.WaveChanged += OnWaveChanged;
        }

        private void OnDisable()
        {
            _inputRoot.Shoot -= OnShoot;
            _wavesController.WaveChanged -= OnWaveChanged;
        }

        public void Kill()
        {
            TakeDamage(1);
        }

        public void TakeDamage(int damage)
        {
            gameObject.SetActive(false);
            PlayerDead?.Invoke();
            _inputRoot.Reset();
        }

        public void Reset()
        {
            gameObject.SetActive(false);
            _positionMover.ChangePosition();
            gameObject.SetActive(true);
            ChangeWeapon();
            _isReadyToWeaponChange = true;
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

        private void ChangeWeapon()
        {
            _currentWeapon?.gameObject.SetActive(false);

            var newWeaponIndex = Random.Range(0, allWeapons.Length);

            while (allWeapons[newWeaponIndex] == _currentWeapon)
            {
                newWeaponIndex = Random.Range(0, allWeapons.Length);
            }

            _currentWeapon = allWeapons[newWeaponIndex];
            _currentWeapon.gameObject.SetActive(true);  
            WeaponChanged?.Invoke(_currentWeapon);
        }

        private void OnWaveChanged(float currentWave, float nextWave, float waveTime)
        {
            if (_isReadyToWeaponChange)
                ChangeWeapon();

            _isReadyToWeaponChange = !_isReadyToWeaponChange;
        }
    }
}