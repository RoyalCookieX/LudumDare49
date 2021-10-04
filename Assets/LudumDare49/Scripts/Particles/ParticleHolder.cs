using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleHolder : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particles;

    private IEnumerator Start()
    {
       _particles.Play();
       yield return null;
       yield return new WaitUntil(() => !_particles.isPlaying);
       Destroy(gameObject);
    }
}
