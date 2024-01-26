using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class MiniGame : MonoBehaviour
{
    [SerializeField] Transform Parent;
    [SerializeField] GameObject MiniGameObj;
    [SerializeField] GameObject Rope;
    [SerializeField] GameObject NowRope;
    [SerializeField] Transform StartPointForRope;
    [SerializeField] int NumbOfLines;
    [SerializeField] List<GameObject> AllRope;

    [SerializeField] GM gm;

    int LastSideTaped = 0;
    int NumDone;
    int nowLine;
    // Start is called before the first frame update
    void Start()
    {
        //StartMiniGame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartMiniGame()
    {
        MiniGameObj.SetActive(true);
        GameObject NewRope = (GameObject)Instantiate(Rope, Parent.position, Quaternion.identity);
        AllRope.Add(NewRope);
        NowRope = NewRope;
        NowRope.transform.SetParent(Parent);
        NowRope.transform.position = StartPointForRope.position;
        Debug.Log("StartGame");
    }

    public void ClickedPoint (GameObject Point, int LastSide)
    {
        if (LastSideTaped != LastSide)
        {
            nowLine++;
            if (nowLine != NumbOfLines)
            {
                LastSideTaped = LastSide;
                NowRope.GetComponent<Rope>().enabled = false;
                GameObject NewRope = (GameObject)Instantiate(Rope, Parent.position, Quaternion.identity);
                AllRope.Add(NewRope);
                NowRope = NewRope;
                NowRope.transform.SetParent(Parent);
                NowRope.transform.position = Point.transform.position;
            }
            else
            {
                nowLine = 0;
                NumDone++;
                if (NumDone != 2)
                {
                    LastSideTaped = LastSide;

                    NowRope.GetComponent<Rope>().enabled = false;
                    GameObject NewRope = (GameObject)Instantiate(Rope, Parent.position, Quaternion.identity);
                    AllRope.Add(NewRope);
                    NowRope = NewRope;
                    NowRope.transform.SetParent(Parent);
                    NowRope.transform.position = StartPointForRope.position;
                }
                else
                {
                    EndMiniGame();
                }

            }
        }
    }
    void EndMiniGame ()
    {
        NumDone = 0;
        LastSideTaped = 0;
        foreach(GameObject ropes in AllRope)
        {
            Destroy(ropes);
        }
        AllRope.Clear();
        MiniGameObj.SetActive(false);

        gm.LeaveConvWithNPC();
    }

 
}
