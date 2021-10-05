using System;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicAudioSource : MonoBehaviour
{
    private static int CurrentID { get; set; } = -1;
    
    [BoxGroup("Components"), SerializeField] private AudioSource _audioSource;

    [BoxGroup("Properties"), SerializeField] private AudioEntry[] _musicClips;

    private string _currentSceneName;

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
        SceneManager.activeSceneChanged += OnSceneChanged;
    }

    private void OnDisable()
    {
        SceneManager.activeSceneChanged -= OnSceneChanged;
    }

    private void OnSceneChanged(Scene arg0, Scene arg1)
    {
        if(arg1.name == _currentSceneName) return;
        _currentSceneName = arg1.name;

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
