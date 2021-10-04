using System;
using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Audio;

public class AudioSlider : MonoBehaviour
{
    [BoxGroup("Properties"), SerializeField] private string _volumeName;
    [BoxGroup("Properties"), SerializeField] private AudioMixerGroup _mixerGroup;

    private void Start()
    {
        float value = PlayerPrefs.GetFloat(_volumeName);
        SetValue(value);
    }

    public void SetValue(float value01)
    {
        float newValue = Mathf.Log10(value01) * 20;
        _mixerGroup.audioMixer.SetFloat(_volumeName, newValue);
        SaveValue(value01);
    }
    
    public void SaveValue(float value01)
    {
        PlayerPrefs.SetFloat(_volumeName, value01);
    }
}
