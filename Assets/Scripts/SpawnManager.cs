using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public Transform[] spawnLocations;//which location under spawner that it spawns
    //public GameObject[] whatToSpawnPrefab;//spawns the specified customer prefab
    //public GameObject[] whatToClone;


    [SerializeField] GameObject poacher;
    [SerializeField] int numberOfPoacherToSpawn;

    void Start()
    {
        for (int i = 0; i < numberOfPoacherToSpawn; i++)
        {
            Instantiate(poacher, spawnLocations[Random.Range(0, spawnLocations.Length)].transform.position, transform.rotation);
        }


        // Replaced idk why do we need to that
        //whatToClone[0] = Instantiate(whatToSpawnPrefab[0], spawnLocations[0].transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;//usedPrefab, spawned position, rotation             
        //whatToClone[0] = Instantiate(whatToSpawnPrefab[0], spawnLocations[1].transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;//usedPrefab, spawned position, rotation             
        //whatToClone[0] = Instantiate(whatToSpawnPrefab[0], spawnLocations[2].transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;//usedPrefab, spawned position, rotation             
    }
}
    
