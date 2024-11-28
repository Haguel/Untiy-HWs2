using UnityEngine;

public abstract class Unit : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        gameObject.SetActive(false);        
    }
}