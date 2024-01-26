using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BitSplash.AI.GPT;

public class NPC : MonoBehaviour
{
    [SerializeField] GameObject TextBubble;
    [SerializeField] Text TextBubbleText;
    [SerializeField] string Response;
    [SerializeField] Pathfinder Path;
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
        StartCoroutine(TurnOnTextBubbleAct());

        
    }


    IEnumerator TurnOnTextBubbleAct ()
    {
        TextBubble.gameObject.SetActive(true);
        yield return new WaitForSeconds(2);
        TurnOffTextBubble();
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
