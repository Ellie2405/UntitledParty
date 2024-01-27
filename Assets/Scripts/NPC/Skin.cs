using UnityEngine;

[CreateAssetMenu(fileName = "NewSkin", menuName = "Custom/SkinData")]
public class SkinData : ScriptableObject
{
    public string name;
    public Sprite[] Sprites;
}