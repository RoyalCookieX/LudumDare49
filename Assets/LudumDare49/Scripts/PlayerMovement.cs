using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private UnityEvent onThrown;
    
    private Rigidbody _rb;
    private Vector2 _direction;
    [SerializeField] private float _moveSpeed = 10f;
    [SerializeField] private float _maxVelocity = 10f;

    private bool jumping = false;

    [SerializeField] private GameObject _meshObject;
    [SerializeField] private Collider _collider;

    //private bool _held = false;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Vector3 targetPos = Input.mousePosition;
        targetPos.z = 20;
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(targetPos);
        //Rotate Player Towards the Mouse
        
        if(Input.GetMouseButton(0) && !(jumping)){
            jumping = true;
            Jump(targetPos, worldPos);
        }
    }
    
    public void Jump(Vector3 targetPos, Vector3 worldPos){
        _direction = (worldPos - transform.position).normalized;
        _rb.AddForce(_direction * _moveSpeed, ForceMode.Impulse);
        _rb.velocity = Vector3.ClampMagnitude(_rb.velocity, _maxVelocity);
    }

    public void Hide(){
        jumping = false;
        _rb.velocity = Vector3.zero;
        _meshObject.SetActive(false);
        _collider.enabled = false;
    }

    public void Throw(Vector2 startPos, Vector2 throwDir, float releaseOffset){
        _meshObject.SetActive(true);
        _collider.enabled = true;
        jumping = true;

        transform.position = (startPos + throwDir * releaseOffset);
        _rb.AddForce(throwDir * _moveSpeed, ForceMode.Impulse);
        onThrown?.Invoke();
    }
}
