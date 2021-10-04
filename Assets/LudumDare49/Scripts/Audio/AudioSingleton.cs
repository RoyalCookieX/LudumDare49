using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioSingleton : MonoBehaviour
{
    public string audioName;

    private string _sceneName;

    private void OnEnable()
    {
        _sceneName = SceneManager.GetActiveScene().name;
        
        List<AudioSingleton> audioSingletons = new List<AudioSingleton>(FindObjectsOfType<AudioSingleton>());
        if(audioSingletons.Exists(x => x.audioName == audioName && x.GetInstanceID() != GetInstanceID())) Destroy(gameObject);
        
        DontDestroyOnLoad(gameObject);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        if(gameObject == null) return;
        if(arg0.name != _sceneName && arg0.name != null) Destroy(gameObject);
    }
}
