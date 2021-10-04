using System;
using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioHolder : MonoBehaviour
{
    [BoxGroup("Components"), SerializeField] private AudioSource _audioSource;

    private Coroutine _current;
    private string _sceneName;
    
    private void OnEnable()
    {
        _sceneName = SceneManager.GetActiveScene().name;
        
        _current = StartCoroutine(Audioroutine());
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;

    }

    private IEnumerator Audioroutine()
    {
        DontDestroyOnLoad(gameObject);
        yield return new WaitUntil(() => _audioSource.clip != null);
        _audioSource.Play();
        yield return null;
        yield return new WaitUntil(() => !_audioSource.isPlaying);
        Destroy(gameObject);
        _current = null;
    }
    
    private void OnSceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        if (arg0.name == _sceneName || arg0.name == null) return;
        
        if(_current != null) StopCoroutine(_current);
        Destroy(gameObject);
    }
}
