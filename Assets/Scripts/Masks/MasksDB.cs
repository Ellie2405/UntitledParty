using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MasksDB : MonoBehaviour
{
    [Header("Surfaces")]
    [SerializeField] List<Sprite> surfacesFront;
    [SerializeField] List<Sprite> surfacesSide;

    [Header("Ears")]
    [SerializeField] List<Sprite> earsFront;
    [SerializeField] List<Sprite> earsSide;

    [Header("Eyes")]
    [SerializeField] List<Sprite> eyesFront;
    [SerializeField] List<Sprite> eyesSide;

    [Header("Mouths")]
    [SerializeField] List<Sprite> mouthsFront;
    [SerializeField] List<Sprite> mouthsSide;

    public static MasksDB instance;

    private List<int> masksPossibilities;

    private void Awake()
    {
        instance = this;
        masksPossibilities = Enumerable.Range(1, 256).OrderBy(x => Random.value).ToList();   
    }
    public List<List<Sprite>> GetRandomMask()
    {
        int maskCode = masksPossibilities[0];
        masksPossibilities.RemoveAt(0);
        List<Sprite> front = new List<Sprite>(); 
        List<Sprite> side = new List<Sprite>();
        front.Add(surfacesFront[maskCode % 4]);
        side.Add(surfacesSide[maskCode % 4]);
        maskCode /= 4;
        front.Add(earsFront[maskCode % 4]);
        side.Add(earsSide[maskCode % 4]);
        maskCode /= 4;
        front.Add(eyesFront[maskCode % 4]);
        side.Add(eyesSide[maskCode % 4]);
        maskCode /= 4;
        front.Add(mouthsFront[maskCode % 4]);
        side.Add(mouthsSide[maskCode % 4]);

        return new List<List<Sprite>> { front, side };
    }
}
