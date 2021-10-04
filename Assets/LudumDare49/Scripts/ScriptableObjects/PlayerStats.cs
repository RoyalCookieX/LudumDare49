using System;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Player Stats")]
public class PlayerStats : ScriptableObject
{
    public int Score => _score;
    public int Highscore => _highscore;

    public UnityAction<int> onScoreUpdated;
    
    [BoxGroup("Score"), SerializeField] private int _score = 0;
    [BoxGroup("Score"), SerializeField] private int _highscore = 0;

    public void Increment(int value = 1)
    {
        _score += value;
        onScoreUpdated?.Invoke(_score);
        if (_score > _highscore) _highscore = _score;
    }
    
    public void ResetScore()
    {
        _score = 0;
    }

    public void HardReset()
    {
        ResetScore();
        _highscore = 0;
    }
}
