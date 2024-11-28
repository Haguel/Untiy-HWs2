using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<WaveSpawnerScriptableObject> _wavesData;
    
    private List<UnitMover> _spawnedUnits = new List<UnitMover>();

    private float _timeToSpawn;
    private float _timeToNextWave;
    private int _currentWaveIndex;
    
    public event UnityAction<int> OnWaveSpawned;
    public event UnityAction OnAllWavesFinished;
    
    private void Start()
    {
        InitializeSpawn(_wavesData[_currentWaveIndex]);
    }

    private void Update()
    {
        ActiveSelfChecker(_wavesData[_currentWaveIndex]);
        NextWaveChecker();
    }

    private void InitializeSpawn(WaveSpawnerScriptableObject wave)
    {
        for (var i = 0; i < wave.SpawnSize; i++)
        {
            var newUnit = Instantiate(GetRandomUnit(wave), RandomPosition(wave), Quaternion.identity);
            newUnit.gameObject.SetActive(false);
            _spawnedUnits.Add(newUnit);
            OnWaveSpawned?.Invoke(wave.WaveNumber);
        }
    }

    private void ActiveSelfChecker(WaveSpawnerScriptableObject wave)
    {
        _timeToSpawn += Time.deltaTime;

        foreach (var unit in _spawnedUnits)
        {
            if (!unit.gameObject.activeSelf && _timeToSpawn >= wave.SpawnDelay)
            {
                unit.transform.position = RandomPosition(wave);
                unit.gameObject.SetActive(true);
                _timeToSpawn = 0f;
            }
        }
    }

    private void NextWaveChecker()
    {
        _timeToNextWave += Time.deltaTime;

        if (_timeToNextWave >= _wavesData[_currentWaveIndex].WaveDuration)
        {
            foreach (var unit in _spawnedUnits.ToList())
            {
                _spawnedUnits.Remove(unit);
                Destroy(unit.gameObject);
            }
            
            if (_currentWaveIndex < _wavesData.Count - 1)
            {
                _currentWaveIndex++;
                InitializeSpawn(_wavesData[_currentWaveIndex]);
                _timeToNextWave = 0f;
            }
            else
            {
                OnAllWavesFinished?.Invoke();
            }
        }
    }

    private UnitMover GetRandomUnit(WaveSpawnerScriptableObject wave)
    {
        return wave.Templates[Random.Range(0, wave.Templates.Count)];
    }
    
    private Vector2 RandomPosition(WaveSpawnerScriptableObject wave)
    {
        return new Vector2(transform.position.x, Random.Range(-wave.SpawnPositionRange, wave.SpawnPositionRange));
    }
}
