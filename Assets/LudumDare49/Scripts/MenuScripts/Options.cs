using System;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public struct VolumeSliderEntry
{
    public string volumeName;
    public Slider slider;
    public AudioMixerGroup mixerGroup;
}

public class Options : MonoBehaviour
{
    private readonly string KEY_FULLSCREEN = "Fullscreen";
    
    [BoxGroup("Components"), SerializeField] private List<VolumeSliderEntry> _volumeSliders;
    [BoxGroup("Components"), SerializeField] private Toggle _fullscreenToggle;

    private void Start()
    {
        foreach (VolumeSliderEntry entry in _volumeSliders)
        {
            UpdateSlider(entry);
        }
        UpdateFullscreenToggle();
    }
    
    public void SetVolume(string volumeName, float value)
    {
        VolumeSliderEntry volumeSlider = _volumeSliders.Find(x => x.volumeName == volumeName);
        if(volumeSlider.volumeName == "") return;

        float newValue = Mathf.Log10(value) * 20;
        volumeSlider.mixerGroup.audioMixer.SetFloat(volumeName, newValue);
        PlayerPrefs.SetFloat(volumeName, value);
        volumeSlider.slider.value = value; 
    }
    
    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
        PlayerPrefs.SetInt(KEY_FULLSCREEN, isFullscreen ? 1 : 0);
    }

    private void UpdateSlider(VolumeSliderEntry entry)
    {
        float value = PlayerPrefs.GetFloat(entry.volumeName, 0.5f);
        entry.slider.value = value;
    }

    private void UpdateFullscreenToggle()
    {
        int value = PlayerPrefs.GetInt(KEY_FULLSCREEN);
        _fullscreenToggle.isOn = value == 1;
    }
}
