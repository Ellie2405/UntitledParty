using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    [SerializeField] GameObject TextPanel;
    [SerializeField] GameObject IconPanel;
    [SerializeField] Image IconImage;
    [SerializeField] Text Text;
    // Start is called before the first frame update
 
    public string TextQuestion;
    public string TextMask;
    public float typingSpeed = 0.1f;
    [SerializeField] Sprite QuestionIcon;
    [SerializeField] Sprite MaskIcon;

    private void Start()
    {

    }

    public void WriteQuestionTut ()
    {
        StartCoroutine(TypeText(TextQuestion, QuestionIcon));
    }

    public void WriteMaskTut()
    {
        StartCoroutine(TypeText(TextMask, MaskIcon));
    }

    IEnumerator TypeText(string text,Sprite Icon)
    {
        if(Icon == null)
        {
            IconPanel.SetActive(false);

        }
        else
        {
            IconPanel.SetActive(true);
            IconImage.sprite = Icon;
        }    


        foreach (char c in text)
        {
            Text.text += c;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
}
