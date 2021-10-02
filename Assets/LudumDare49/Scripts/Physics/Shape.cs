using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

public class Shape : MonoBehaviour
{
    [BoxGroup("Properties"), SerializeField] private float _moveSpeed;
    [BoxGroup("Properties"), SerializeField] private Rigidbody2D _rigidbody;
    
    private void Start()
    {
        Vector2 startDir = Random.insideUnitCircle.normalized;
        _rigidbody.AddForce(startDir * _moveSpeed, ForceMode2D.Impulse);
    }
}
