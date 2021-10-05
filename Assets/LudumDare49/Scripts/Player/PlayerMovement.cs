using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class PlayerMovement : MonoBehaviour
{
    private Rigidbody _rb;
    private Vector2 _direction;
    [SerializeField] private float _moveSpeed = 10f;

    private bool jumping = false;
    private Camera _camera;

    void Start()
    {
        _camera = Camera.main;
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Vector3 targetPos = Input.mousePosition;
        targetPos.z = 10;
        Vector3 worldPos = _camera.ScreenToWorldPoint(targetPos);
        Vector3 throwDir = (worldPos - transform.position).normalized;
        
        //Rotate Player Towards the Mouse
        if(Input.GetMouseButton(0) && !(jumping)) {
            Throw(transform.position, throwDir, 0f);
        }
    }

    public void Hide() {
        jumping = false;
        _rb.velocity = Vector3.zero;
    }

    public void Throw(Vector2 startPos, Vector2 throwDir, float releaseOffset){
        jumping = true;
        
        transform.position = (startPos + throwDir.normalized * releaseOffset);
        _rb.AddForce(throwDir * _moveSpeed, ForceMode.VelocityChange);
    }
}
