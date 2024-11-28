using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CollectibleMover : UnitMover
{
    private void FixedUpdate()
    {
        Move();
    }
}
