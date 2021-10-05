using System;
using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Events;

public class PanelSwapper : MonoBehaviour
{
    [BoxGroup("Events"), SerializeField] private UnityEvent<int> onPanelSelected;
    
    [BoxGroup("Components"), SerializeField] private CanvasGroup[] _panels;

    [BoxGroup("Properties"), SerializeField] private int _startIndex = 0;

    private void Start()
    {
        if(_startIndex > 0 && _startIndex < _panels.Length - 1)
            SelectPanel(_startIndex);
    }

    public void SelectPanel(int index)
    {
        if(index < 0 || index > _panels.Length - 1) return;

        HideAllPanels();
        ShowPanel(index, true);
        onPanelSelected?.Invoke(index);
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
