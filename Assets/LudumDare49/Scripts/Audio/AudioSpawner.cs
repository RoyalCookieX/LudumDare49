using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public struct AudioEntry
{
    public string name;
    public AudioClip clip;
    public AudioMixerGroup mixerGroup;
}

public class AudioSpawner : MonoBehaviour
{
    [BoxGroup("Prefab"), SerializeField] private AudioSource _prefab;

    [BoxGroup("Properties"), SerializeField] private List<AudioEntry> _entries;

    public void SpawnAudio(string name)
    {
        AudioEntry entry = _entries.Find(e => e.name == name);
        if(entry.name == "") return;
        AudioSource instance = Instantiate(_prefab, transform.position, Quaternion.identity);
        instance.clip = entry.clip;
        instance.outputAudioMixerGroup = entry.mixerGroup;
    }
}
