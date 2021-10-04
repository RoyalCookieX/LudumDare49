using System;
using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Events;

public class PanelSwapper : MonoBehaviour
{
    [BoxGroup("Components"), SerializeField] private CanvasGroup[] _panels;

    [BoxGroup("Properties"), SerializeField] private int _startIndex = 0;

    private void Start()
    {
        SetPanel(_startIndex);
    }

    public void SetPanel(int index)
    {
        if(index < 0 || index > _panels.Length - 1) return;

        HideAllPanels();
        ShowPanel(index, true);
    }
    
    public void ShowPanel(int index, bool visible)
    {
        if(index < 0 || index > _panels.Length - 1) return;

        _panels[index].alpha = visible ? 1f : 0f;
        _panels[index].interactable = visible;
        _panels[index].blocksRaycasts = visible;
    }
    
    public void HideAllPanels()
    {
        for (int i = 0; i < _panels.Length; i++)
        {
            ShowPanel(i, false);
        }
    }
}
