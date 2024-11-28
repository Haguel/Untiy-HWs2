using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Score : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private int _nextSceneIndex;

    private List<Coin> _coins;
    private int _scoreValue;

    public event UnityAction OnScoreUpdate;

    private void Start()
    {
        InitializeScore();
    }

    private void OnEnable()
    {
        _player.OnCoinPickUp += AddScore;
    }

    private void OnDisable()
    {
        _player.OnCoinPickUp -= AddScore;
    }

    private void InitializeScore()
    {
        _coins = new List<Coin>(FindObjectsOfType<Coin>());
        _scoreValue = 0;
        UpdateScoreText();
    }

    private void AddScore()
    {
        _scoreValue++;
        UpdateScoreText();

        var activeCoins = _coins.FindAll(coin => coin.gameObject.activeSelf);

        if (activeCoins.Count == 0)
        {
            OnScoreUpdate?.Invoke();
        }
    }

    private void UpdateScoreText()
    {
        _scoreText.text = $"Score: {_scoreValue}";
    }
}