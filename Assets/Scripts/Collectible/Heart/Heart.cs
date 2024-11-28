using UnityEngine;

public class Heart : Collectible
{
    [SerializeField] private int _healValue;
    
    public int HealValue => _healValue;
}
