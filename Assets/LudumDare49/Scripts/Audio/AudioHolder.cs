using System;
using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

public class AudioHolder : MonoBehaviour
{
    [BoxGroup("Components"), SerializeField] private AudioSource _audioSource;

    private IEnumerator Start()
    {
        DontDestroyOnLoad(gameObject);
        yield return new WaitUntil(() => _audioSource.clip != null);
        _audioSource.Play();
        yield return null;
        yield return new WaitUntil(() => !_audioSource.isPlaying);
        Destroy(gameObject);
    }
}
