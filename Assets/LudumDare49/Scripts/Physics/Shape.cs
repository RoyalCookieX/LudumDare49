using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

public class Shape : MonoBehaviour
{
    [BoxGroup("Properties"), SerializeField] private float _moveSpeed;
    [BoxGroup("Properties"), SerializeField] private Rigidbody _rigidbody;
    
    private void Start()
    {
        Vector2 startDir = Random.insideUnitCircle.normalized;
        float rngVal = Random.Range(1f, 2f);
        _rigidbody.AddForce(startDir * _moveSpeed * rngVal, ForceMode.Impulse);
    }
}
