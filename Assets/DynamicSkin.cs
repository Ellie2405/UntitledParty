using Assets.Scripts;
using UnityEngine;

public class DynamicSkin : MonoBehaviour
{
    public SkinData skins; 
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        skins = SkinManager.Instance.GetRandomSkin();

        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer == null)
        {
            spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
        }
        spriteRenderer.sprite = skins.downSprites;
    }

    public void UpdateSkin(float x, float y)
    {
        if (x>y)
        {
            if (x > 0)
            {
                spriteRenderer.sprite = skins.rightSprites;
            }
            else
            {
                spriteRenderer.sprite = skins.leftSprites;
            }
        }
        else
        {
            if (y > 0)
            {
                spriteRenderer.sprite = skins.upSprites;
            }
            else
            {
                spriteRenderer.sprite = skins.downSprites;
            }
        }
    }

}
