using Assets.Scripts;
using UnityEngine;

public class DynamicSkin : MonoBehaviour
{
    public SkinData skins;
    private SpriteRenderer spriteRenderer;
    public bool useRandomSkin = true;

    void Start()
    {
        if (useRandomSkin)
            skins = SkinManager.Instance.GetRandomSkin();

        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer == null)
        {
            spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
        }
        spriteRenderer.sprite = skins.Sprites[1];
    }

    public void UpdateSkin(int i)
    {
        spriteRenderer.sprite = skins.Sprites[i];
    }

}
