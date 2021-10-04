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
    [BoxGroup("Properties"), SerializeField] private List<VolumeSliderEntry> _volumeSliders;

    private void Start()
    {
        foreach (VolumeSliderEntry entry in _volumeSliders)
        {
            UpdateSlider(entry);
        }
    }
    
    public void SetVolume(string volumeName, float value)
    {
        VolumeSliderEntry volumeSlider = _volumeSliders.Find(x => x.volumeName == volumeName);
        if(volumeSlider.volumeName == "") return;

        float newValue = Mathf.Log10(value) * 20;
        volumeSlider.mixerGroup.audioMixer.SetFloat(volumeName, newValue);
        volumeSlider.slider.value = value;
    }
    
    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    private void UpdateSlider(VolumeSliderEntry entry)
    {
        float value = PlayerPrefs.GetFloat(entry.volumeName, 0.5f);
        entry.slider.value = value;
    }
}
