using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HintManager : MonoBehaviour
{
    [SerializeField] GM gm;
    public List<string> HintsText;
    public int NowHintNumber;
    int NumberOfObjec;

    public string GoalSurface;
    public string GoalEar;
    public string GoalMonth;
    public string GoalEye;
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
        if (NowHintNumber != HintsText.Count)
            NowHintNumber++;
        return HintsText[NowHintNumber];
     
    }
    public string GetObjectation()
    {
        if (NumberOfObjec == 0)
        {
            NumberOfObjec = 1;
            gm.SearchingSurface = true;
            return GoalSurface;
      
        }
        else if (NumberOfObjec == 1)
        {
            NumberOfObjec = 2;
            gm.SearchingEyes = true;
            return GoalEye;
         
        }
        else if (NumberOfObjec == 2)
        {
            NumberOfObjec = 4;
            gm.SearchingMouth = true;
            return GoalMonth;
  
        }
        else
        {
            NumberOfObjec = 5;
            gm.SearchingEars = true;
            return GoalEar;
          
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
