using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private TMP_Text _healthText;
    [SerializeField] private int _nextSceneIndex;

    private List<Coin> _coins;
    private int _healthValue;

    public event UnityAction OnHealthUpdate;

    private void Start()
    {
        InitializeHealth();
    }

    private void OnEnable()
    {
        _player.OnHealthPickUp += AddHealth;
        _player.OnDamageTake += TakeAwayHealth;
    }

    private void OnDisable()
    {
        _player.OnHealthPickUp -= AddHealth;
        _player.OnDamageTake -= TakeAwayHealth;

    }

    private void InitializeHealth()
    {
        _coins = new List<Coin>(FindObjectsOfType<Coin>());
        _healthValue = 100;
        UpdateHealthText();
    }

    private void AddHealth()
    {
        if (_healthValue < 100)
        {
            _healthValue += 20;
            UpdateHealthText();
        }
    }
    
    private void TakeAwayHealth()
    {
        _healthValue -= 20;
        UpdateHealthText();

        if (_healthValue == 0)
        {
            OnHealthUpdate?.Invoke();
        }
    }
    
    

    private void UpdateHealthText()
    {
        _healthText.text = $"Health: {_healthValue}";
    }
}
