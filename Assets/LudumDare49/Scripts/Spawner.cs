using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    public List<GameObject> _spawnObjects;
    public AnimationCurve _spawnCurve;
    public float _spawnRadius;
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
                Vector3 spawnDir = Random.insideUnitCircle.normalized;
                float t = _spawnCurve.Evaluate(Random.Range(0f, 1f));
                float distanceFromOrigin = Mathf.Lerp(0f, _spawnRadius, t);
                Vector3 spawnPos = transform.position + spawnDir * distanceFromOrigin;
                GameObject spawnObject = _spawnObjects[Random.Range(0, _spawnObjects.Count)];
                Instantiate(spawnObject, spawnPos, Quaternion.identity);
            }
            yield return new WaitForSeconds(Random.Range(minTime, maxTime));
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, _spawnRadius);
    }
}