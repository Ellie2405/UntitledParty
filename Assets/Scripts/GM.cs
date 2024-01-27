using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GM : MonoBehaviour
{
    [SerializeField] public MiniGame MiniGameManager;

    [Header("NPC")]
    [SerializeField] Player PlayerObj;
    [SerializeField] public GameObject targetNPC;
    public GameObject NowNPC;

    [Header("UI")]
    [SerializeField] GameObject ButtonLeftText; 
    [SerializeField] GameObject ButtonRightText; 
    [SerializeField] GameObject ButtonMiddleText;


    [Header("Hints")]
   public bool HintState;
    [SerializeField] public  HintManager HintGM;

    [Header("Searching")]
    public bool SearchingSurface;
    public bool SearchingEars;
    public bool SearchingMouth;
    public bool SearchingEyes;
    public bool EndGame;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SetRandomTargetWait());
    }

    IEnumerator SetRandomTargetWait ()
    {
        yield return new WaitForSeconds(0.1f);
        SetRandomTarget();
    }
    void SetRandomTarget ()
    {
        GameObject[] allNPCs = GameObject.FindGameObjectsWithTag("NPC");
        int i = Random.Range(0, allNPCs.Length - 1);
        Debug.Log("Name: " +  allNPCs[i].name);

        targetNPC = allNPCs[i];
        GenericMask mask = allNPCs[i].GetComponent<NPC>().MaskGenerec;
        HintGM.SetGoal(mask);
        
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
        PlayerObj.EndConv();
        ButtonLeftText.SetActive(false);
        ButtonRightText.SetActive(false);
        ButtonMiddleText.SetActive(false);
    }

    public void StartMiniGame ()
    {
             ButtonLeftText.SetActive(false);
        ButtonRightText.SetActive(false);
        ButtonMiddleText.SetActive(false);
        PlayerObj.StartMiniGame();
        MiniGameManager.StartMiniGame();

    }

    public void LeaveConvWithNPC()
    {
        PlayerObj.EndConv();
        NowNPC.GetComponent<NPC>().TurnOffTextBubble();
            ButtonLeftText.SetActive(false);
            ButtonMiddleText.SetActive(false);
            ButtonRightText.SetActive(false);
     
    }

    public void AskHint()
    {
        HintState = true;
        NowNPC.GetComponent<NPC>().WriteHint(HintGM.GetString(), HintGM.GetObjectation());
    
        ButtonMiddleText.SetActive(false);
        ButtonRightText.SetActive(false);
    }
}
