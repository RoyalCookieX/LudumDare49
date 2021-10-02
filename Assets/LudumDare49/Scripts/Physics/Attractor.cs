using System;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

public class Attractor : MonoBehaviour
{
    [BoxGroup("Properties"), SerializeField] private float _attractRadius;
    [BoxGroup("Properties"), SerializeField] private float _attractionMultiplier = 1.2f;
    [BoxGroup("Properties"), Min(1), SerializeField] private int _maxRigidbodies = 20;
    [BoxGroup("Properties"), SerializeField] private LayerMask _attractorMask;

    private RaycastHit2D[] _raycastHitData;

    private void FixedUpdate()
    {
        _raycastHitData = new RaycastHit2D[_maxRigidbodies];
        Physics2D.CircleCastNonAlloc(transform.position, _attractRadius, Vector2.up, _raycastHitData, 0f, _attractorMask);
        
        foreach(RaycastHit2D info in _raycastHitData)
        {
            Rigidbody2D rb = info.rigidbody;
            if(rb == null) continue;

            Vector2 dir = (transform.position - rb.transform.position).normalized;
            rb.AddForce(dir * _attractionMultiplier);
        }
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _attractRadius);
    }
}