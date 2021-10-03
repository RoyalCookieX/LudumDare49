using System;
using NaughtyAttributes;
using UnityEngine;

[CreateAssetMenu(menuName = "Player Stats")]
public class PlayerStats : ScriptableObject
{
    public int Score => _score;
    public int Highscore => _highscore;
    
    [BoxGroup("Score"), SerializeField] private int _score = 0;
    [BoxGroup("Score"), SerializeField] private int _highscore = 0;

    public void Increment(int value = 1)
    {
        _score += value;
        if (_score > _highscore) _highscore = _score;
    }
    
    public void Reset()
    {
        _score = 0;
    }

    public void HardReset()
    {
        Reset();
        _highscore = 0;
    }
}
