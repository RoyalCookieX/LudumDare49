using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Events;

public class PauseKeyHandler : MonoBehaviour
{
    [BoxGroup("Events"), SerializeField] private UnityEvent _onPauseKeyPressed;

    [BoxGroup("Properties"), SerializeField] private KeyCode _pauseKey = KeyCode.Escape;
    
    private void Update()
    {
        if (Input.GetKeyDown(_pauseKey))
        {
            _onPauseKeyPressed?.Invoke();
        }
    }
}
