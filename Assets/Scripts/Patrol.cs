using UnityEngine;

public class Patrol : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the entering collider has a specific tag (optional).
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered the trigger zone!");
            // Do something when the player enters the trigger zone.
        }
    }
}
