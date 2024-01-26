using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAlot : MonoBehaviour
{
    [SerializeField] GameObject NPC;
    [SerializeField] int count;
    void Start()
    {
        for(int i = 0; i < count; i++)
        {
            Instantiate(NPC, Random.insideUnitCircle * 30, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
