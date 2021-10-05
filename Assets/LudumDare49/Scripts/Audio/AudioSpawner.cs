using System;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Audio;

public class AudioSpawner : MonoBehaviour
{
    [BoxGroup("Prefab"), SerializeField] private AudioSource _prefab;

    [BoxGroup("Properties"), SerializeField] private List<AudioEntry> _entries;
    [BoxGroup("Properties"), SerializeField] private bool _spawnOnStart;
    [BoxGroup("Properties"), SerializeField] private string _defaultClip;

    private void Start()
    {
        if(_spawnOnStart) SpawnAudio(_defaultClip);
    }

    public void SpawnAudio(string name)
    {
        AudioEntry entry = _entries.Find(e => e.name == name);
        if(entry.name == "") return;
        
        AudioSource instance = Instantiate(_prefab, transform.position, Quaternion.identity);
        instance.clip = entry.RandomClip();
        instance.outputAudioMixerGroup = entry.mixerGroup;
    }
}
