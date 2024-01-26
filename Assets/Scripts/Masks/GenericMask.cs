using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericMask : MonoBehaviour
{
    // Order is surface, ears, eyes, mouth (top to bottom)
    [SerializeField] List<SpriteRenderer> maskSpriteRenderers;

    private List<Sprite> maskSpritesFront;
    private List<Sprite> maskSpritesSide;

    private Vector3 normalScale = Vector3.one;
    private Vector3 flippedScale = new Vector3(-1, 1, 1);


    public string Surface { get { return maskSpritesFront[0].name.Split("_")[1]; } }
    public string Ears { get { return maskSpritesFront[1].name.Split("_")[1]; } }
    public string Eyes { get { return maskSpritesFront[2].name.Split("_")[1]; } }
    public string Mouth { get { return maskSpritesFront[3].name.Split("_")[1]; } }

    private void Start()
    {
        List<List<Sprite>> sprites = MasksDB.instance.GetRandomMask();
        maskSpritesFront = sprites[0];
        maskSpritesSide = sprites[1];
        SetFrontView();
    }

    public void UpdateView(int direction)
    {

        if(direction >= 2)
        {
            SetSideView();
            if (direction == 2) this.transform.localScale = normalScale;
            else this.transform.localScale = flippedScale;
        }
        else
        {
            if (direction == 1) this.transform.localScale = Vector3.zero;
            else SetFrontView();
        }
    }

    private void SetFrontView()
    {
        for(int i = 0; i < maskSpriteRenderers.Count; i++)
        {
            maskSpriteRenderers[i].sprite = maskSpritesFront[i];
        }
    }

    private void SetSideView()
    {
        for (int i = 0; i < maskSpriteRenderers.Count; i++)
        {
            maskSpriteRenderers[i].sprite = maskSpritesSide[i];
        }
    }
}
