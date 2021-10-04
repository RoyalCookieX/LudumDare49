using System;
using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHUD : MonoBehaviour
{
    [BoxGroup("Components"), SerializeField] private GameObject[] _panels;

    [BoxGroup("Properties"), SerializeField] private int _startIndex = 0;

    public void SetPanel(int index)
    {
        if(index < 0 || index > _panels.Length - 1) return;

        foreach (GameObject panel in _panels)
        {
            panel.SetActive(false);
        }
        _panels[index].SetActive(true);
    }

    public void PauseGame(bool pause)
    {
        Time.timeScale = pause ? 0f : 1f;
    }

    [Button]
    private void ShowPanel() => SetPanel(_startIndex);
}
