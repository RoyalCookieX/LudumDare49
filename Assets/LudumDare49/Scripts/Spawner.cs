using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    public List<GameObject> _spawnObjects;
    public bool stopSpawn;
    public Transform _spawnTarget;
    public float _spawnDistanceFromPlayer;

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
            if(_spawnTarget == null) yield break;
            if (!stopSpawn)
            {
                Vector3 spawnDir = Random.insideUnitCircle.normalized;
                Vector3 spawnPos = _spawnTarget.position + spawnDir * _spawnDistanceFromPlayer;
                GameObject spawnObject = _spawnObjects[Random.Range(0, _spawnObjects.Count)];
                Instantiate(spawnObject, spawnPos, Quaternion.identity);
            }
            yield return new WaitForSeconds(Random.Range(minTime, maxTime));
        }
    }

    private void OnDrawGizmos()
    {
        if(_spawnTarget == null) return;
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(_spawnTarget.position, _spawnDistanceFromPlayer);
    }
}