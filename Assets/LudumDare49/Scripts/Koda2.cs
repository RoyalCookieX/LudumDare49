using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Koda2 : MonoBehaviour
{
    public List<GameObject> _spawnObjects;

    public bool stopSpawn = false;
    public float spawnTime;
    public GameObject player;

    void Start()
    {
        StartCoroutine(SpawnObject());
    }
    public IEnumerator SpawnObject()
    {
        //player = GameObject.Find("Player");

        spawnTime = Random.Range(1, 10);
        GameObject spawnObject = _spawnObjects[Random.Range(0, _spawnObjects.Count)];
        

        if ((player.transform.position - this.transform.position).sqrMagnitude < 10 * 10)
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