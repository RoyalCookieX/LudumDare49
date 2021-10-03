using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<GameObject> _spawnObjects;
    public GameObject player;
    public bool stopSpawn = false;

    public float minTime = 1;
    public float maxTime = 10;
    public int range = 10;

    void Start()
    {
        StartCoroutine(SpawnObject());
    }
    public IEnumerator SpawnObject()
    {
        float spawnTime;

        spawnTime = Random.Range(minTime, maxTime);
        GameObject spawnObject = _spawnObjects[Random.Range(0, _spawnObjects.Count)];
        

        if ((player.transform.position - this.transform.position).sqrMagnitude < range * range)
        {
            stopSpawn = true;
        }
        else
        {
            stopSpawn = false;
        }

        yield return new WaitForSeconds(spawnTime);
        if (stopSpawn)
        {
            //Stop spawning
        }
        else
        {
            Instantiate(spawnObject, this.transform.position, this.transform.rotation);
        }
        StartCoroutine(SpawnObject());
    }
}