using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{  
    private Rigidbody _rb;
    private Vector2 _direction;
    /*[SerializedField]*/private float _moveSpeed = 15f;
    /*[SerializedField]*/private float _maxVelocity = 10f;

    private bool _jumping = false;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {

        if(Input.GetMouseButton(0) && !(_jumping)){
            _jumping = true;

            Vector3 targetPos = Input.mousePosition;
            targetPos.z = 10;
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(targetPos);


            _direction = (worldPos - transform.position).normalized;
            _rb.AddForce(_direction * _moveSpeed, ForceMode.Impulse);
            _rb.velocity = Vector3.ClampMagnitude(_rb.velocity, _maxVelocity);

        }
                   

    }
}
