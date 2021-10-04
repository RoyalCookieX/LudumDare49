using System;
using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using TMPro;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour
{
    [BoxGroup("Components"), SerializeField] private TMP_Text _scoreText;
    
    [BoxGroup("Properties"), SerializeField] private PlayerStats _playerStats;

    private void OnEnable()
    {
        _playerStats.onScoreUpdated += SetScoreText;
        SetScoreText(_playerStats.Score);
    }

    private void OnDisable()
    {
        _playerStats.onScoreUpdated -= SetScoreText;
    }

    private void SetScoreText(int score)
    {
        _scoreText.text = $"{score}";
    }
}
