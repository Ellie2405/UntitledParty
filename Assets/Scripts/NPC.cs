using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BitSplash.AI.GPT;

public class NPC : MonoBehaviour
{
    [SerializeField] GameObject TextBubble;
    [SerializeField] public Text TextBubbleText;
    [SerializeField] public Text TextBubbleHint1Text;
    [SerializeField] public Text TextBubbleHint2Text;
    [SerializeField] string Response;
    [SerializeField] Pathfinder Path;
    [SerializeField] GM gm;
    [SerializeField] public GameObject Mask;
    // Start is called before the first frame update
    void Start()
    {

        GenText();
    }

    void GenText()
    {
        var Convo = ChatGPTConversation.Start(this);
        Convo.Say("You are a Game NPC that are in party. i need from you to input me a small text that you gonna say to a user that starting to talk with you, something random and funny. its need to be maximum 2 lines. its need to be clean text becouse i gonna input your response directly to the game");

    }

    public void TurnOnTextBubble ()
    {
        TextBubbleText.gameObject.SetActive(true);
        TextBubbleHint1Text.gameObject.SetActive(false);
        TextBubbleHint2Text.gameObject.SetActive(false);
        TextBubble.gameObject.SetActive(true);

    }

    public void WriteHint (string hint)
    {
        TextBubbleText.gameObject.SetActive(false);
        TextBubbleHint1Text.gameObject.SetActive(true);
        TextBubbleHint2Text.gameObject.SetActive(true);
        TextBubbleHint1Text.text = hint;

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
}
