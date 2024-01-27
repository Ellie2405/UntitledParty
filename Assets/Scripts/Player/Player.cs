using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;



public class Player : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] float Speed; // Adjust this value to control the movement speed
    [SerializeField] DynamicSkin dSkin;
    private Rigidbody2D rb;
    SpriteRenderer ThisSprite;
    public float horizontalInput;
    float verticalInput;


    [Header("Animations")]
    [SerializeField] Sprite[] WalkAnimation;
    [SerializeField] Animator AnimatorComp;

    [Header("Mask")]
    [SerializeField] public GameObject Mask;
    GenericMask NowMask;


    [Header("NPC")]
    [SerializeField] GameObject NearNPC;
    [Header("Other")]
    [SerializeField] IntecartionArea AreInteractionScript;
    [SerializeField] GM gm;
    Animator Anim;
    public bool isInMinigame;
    GameObject NearNPCSearch;
    int MovingDirection;   // -1 = left   0 = stand  1 = right
    void Start()
    {
        // Get the Rigidbody2D component attached to the GameObject
        Anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        ThisSprite = GetComponent<SpriteRenderer>();
        AnimatorComp = GetComponent<Animator>();
    }

    void Update()
    {

        // Get input for movement
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        dSkin.UpdateSkin(CheckDirection());

        WalkAnimationFunc();
        //FlipChecker();
        // Calculate the movement direction
        UnityEngine.Vector2 movement = new Vector2(horizontalInput, verticalInput);

        // Set the velocity based on the movement direction and speed
        rb.velocity = movement * Speed;

        InputChecker();
        NearChecker();
    }
    void NearChecker ()
    {
        float Dis = 100;
        foreach (GameObject npc in AreInteractionScript.InteractNPC)
        {
            if (Vector2.Distance(gameObject.transform.position, npc.transform.position) < Dis && Vector2.Distance(gameObject.transform.position, npc.transform.position) < 10)
            {
                NearNPC = npc;
                Dis = Vector2.Distance(gameObject.transform.position, npc.transform.position);
            }
            else
                NearNPC = null;

        }

        foreach (GameObject npc in AreInteractionScript.InteractNPC)
            npc.GetComponent<NPC>().TurnOffPressE();
        if(NearNPC !=null)
        NearNPC.GetComponent<NPC>().TurnOnPressE();

    }

    public GameObject GetNearNPC ()
    {
        GameObject[] ALLNPC = GameObject.FindGameObjectsWithTag("NPC");
   
        float Dis = 1000;
        foreach(GameObject npc in ALLNPC)
        {
            if(Vector2.Distance(npc.transform.position,transform.position) < Dis)
            {
                NearNPCSearch = npc;
                Dis = Vector2.Distance(npc.transform.position, transform.position);
            }
        }

        return NearNPCSearch;
    }

    public void EndGameAct ()
    {
        StartCoroutine(EndGameFunc());
    }

    IEnumerator EndGameFunc()
    {
        gm.EndGame = true;
        GetNearNPC().transform.DOMove(transform.position, 0.7f);
        yield return new WaitForSeconds(0.7f);
        Debug.Log("EndGameScreen");
    }



    void InputChecker()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (AreInteractionScript.CanInteract)
                InteractWithNPC(AreInteractionScript.InteractNPC);
        }


    }

    int CheckDirection()
    {
        if (horizontalInput == 0)
        {
            if (verticalInput > 0)
            {
                return 1;
            }
            else return 0;
        }
        else
        {
            if (horizontalInput > 0)
            {
                return 3;
            }
            else return 2;
        }
    }

    public void ShitchMasks()
    {
        StartCoroutine(MaskSwichingBool());
        GameObject PlayerMask = Mask;
        GameObject NPCMask = NearNPC.GetComponent<NPC>().Mask;
        Mask = NPCMask;
        Mask.transform.SetParent(transform);
        NearNPC.GetComponent<NPC>().Mask = PlayerMask;
        NearNPC.GetComponent<NPC>().Mask.transform.SetParent(NearNPC.transform);

        Mask.transform.DOLocalMove(Vector2.zero, 0.4f);
        NearNPC.GetComponent<NPC>().Mask.transform.DOLocalMove(Vector2.zero, 0.4f);
    }

    IEnumerator MaskSwichingBool()
    {
        isInMinigame = true;
        yield return new WaitForSeconds(0.4f);
        isInMinigame = false;
    }

    void InteractWithNPC(List<GameObject> NPC)
    {

        float Dis = 100;
        foreach (GameObject npc in NPC)
        {
            if (Vector2.Distance(gameObject.transform.position, npc.transform.position) < Dis)
            {
                NearNPC = npc;
                Dis = Vector2.Distance(gameObject.transform.position, npc.transform.position);
            }

        }
        gm.NowNPC = NearNPC;

        NowMask = Mask.GetComponent<GenericMask>();
        if (gm.SearchingSurface)
        {

            if (gm.HintGM.goalSurface == NearNPC.GetComponent<NPC>().MaskGenerec.Surface)
            {
                StartComunicationWithNPC();
            }
            else
            {
                NearNPC.GetComponent<NPC>().TurnOffPressE();
            }

        }
        else if (gm.SearchingEyes)
        {

            if (gm.HintGM.goalSurface == NearNPC.GetComponent<NPC>().MaskGenerec.Surface && gm.HintGM.goalEyes == NearNPC.GetComponent<NPC>().MaskGenerec.Eyes)
            {
                StartComunicationWithNPC();
            }
            else
            {
                NearNPC.GetComponent<NPC>().TurnOffPressE();
            }

        }
        else if (gm.SearchingMouth)
        {

            if (gm.HintGM.goalSurface == NearNPC.GetComponent<NPC>().MaskGenerec.Surface && gm.HintGM.goalEyes == NearNPC.GetComponent<NPC>().MaskGenerec.Eyes
                && gm.HintGM.goalMouth == NearNPC.GetComponent<NPC>().MaskGenerec.Mouth)
            {
                StartComunicationWithNPC();
            }
            else
            {
                NearNPC.GetComponent<NPC>().TurnOffPressE();
            }

        }
        else if (gm.SearchingEars)
        {

            if (gm.HintGM.goalSurface == NearNPC.GetComponent<NPC>().MaskGenerec.Surface && gm.HintGM.goalEyes == NearNPC.GetComponent<NPC>().MaskGenerec.Eyes
                && gm.HintGM.goalMouth == NearNPC.GetComponent<NPC>().MaskGenerec.Mouth && gm.HintGM.goalEars == NearNPC.GetComponent<NPC>().MaskGenerec.Ears)
            {

                //    END GAME 

                Debug.Log("End Game");
            }
            else
            {
                NearNPC.GetComponent<NPC>().TurnOffPressE();
            }

        }
        else
        {
            StartComunicationWithNPC();
        }

    }

    void StartComunicationWithNPC()
    {
        NearNPC.GetComponent<Pathfinder>().CanMove = false;
        NearNPC.GetComponent<NPC>().TurnOnTextBubble();
        NearNPC.GetComponent<NPC>().TurnOffPressE();
        gm.StartConv();

        Anim.SetBool("Dialogue", true);
    }

    public void EndConv()
    {
        Anim.SetBool("Dialogue", false);
        Anim.SetBool("MiniGame", false);


    }

    public void StartMiniGame()
    {

        Anim.SetBool("MiniGame", true);
    }

    void FlipChecker()
    {
        if (horizontalInput > 0)
            ThisSprite.flipX = false;
        else if (horizontalInput < 0)
            ThisSprite.flipX = true;

    }

    void WalkAnimationFunc()
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
