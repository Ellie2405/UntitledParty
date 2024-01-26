using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintManager : MonoBehaviour
{
    public List<string> HintsText;
    public int NowHintNumber;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public string GetString ()
    {
        return HintsText[NowHintNumber];
        if(NowHintNumber != HintsText.Count)
        NowHintNumber++;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
