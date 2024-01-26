using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GM : MonoBehaviour
{
    [SerializeField] public MiniGame MiniGameManager;

    [Header("NPC")]
    public GameObject NowNPC;

    [Header("UI")]
    [SerializeField] GameObject ButtonLeftText; 
    [SerializeField] GameObject ButtonRightText; 
    [SerializeField] GameObject ButtonMiddleText;


    [Header("Hints")]
    bool HintState;
    [SerializeField] HintManager HintGM;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartConv ()
    {
        ButtonLeftText.SetActive(true);
        ButtonRightText.SetActive(true);
        ButtonMiddleText.SetActive(true);
    }

    public void EndConv()
    {
        ButtonLeftText.SetActive(false);
        ButtonRightText.SetActive(false);
        ButtonMiddleText.SetActive(false);
    }

    public void StartMiniGame ()
    {
        MiniGameManager.StartMiniGame();
        EndConv();
    }

    public void LeaveConvWithNPC()
    {
  
            NowNPC.GetComponent<NPC>().TurnOffTextBubble();
            ButtonLeftText.SetActive(false);
            ButtonMiddleText.SetActive(false);
            ButtonRightText.SetActive(false);
     
    }

    public void AskHint()
    {
        HintState = true;
        NowNPC.GetComponent<NPC>().WriteHint(HintGM.GetString());
    
        ButtonMiddleText.SetActive(false);
        ButtonRightText.SetActive(false);
    }
}
