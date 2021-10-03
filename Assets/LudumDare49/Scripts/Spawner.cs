using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    public List<GameObject> _spawnObjects;
    public float spawnRadius;
    public GameObject player;
    public bool stopSpawn = false;

    public float minTime = 1;
    public float maxTime = 10;

    void Start()
    {
        StartCoroutine(SpawnObject());
    }
    
    private IEnumerator SpawnObject()
    {
        yield return null;
        while (true)
        {
            if (!stopSpawn)
            {
                Vector3 spawnPos = transform.position + (Vector3)Random.insideUnitCircle * spawnRadius;
                GameObject spawnObject = _spawnObjects[Random.Range(0, _spawnObjects.Count)];
                Instantiate(spawnObject, spawnPos, Quaternion.identity);
            }
            yield return new WaitForSeconds(Random.Range(minTime, maxTime));
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, spawnRadius);
    }
}