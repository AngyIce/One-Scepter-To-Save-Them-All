using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusSpawner : MonoBehaviour
{
    private float nextSpawnTime;
    public GameObject virusPrefab;
    public static float spawnDelay = 8;

    private GameObject instantiatedObj;

    void Update()
    {
        if (ShouldSpawn())
        {
            Spawn();
            Debug.Log(spawnDelay);
        }
    }

    public void Spawn()
    {
        nextSpawnTime = Time.time + spawnDelay;
        instantiatedObj = Instantiate(virusPrefab, transform.position, transform.rotation);
        instantiatedObj.transform.parent = GameObject.Find("Earth").transform;
    }

    public bool ShouldSpawn()
    {
        return Time.time >= nextSpawnTime;
    }

}
