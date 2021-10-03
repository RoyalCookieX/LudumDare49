using System;
using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;
using Random = UnityEngine.Random;

public class Shape : MonoBehaviour
{
    [BoxGroup("Properties"), SerializeField] private float _moveSpeed;
    [BoxGroup("Properties"), MinMaxSlider(-5f, 5f), SerializeField] private Vector2 _rngMultiplierRange;
    [BoxGroup("Properties"), SerializeField] private float _maxLifetime;
    [BoxGroup("Properties"), SerializeField] private float _releaseOffset;
    
    [BoxGroup("Components"), SerializeField] private Rigidbody _rigidbody;

    private void Start()
    {
        Vector2 startDir = Random.insideUnitCircle.normalized;
        float rngVal = Random.Range(_rngMultiplierRange.x, _rngMultiplierRange.y);
        _rigidbody.AddForce(startDir * _moveSpeed * rngVal, ForceMode.Impulse);

        Quaternion startRot = Random.rotation;
        _rigidbody.AddTorque(startRot.eulerAngles * rngVal, ForceMode.Impulse);

        if(_maxLifetime >= 0)
            StartCoroutine(DestroyRoutine());
    }

    private IEnumerator DestroyRoutine()
    {
        yield return new WaitForSeconds(_maxLifetime);
        Destroy(gameObject);
    }
}
