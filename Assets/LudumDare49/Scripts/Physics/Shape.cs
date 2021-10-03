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

    private PlayerMovement _playerMovement;
    private Camera _mainCamera;

    private void Start()
    {
        _mainCamera = Camera.main;
        
        Vector2 startDir = Random.insideUnitCircle.normalized;
        float rngVal = Random.Range(_rngMultiplierRange.x, _rngMultiplierRange.y);
        _rigidbody.AddForce(startDir * _moveSpeed * rngVal, ForceMode.Impulse);

        Quaternion startRot = Random.rotation;
        _rigidbody.AddTorque(startRot.eulerAngles * rngVal, ForceMode.Impulse);

        if(_maxLifetime >= 0)
            StartCoroutine(DestroyRoutine());
    }
    

    public void HoldObject(PlayerMovement player)
    {
        _playerMovement = player;
        _playerMovement.Hide();
    }

    public void ReleaseObject()
    {
        Vector3 targetPos = Input.mousePosition;
        targetPos.z = 10;
        Vector3 worldPos = _mainCamera.ScreenToWorldPoint(targetPos);

        Vector2 throwDir = (worldPos - transform.position).normalized;

        _playerMovement.Throw(this.transform.position, throwDir, _releaseOffset);
        _playerMovement = null;
    }

    private IEnumerator DestroyRoutine()
    {
        yield return new WaitForSeconds(_maxLifetime);
        Destroy(gameObject);
    }


    //Collision With Player

    private void OnCollisionEnter(Collision other){
        if(other.transform.CompareTag("Player")){
            if(other.transform.TryGetComponent(out PlayerMovement playerMovement)){
                HoldObject(playerMovement);
            }
        }
    }

    void Update(){

        if(!(_playerMovement == null) && Input.GetMouseButtonDown(0)){
            ReleaseObject();
        }
    }





}
