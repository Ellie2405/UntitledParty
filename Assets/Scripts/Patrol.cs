using UnityEngine;

public class Patrol : MonoBehaviour
{
    private bool playerSpotted = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) 
            return;

        Debug.Log("Player entered the trigger zone!");
        playerSpotted = true;
        StartCoroutine(TriggeredAction());
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // Reset the flag when the player leaves the trigger zone.
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player exited the trigger zone!");
            playerSpotted = false;
        }
    }

    private System.Collections.IEnumerator TriggeredAction()
    {
        yield return new WaitForSeconds(5f); // Wait for 5 seconds

        if (playerSpotted)
        {
            Debug.Log("Player has been spotted for 5 seconds!");
        }
    }
}