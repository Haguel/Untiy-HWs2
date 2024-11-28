using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
{
    [Header("General")]
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [Header("Movement")]
    [SerializeField] private float _speed;
    [SerializeField] private float _moveDistance;

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        var movementVector = new Vector2(0f, _playerInput.VerticalInput) * (_speed * Time.fixedDeltaTime);
        
        var clampPosition = _rigidbody2D.position + movementVector;
        clampPosition.y = Mathf.Clamp(clampPosition.y, -_moveDistance, _moveDistance);
        
        _rigidbody2D.MovePosition(clampPosition);
    }
}
