using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericMask : MonoBehaviour
{
    [SerializeField] Sprite surface;
    [SerializeField] Sprite ears;
    [SerializeField] Sprite eyes;
    [SerializeField] Sprite mouth;

    public string Surface { get { return surface.name.Split("_")[1]; } }
    public string Ears { get { return ears.name.Split("_")[1]; } }
    public string Eyes { get { return eyes.name.Split("_")[1]; } }
    public string Mouth { get { return mouth.name.Split("_")[1]; } }
}
