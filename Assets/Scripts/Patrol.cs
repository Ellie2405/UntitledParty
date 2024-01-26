using UnityEngine;

public class Patrol : MonoBehaviour
{
    private bool _playerSpotted;
    public float IncreaseThreatAmount = 10f;
    public float SpotTimeToAction = 5f;
    public ThreatManager ThreatManager;

    private void Start()
    {
        ThreatManager = GameObject.FindGameObjectWithTag("TM").GetComponent<ThreatManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) 
            return;

        Debug.Log("Player entered the trigger zone!");
        _playerSpotted = true;
        StartCoroutine(TriggeredAction());
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) 
            return;

        Debug.Log("Player exited the trigger zone!");
        _playerSpotted = false;
    }

    private System.Collections.IEnumerator TriggeredAction()
    {
        yield return new WaitForSeconds(SpotTimeToAction);

        if (!_playerSpotted) 
            yield break;

        Debug.Log($"Player has been spotted for {SpotTimeToAction} seconds!");

        if (ThreatManager == null) 
            yield break;

        Debug.Log($"Player has been spotted for {SpotTimeToAction} seconds! - IncreaseThreat");

        ThreatManager.IncreaseThreat(IncreaseThreatAmount);
    }
}