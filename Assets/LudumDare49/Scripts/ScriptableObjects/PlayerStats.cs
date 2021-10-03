using System;
using NaughtyAttributes;
using UnityEngine;

[CreateAssetMenu(menuName = "Player Stats")]
public class PlayerStats : ScriptableObject
{
    public int Score => _score;
    
    [BoxGroup("Score"), SerializeField] private int _score = 0;

    public void Increment(int value = 1) => _score += value;
    
    public void Reset()
    {
        _score = 0;
    }
}
