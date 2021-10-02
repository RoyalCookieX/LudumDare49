using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{  
    private Rigidbody _rb;
    private Vector2 _direction;
    private float _moveSpeed = 10f;
    private float _maxVelocity = 10f;

    private bool jumping = false;

    private MeshRenderer _mesh;
    //private bool _held = false;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _mesh = GetComponent<MeshRenderer>();
    }

    void Update()
    {

        if(Input.GetMouseButton(0) && !(jumping)){
            jumping = true;
            Jump();
        }
                   

    }
    public void Jump(){
        Vector3 targetPos = Input.mousePosition;
        targetPos.z = 10;
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(targetPos);


        _direction = (worldPos - transform.position).normalized;
        _rb.AddForce(_direction * _moveSpeed, ForceMode.Impulse);
        _rb.velocity = Vector3.ClampMagnitude(_rb.velocity, _maxVelocity);
    }


    public void Hide(){
        jumping = false;
        _mesh.enabled = false;
        _rb.velocity = Vector3.zero;


    }

    public void Throw(Vector2 startPos, Vector2 throwDir, float releaseOffset){
        
        jumping = true;

        transform.position = (startPos + throwDir * releaseOffset);
        _rb.AddForce(throwDir * _moveSpeed, ForceMode.Impulse);
        
        _mesh.enabled = true;

    }



}
