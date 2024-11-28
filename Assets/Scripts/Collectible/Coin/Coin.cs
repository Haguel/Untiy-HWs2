using UnityEngine;

public class Coin : Collectible
{
    [SerializeField] private int _coinValue;
    
    public int CoinValue => _coinValue;
}