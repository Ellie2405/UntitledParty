using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntecartionArea : MonoBehaviour
{
    int numOfNPC;
    public bool CanInteract;
    public List<GameObject> InteractNPC;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }




    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("NPC"))
            InteractNPC.Add(other.gameObject);
        
        CanInteract = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("NPC"))
            InteractNPC.Remove(other.gameObject);

        if (InteractNPC.Count == 0)
            CanInteract = false;
    }
}
