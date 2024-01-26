using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] float Speed; // Adjust this value to control the movement speed
    private Rigidbody2D rb;
    SpriteRenderer ThisSprite;
    float horizontalInput;
    float verticalInput;


    [Header("Animations")]
    [SerializeField] Sprite[] WalkAnimation;
    [SerializeField] Animator AnimatorComp;


    [Header("NPC")]
    GameObject NearNPC;
    [Header("Other")]
    [SerializeField] IntecartionArea AreInteractionScript;
    [SerializeField] GM gm;
    
    int MovingDirection;   // -1 = left   0 = stand  1 = right
    void Start()
    {
        // Get the Rigidbody2D component attached to the GameObject
        rb = GetComponent<Rigidbody2D>();
        ThisSprite = GetComponent<SpriteRenderer>();
        AnimatorComp = GetComponent<Animator>();
    }

    void Update()
    {

        // Get input for movement
         horizontalInput = Input.GetAxis("Horizontal");
         verticalInput = Input.GetAxis("Vertical");

       WalkAnimationFunc();
        FlipChecker();
        // Calculate the movement direction
        Vector2 movement = new Vector2(horizontalInput, verticalInput);

        // Set the velocity based on the movement direction and speed
        rb.velocity = movement * Speed;

        InputChecker();
    }

    void InputChecker ()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            if (AreInteractionScript.CanInteract)
                InteractWithNPC(AreInteractionScript.InteractNPC);
        }


    }

    void InteractWithNPC (List<GameObject> NPC)
    {
   
        float Dis = 100;
        foreach(GameObject npc in NPC)
        {
            if(Vector2.Distance(gameObject.transform.position,npc.transform.position) < Dis)
            {
                NearNPC = npc;
                Dis = Vector2.Distance(gameObject.transform.position, npc.transform.position);
            }

        }


        NearNPC.GetComponent<Pathfinder>().CanMove = false ;
        NearNPC.GetComponent<NPC>().TurnOnTextBubble();
        gm.MiniGameManager.StartMiniGame();
    }

    void FlipChecker()
    {
        if (horizontalInput > 0)
            ThisSprite.flipX = false;
        else if(horizontalInput < 0 )
            ThisSprite.flipX = true;

    }

    void WalkAnimationFunc ()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S))
            AnimatorComp.SetBool("Walk", true);
        else
            AnimatorComp.SetBool("Walk", false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
    }
}
