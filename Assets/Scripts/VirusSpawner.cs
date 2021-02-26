using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusSpawner : MonoBehaviour
{
    private float nextSpawnTime;

    [SerializeField]
    public GameObject virusPrefab;

    [SerializeField]
    public float spawnDelay = 10;

    private GameObject instantiatedObj;

    void Update()
    {
        if (ShouldSpawn())
        {
            Spawn();
        }
    }

    private void Spawn()
    {
        nextSpawnTime = Time.time + spawnDelay;
        instantiatedObj = GameObject.Instantiate(virusPrefab, transform.position, transform.rotation);
        instantiatedObj.transform.parent = GameObject.Find("Earth").transform;
    }

    private bool ShouldSpawn()
    {
        return Time.time >= nextSpawnTime;
    }

}
