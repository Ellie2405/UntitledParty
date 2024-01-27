using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAlot : MonoBehaviour
{
    [SerializeField] GameObject NPC;
    [SerializeField] int count;
    [SerializeField] float spawnRadius;
    [SerializeField] List<Transform> spawnPoints;
    void Start()
    {
        int NPCsPerSpawn = count / spawnPoints.Count;
        NPCsPerSpawn += Random.Range(-1, 1) * 5; // surprise

        foreach(Transform spawnPoint in spawnPoints)
        {
            SpawnAround(spawnPoint, NPCsPerSpawn);
        }
    }

    void SpawnAround(Transform point, int count)
    {
        for(int i = 0; i < count; i++)
        {
            Instantiate(NPC, point.position + Random.insideUnitSphere * spawnRadius, Quaternion.identity);
        }
    }
}
