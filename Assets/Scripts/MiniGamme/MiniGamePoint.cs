using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MiniGamePoint : MonoBehaviour, IPointerEnterHandler
{
    [SerializeField] MiniGame MiniGameScript;
    [SerializeField] bool LastPoint;
    bool Used;
    public int Side;    // -1 = left    1 = right
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseOver()
    {
 
        // else
    }

    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        if (!Used)
        {
            StartCoroutine(Over());
        }
    }

    IEnumerator Over() {
        yield return new WaitForSeconds(0.05f);
        MiniGameScript.ClickedPoint(gameObject, Side);
        Used = true;

    }

    public void Press()
    {
       // if(!LastPoint)
        
         //   MiniGameScript.StartNewRope(Side);
    }
}
