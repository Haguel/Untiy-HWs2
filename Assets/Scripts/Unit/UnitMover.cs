using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public abstract class UnitMover : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private float _speed;
    
    protected virtual void Move()
    {
        _rigidbody2D.linearVelocity = -transform.right * _speed;
    }
    
}