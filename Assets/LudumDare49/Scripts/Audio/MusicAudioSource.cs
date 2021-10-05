using System;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicAudioSource : MonoBehaviour
{
    private static int CurrentID { get; set; } = -1;
    
    [BoxGroup("Components"), SerializeField] private AudioSource _audioSource;

    [BoxGroup("Properties"), SerializeField] private AudioEntry[] _musicClips;

    private void Start()
    {
        if (CurrentID == -1)
        {
            CurrentID = GetInstanceID();
            DontDestroyOnLoad(gameObject);
        }
        else if (CurrentID != GetInstanceID())
        {
            Destroy(gameObject);
        }
    }

    private void OnEnable()
    {
        SceneManager.activeSceneChanged += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.activeSceneChanged -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene arg0, Scene arg1)
    {
        if(arg0.buildIndex == arg1.buildIndex) return;

        AudioEntry entry = _musicClips[arg1.buildIndex];
        _audioSource.Stop();
        _audioSource.clip = entry.RandomClip();
        _audioSource.outputAudioMixerGroup = entry.mixerGroup;
        _audioSource.Play();
    }

    private void OnDestroy()
    {
        if (CurrentID == GetInstanceID()) CurrentID = -1;
    }
}
