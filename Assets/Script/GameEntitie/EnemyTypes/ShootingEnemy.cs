using Script.Health;
using Script.Mover;
using Script.Shoot;
using Script.Shoot.Devices.Arms;
using UnityEngine;
using Zenject;

namespace Script.GameEntitie.EnemyTypes
{
    public class ShootingEnemy: Enemy, IAttacker
    {
        [Inject] private PlayerMover _playerMover;
        
        [SerializeField] private Weapon weapon;
        [SerializeField] private float attackDistance;

        private Transform _playerTransform;
        
        public DamagableType[] Targets { get; } = new DamagableType[] { DamagableType.Player};

        private void Start()
        {
            _playerTransform = _playerMover.transform;
        }

        private void FixedUpdate()
        {
            Attack(Targets);
            transform.LookAt(_playerTransform);
        }

        public void Attack(DamagableType[] targets)
        {
            if (Vector3.Distance(_playerTransform.position, transform.position) < attackDistance)
                weapon.TryShoot(targets);
        }
    }
}