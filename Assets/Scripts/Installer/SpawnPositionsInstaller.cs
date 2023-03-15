using Script.Spawn;
using UnityEngine;
using Zenject;

public class SpawnPositionsInstaller : MonoInstaller
{
    [SerializeField] private SpawnPosition[] _spawnPositions;
    
    private Vector3[] _positions;

    public override void InstallBindings()
    {
        _positions = new Vector3[_spawnPositions.Length];
        for (int i = 0; i < _spawnPositions.Length; i++)
        {
            _positions[i] = _spawnPositions[i].Position + Vector3.up * _spawnPositions[i].Height;
        }

        Container
            .Bind<Vector3[]>()
            .FromInstance(_positions);
    }
}