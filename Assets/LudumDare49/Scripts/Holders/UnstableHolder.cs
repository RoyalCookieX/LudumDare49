using System;
using Cinemachine;
using NaughtyAttributes;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(CinemachineImpulseSource))]
public class UnstableHolder : MonoBehaviour, IObjectHolder<PlayerHoldable>
{
    public PlayerHoldable Holdable => _holdable;

    
    [BoxGroup("Properties"), SerializeField] private float _releaseOffset = 6f;

    private PlayerHoldable _holdable;
    private CinemachineImpulseSource _impulseSource;

    private void Start()
    {
        _impulseSource = GetComponent<CinemachineImpulseSource>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if(!other.transform.CompareTag("Player")) return;

        if (other.transform.TryGetComponent(out PlayerHoldable holdable))
        {
            HoldObject(holdable);
        }
    }
    
    public void HoldObject(PlayerHoldable holdable)
    {
        _holdable = holdable;
        _holdable.Hold();
        Release(transform.position, Random.insideUnitCircle.normalized, _releaseOffset);
        _impulseSource.GenerateImpulse();
    }

    public void Release(Vector2 startPos, Vector2 throwDir, float releaseOffset)
    {
        _holdable.Release(startPos, throwDir, releaseOffset);
        _holdable = null;
    }
}