using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BitSplash.AI.GPT;

public class NPC : MonoBehaviour
{
    [SerializeField] GameObject PressE;
    [SerializeField] GameObject TextBubble;
    [SerializeField] public Text TextBubbleText;
    [SerializeField] public Text TextBubbleHint1Text;
    [SerializeField] public Text TextBubbleHint2Text;
    [SerializeField] string Response;
    [SerializeField] Pathfinder Path;
    [SerializeField] GM gm;
    [SerializeField] public GameObject Mask;
    [SerializeField] public  GenericMask MaskGenerec;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GM>();
        GenText();
    }

    void GenText()
    {
        var Convo = ChatGPTConversation.Start(this);
        Convo.Say("You are a Game NPC that are in party. i need from you to input me a small text that you gonna say to a user that starting to talk with you, something random and funny. its need to be maximum 2 lines. its need to be clean text becouse i gonna input your response directly to the game");

    }

    public void TurnOnPressE ()
    {
        PressE.SetActive(true);
        StartCoroutine(TimerForOffE());
    }

    IEnumerator TimerForOffE()
    {
        yield return new WaitForSeconds(2);
       
        TurnOffPressE();
    }

    public void TurnOffPressE()
    {
        PressE.SetActive(false);

    }

    public void TurnOnTextBubble ()
    {
        TextBubbleText.gameObject.SetActive(true);
        TextBubbleHint1Text.gameObject.SetActive(false);
        TextBubbleHint2Text.gameObject.SetActive(false);
        TextBubble.gameObject.SetActive(true);

    }

    public void WriteHint (string hint,string objectation)
    {
        TextBubbleText.gameObject.SetActive(false);
        TextBubbleHint1Text.gameObject.SetActive(true);
        TextBubbleHint2Text.gameObject.SetActive(true);
        TextBubbleHint1Text.text = hint;
        TextBubbleHint2Text.text = objectation;

    }


    public void TurnOffTextBubble()
    {
        TextBubble.gameObject.SetActive(false);
        GenText();
        Path.CanMove = true;
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    void OnConversationResponse (string text)
    {
        Response = text;
        TextBubbleText.text = Response;
    }

    public void StartMiniGame ()
    {
        gm.StartMiniGame();
    }


    public void LeavConv()
    {
        gm.LeaveConvWithNPC();
    }


    public void AskHint ()
    {
        gm.AskHint();
    }
}
