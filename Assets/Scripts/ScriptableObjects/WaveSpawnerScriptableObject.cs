using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Spawner/NewWave", fileName = "NewWave")]
public class WaveSpawnerScriptableObject : ScriptableObject
{
    [SerializeField] private int _waveNumber;
    [SerializeField] private List<UnitMover> _templates;
    [SerializeField] private int _spawnSize;
    [SerializeField] private float _spawnDelay;
    [SerializeField] private int _spawnPositionRange;
    [SerializeField] private float _waveDuration;

    public int WaveNumber => _waveNumber;
    public List<UnitMover> Templates => _templates;
    public int SpawnSize => _spawnSize;
    public float SpawnDelay => _spawnDelay;
    public int SpawnPositionRange => _spawnPositionRange;
    public float WaveDuration => _waveDuration;
}
