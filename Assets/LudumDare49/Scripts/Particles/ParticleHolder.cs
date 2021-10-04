using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleHolder : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particles;
    [SerializeField] private float _maxDuration = 5f;

    private IEnumerator Start()
    {
        _particles.Play();
        yield return null;
        yield return new WaitForSeconds(_maxDuration);
        Destroy(gameObject);
    }
}
