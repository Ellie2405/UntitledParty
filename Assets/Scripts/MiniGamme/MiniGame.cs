using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class MiniGame : MonoBehaviour
{
    [SerializeField] Canvas MainCanvas;
    [SerializeField] GameObject MiniGameObj;
    [SerializeField] GameObject Rope;
    [SerializeField] GameObject NowRope;
    [SerializeField] Transform StartPointForRope;
    [SerializeField] int NumbOfLines;
    [SerializeField] List<GameObject> AllRope;

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
        GameObject NewRope = (GameObject)Instantiate(Rope, MainCanvas.gameObject.transform.position, Quaternion.identity);
        AllRope.Add(NewRope);
        NowRope = NewRope;
        NowRope.transform.SetParent(MainCanvas.gameObject.transform);
        NowRope.transform.position = StartPointForRope.position;

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
                GameObject NewRope = (GameObject)Instantiate(Rope, MainCanvas.gameObject.transform.position, Quaternion.identity);
                AllRope.Add(NewRope);
                NowRope = NewRope;
                NowRope.transform.SetParent(MainCanvas.gameObject.transform);
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
                    GameObject NewRope = (GameObject)Instantiate(Rope, MainCanvas.gameObject.transform.position, Quaternion.identity);
                    AllRope.Add(NewRope);
                    NowRope = NewRope;
                    NowRope.transform.SetParent(MainCanvas.gameObject.transform);
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

    }

 
}
