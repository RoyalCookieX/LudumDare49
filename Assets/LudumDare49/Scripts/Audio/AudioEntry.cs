using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public struct AudioEntry
{
    public string name;
    public AudioClip[] clips;
    public AudioMixerGroup mixerGroup;

    public AudioClip RandomClip() => clips[Random.Range(0, clips.Length)];
}