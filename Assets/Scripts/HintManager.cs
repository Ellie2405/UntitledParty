using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HintManager : MonoBehaviour
{
    public List<string> HintsText;
    public int NowHintNumber;
    int NumberOfObjec;

    string GoalSurface;
    string GoalEar;
    string GoalMonth;
    string GoalEye;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void GetGoal (string Surface, string Ear,string Month, string Eye)
    {
        GoalSurface = Surface;
        GoalEar = Ear;
        GoalMonth = Month;
        GoalEye = Eye;

    }


    public string GetString ()
    {
        return HintsText[NowHintNumber];
        if(NowHintNumber != HintsText.Count)
        NowHintNumber++;
    }
    public string GetObjectation()
    {
        if (NumberOfObjec == 0)
        {
            return GoalSurface;
            NumberOfObjec = 1;
        }
        else if (NumberOfObjec == 1)
        {
            return GoalEye;
            NumberOfObjec = 2;
        }
        else if (NumberOfObjec == 3)
        {
            return GoalMonth;
            NumberOfObjec = 4;
        }
        else
        {
            return GoalEar;
            NumberOfObjec = 2;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
