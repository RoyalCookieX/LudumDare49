using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Koda : MonoBehaviour
{
    public List<GameObject> _spawnPoints;
    public List<GameObject> _spawnObjects;

    public GameObject spawner;
    public bool stopSpawn = false;
    public float spawnTime;

    void Start()
    {
        StartCoroutine(SpawnObject());
    }
    public IEnumerator SpawnObject()
    {

        GameObject spawnPoint = _spawnPoints[Random.Range(0, _spawnPoints.Count)];
        GameObject spawnObject = _spawnObjects[Random.Range(0, _spawnObjects.Count)];
        Instantiate(spawnObject, spawnPoint.transform.position, spawnPoint.transform.rotation);

        yield return new WaitForSeconds(spawnTime);
        if (stopSpawn)
        {
            //Stop spawning
        }
        else
        {
            StartCoroutine(SpawnObject());
        }
    }
}
