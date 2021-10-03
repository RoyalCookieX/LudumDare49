using System;
using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    [BoxGroup("Properties"), SerializeField] private PlayerStats _playerStats;

    private void Start()
    {
        _playerStats.Reset();
    }

    public void AddScore()
    {
        _playerStats.Increment();
        Debug.Log(_playerStats.Score);
    }
}
