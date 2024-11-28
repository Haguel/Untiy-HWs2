using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _health;
    public event UnityAction OnCoinPickUp;
    public event UnityAction OnHealthPickUp;
    
    private int _score;
    private int _currentHealth;
    
    public event UnityAction OnDamageTake;

    private void Start()
    {
        _currentHealth = _health;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Coin coin))
        {
            _score += coin.CoinValue;
            OnCoinPickUp?.Invoke();
        } else if (other.TryGetComponent(out Enemy enemy))
        {
            if (enemy.Damage < 0)
                return;

            _currentHealth -= enemy.Damage;
            OnDamageTake?.Invoke();
        }
        else if (other.TryGetComponent(out Heart heart))
        {
            OnHealthPickUp?.Invoke();
        }
    }
}
