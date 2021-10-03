using System;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHoldable : MonoBehaviour, IHoldable
{
    [SerializeField] private UnityEvent onHeld;
    [SerializeField] private UnityEvent<Vector2, Vector2, float> onReleased;
    [SerializeField] private UnityEvent onDestroyed;
    
    private void OnDestroy()
    {
        DestroyPlayer();
    }
    
    public void Hold()
    {
        onHeld?.Invoke();
    }

    public void Release(Vector2 startPos, Vector2 throwDir, float releaseOffset)
    {
        onReleased?.Invoke(startPos, throwDir, releaseOffset);
    }

    public void DestroyPlayer()
    {
        onDestroyed.Invoke();
    }
}