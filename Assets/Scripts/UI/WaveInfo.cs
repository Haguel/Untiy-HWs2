using System;
using TMPro;
using UnityEngine;

public class WaveInfo : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Spawner _spawner;

    private void OnEnable()
    {
        _spawner.OnWaveSpawned += OnWaveSpawned;
    }

    private void OnDisable()
    {
        _spawner.OnWaveSpawned -= OnWaveSpawned;
    }

    private void OnWaveSpawned(int waveNumber)
    {
        _text.text = $"Wave {waveNumber}";
    }
}
