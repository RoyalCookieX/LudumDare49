using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Events;

public class PauseKeyHandler : MonoBehaviour
{
    [BoxGroup("Events"), SerializeField] private UnityEvent _onPauseKeyPressed;

    [BoxGroup("Properties"), SerializeField] private KeyCode _pauseKey = KeyCode.Escape;
    [BoxGroup("Properties"), SerializeField] private int _panelIndex;

    private bool _checkForKey = true;
    
    public void OnPanelSwapped(int index)
    {
        _checkForKey = index == _panelIndex;
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(_pauseKey) && _checkForKey)
        {
            _onPauseKeyPressed?.Invoke();
        }
    }
}
