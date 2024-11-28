using UnityEngine;

public class Enemy : Unit
{
    [SerializeField] private int _damage;
    
    public int Damage => _damage;
}
