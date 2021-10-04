using System;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHolder : MonoBehaviour, IObjectHolder<PlayerHoldable>
{
    public PlayerHoldable Holdable => _holdable;

    [BoxGroup("Events"), SerializeField] private UnityEvent _onHold;
    [BoxGroup("Events"), SerializeField] private UnityEvent _onRelease;
    
    [BoxGroup("Properties"), SerializeField] private float _releaseOffset = 6f;
    
    private PlayerHoldable _holdable;
    private Camera _mainCamera;

    private void Start()
    {
        _mainCamera = Camera.main;
    }

    private void Update()
    {
        if (_holdable == null) return;
        
        _holdable.transform.position = transform.position;
        if(!Input.GetMouseButtonDown(0)) return;
            
        Vector3 targetPos = Input.mousePosition;
        targetPos.z = 10;
        Vector3 worldPos = _mainCamera.ScreenToWorldPoint(targetPos);
        Vector2 throwDir = (worldPos - transform.position).normalized;

        Release(transform.position, throwDir, _releaseOffset);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.CompareTag("Player"))
        {
            if (other.transform.TryGetComponent(out PlayerHoldable holdable))
            {
                HoldObject(holdable);
            }
        }
        else if (other.transform.CompareTag("BlackHole"))
        {
            if(_holdable != null) _holdable.DestroyPlayer();
        }


    }

    public void HoldObject(PlayerHoldable holdable)
    {
        _holdable = holdable;
        _holdable.Hold();
        _onHold?.Invoke();
    }

    public void Release(Vector2 startPos, Vector2 throwDir, float releaseOffset)
    {
        _holdable.Release(startPos, throwDir, releaseOffset);
        if(_holdable.TryGetComponent(out PlayerScore score))
            score.AddScore();
        _onRelease?.Invoke();;
        _holdable = null;
    }
}