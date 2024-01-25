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
}
