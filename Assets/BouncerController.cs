using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.UI;
using UnityEngine;

public class BouncerController : Pathfinder
{
    FlashlightBeamController flashlightBeamController;
    
    public float threatIncreaseTime = 1f;
    public float threatIncreaseAmount = 15;
    ThreatManager threatManager;
    MiniGame minigameManager;

    private bool isInteracting = false;
    private float timeSinceLastPunishment = 0;

    protected new void Start()
    {
        threatManager = GameObject.FindGameObjectWithTag("TM").GetComponent<ThreatManager>();
        minigameManager = FindObjectOfType<MiniGame>();
        
        flashlightBeamController = this.GetComponentInChildren<FlashlightBeamController>();
        
        base.Start();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (!isInteracting && other.CompareTag("Player") && other.gameObject.GetComponent<Player>().isInMinigame)
        {
            isInteracting = true;
            // Stop flashlight and bouncer
            flashlightBeamController.shouldRotate = false;
            canMove = false;
            // Cancel minigame
            minigameManager.EndMiniGame(false);


        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        //Debug.Log("TriggerStay: " + other.name);
        if (isInteracting && other.CompareTag("Player") && other.gameObject.GetComponent<Player>().isInMinigame)
        {
            timeSinceLastPunishment += Time.fixedDeltaTime;
            if (timeSinceLastPunishment >= threatIncreaseTime)
            {
                threatManager.IncreaseThreat(threatIncreaseAmount);
                timeSinceLastPunishment = 0;

            }
        }   
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (isInteracting && other.gameObject.CompareTag("Player") && other.gameObject.GetComponent<Player>().isInMinigame)
        {
            flashlightBeamController.shouldRotate = true;
            StartCoroutine(ResetInteraction());
        }
    }

    protected IEnumerator ResetInteraction()
    {
        yield return new WaitForSeconds(1);
        isInteracting = false;
        canMove = true;
    }

}
