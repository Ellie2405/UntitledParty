using Assets.Scripts;
using UnityEngine;

public class DynamicSkin : MonoBehaviour
{
    public SkinData skins;
    [SerializeField] int bpm = 130;
    private SpriteRenderer spriteRenderer;
    static private float beat;
    private float counter;
    private int danceIndex;
    [SerializeField] private bool isDancing;


    void Start()
    {
        skins = SkinManager.Instance.GetRandomSkin();

        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer == null)
        {
            spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
        }
        spriteRenderer.sprite = skins.Sprites[1];

        if (beat == 0)
        {
            beat = 60f / bpm;
            print(beat);
        }
    }

    private void Update()
    {
        if (isDancing)
        {
            counter += Time.deltaTime;
            if (counter > beat)
            {
                counter -= beat;
                spriteRenderer.sprite = skins.DanceSprites[danceIndex %= skins.DanceSprites.Length];
                danceIndex++;
            }
        }
    }

    public void UpdateSkin(int i)
    {
        spriteRenderer.sprite = skins.Sprites[i];
    }

    public void Dance()
    {
        isDancing = !isDancing;
        print("dancing" + isDancing);
    }

}
