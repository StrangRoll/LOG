using Script.Spawn;
using UnityEngine;
using Zenject;

namespace Script.Installer
{
    public class EnemySpawnerInstaller : MonoInstaller
    {
        [SerializeField] private EnemySpawner enemySpawner;
    
        public override void InstallBindings()
        {
            Container
                .Bind<EnemySpawner>()
                .FromInstance(enemySpawner)
                .AsSingle();
        }
    }
}