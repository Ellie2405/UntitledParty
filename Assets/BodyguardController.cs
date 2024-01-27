using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.UI;
using UnityEngine;

public class BodyguardController : Pathfinder
{
    FlashlightBeamController flashlightBeamController;
    public float threatIncreaseTime = 1f;
    public float threatIncreaseAmount = 15;
    ThreatManager threatManager;
    private float timeSinceLastPunishment = 0;

    protected new void Start()
    {
        threatManager = GameObject.FindGameObjectWithTag("TM").GetComponent<ThreatManager>();

        flashlightBeamController = this.GetComponentInChildren<FlashlightBeamController>();
        
        base.Start();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            if (other.gameObject.GetComponent<Player>().isInMinigame)
            {
                threatManager.IncreaseThreat(100);
            }
            flashlightBeamController.shouldRotate = false;
            canMove = false;
        }
    }
    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            timeSinceLastPunishment += Time.fixedDeltaTime;

            if (timeSinceLastPunishment >= threatIncreaseTime)
            {
                timeSinceLastPunishment = 0;
                threatManager.IncreaseThreat(threatIncreaseAmount);
            }
        }   
    }
    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            flashlightBeamController.shouldRotate = true;
            StartCoroutine(base.ResetMOvemtn());
        }
    }

}
