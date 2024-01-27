using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HintManager : MonoBehaviour
{
    [SerializeField] GM gm;

    public Image goalSurfaceImage;
    public Image goalEarsImage;
    public Image goalEyesImage;
    public Image goalMouthImage;

    public List<string> hintTextList;
    public int currentHintIndex = 0;

    public string goalSurface;
    public string goalEars;
    public string goalMouth;
    public string goalEyes;



    // Start is called before the first frame update
    void Start()
    {
        goalSurfaceImage.enabled = false;
        goalEarsImage.enabled = false;
        goalEyesImage.enabled = false;
        goalMouthImage.enabled = false;
    }

    public void SetGoal (GenericMask mask)
    {
        goalSurface = mask.SurfaceName;
        goalEars = mask.EarsName;
        goalMouth = mask.MouthName;
        goalEyes = mask.EyesName;
        Debug.Log(mask.maskSpriteRenderers.Count);
        Debug.Log(mask.maskSpriteRenderers[0].sprite);
        goalSurfaceImage.sprite = mask.maskSpriteRenderers[0].sprite;
        /*goalEarsImage.sprite = mask.maskSpriteRenderers[1].sprite;
        goalEyesImage.sprite = mask.maskSpriteRenderers[2].sprite;
        goalMouthImage.sprite = mask.maskSpriteRenderers[3].sprite;*/
    }

    
    public string GetString ()
    {
        string result = hintTextList[currentHintIndex];
        UpdateUI();
        if(currentHintIndex != hintTextList.Count)
        currentHintIndex++;
        return result;
    }
    public void UpdateUI()
    {
        switch (currentHintIndex)
        {
            case 0:
                goalSurfaceImage.enabled = true;
                break;
            case 1:
                goalEarsImage.enabled = true;
                break;
            case 2:
                goalEyesImage.enabled = true;
                break;
            case 3:
                goalMouthImage.enabled = true;
                break;
        }
    }
    public string GetObjectation()
    {
        
        switch(currentHintIndex)
        {
            case 0:
                gm.SearchingSurface = true;
                return goalSurface;
            case 1:
                gm.SearchingEars = true;
                return goalEars;
            case 2:
                gm.SearchingEyes = true;
                return goalEyes;
            case 3:
                gm.SearchingMouth = true;
                return goalMouth;
        }
        return "";
        
        /*if (NumberOfObjec == 0)
        {
            return goalSurface;
            NumberOfObjec = 1;
            gm.SearchingSurface = true;
        }
        else if (NumberOfObjec == 1)
        {
            return goalEyes;
            NumberOfObjec = 2;
            gm.SearchingEyes = true;
        }
        else if (NumberOfObjec == 3)
        {
            return goalMouth;
            NumberOfObjec = 4;
            gm.SearchingMouth = true;
        }
        else
        {
            return goalEars;
            NumberOfObjec = 5;
            gm.SearchingEars = true;
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
