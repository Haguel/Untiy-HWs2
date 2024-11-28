using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyMover : UnitMover
{
    private void FixedUpdate()
    {
        Move();
    }
}
