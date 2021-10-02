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

    private Collider[] _colliderData;

    private void OnCollisionEnter(Collision other)
    {
        if(other.transform.CompareTag("Shape"))
            Destroy(other.gameObject);
    }

    private void FixedUpdate()
    {
        _colliderData = new Collider[_maxRigidbodies];
        Physics.OverlapSphereNonAlloc(transform.position, _attractRadius, _colliderData, _attractorMask);
        
        foreach(Collider col in _colliderData)
        {
            if(col == null) continue;
            Rigidbody rb = col.attachedRigidbody;
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