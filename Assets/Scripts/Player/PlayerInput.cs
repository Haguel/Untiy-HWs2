using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public float VerticalInput { get; private set; }

    private void Update() => VerticalInput = Input.GetAxis("Vertical");
}
