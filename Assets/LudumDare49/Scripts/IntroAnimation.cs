using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class IntroAnimation : MonoBehaviour
{
    [SerializeField] private UnityEvent _onGameStart;
    
    [SerializeField] private GameObject _blackHole;
    [SerializeField] private Rigidbody _playerRB;
    [SerializeField] private Vector2 _origin = Vector2.zero;

    [SerializeField] private float _startRadius;
    [SerializeField] private float _startForce = 20;

    private void Start()
    {
        _blackHole.SetActive(false);
        _playerRB.gameObject.SetActive(false);
    }

    public void StartGame()
    {
        _onGameStart?.Invoke();
    }

    public void ShowBlackHole()
    {
        _blackHole.SetActive(true);
    }

    public void LaunchPlayer()
    {
        _playerRB.gameObject.SetActive(true);
        Vector2 randomDir = Random.insideUnitCircle.normalized;
        _playerRB.transform.position = _origin + randomDir * _startRadius;
        _playerRB.AddForce(randomDir * _startForce, ForceMode.Impulse);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(_origin, _startRadius);
    }
}
