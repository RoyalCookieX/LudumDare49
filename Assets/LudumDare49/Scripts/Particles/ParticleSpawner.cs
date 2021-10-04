using System;
using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

public class ParticleSpawner : MonoBehaviour
{
    [BoxGroup("Prefab"), SerializeField] private GameObject _prefab;

    [BoxGroup("Properties"), SerializeField] private bool _callOnEnable;
    [BoxGroup("Properties"), SerializeField] private bool _callOnCollision;

    private void OnEnable()
    {
        if(_callOnEnable) SpawnParticles();
    }
    
    private void OnCollisionEnter(Collision other)
    {
        if(_callOnCollision) SpawnParticles();
    }

    public void SpawnParticles()
    {
        Instantiate(_prefab, transform.position, Quaternion.identity);
    }
}
