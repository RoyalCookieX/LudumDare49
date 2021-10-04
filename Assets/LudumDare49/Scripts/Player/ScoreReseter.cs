using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreReseter : MonoBehaviour
{
    [SerializeField] private PlayerStats _stats;
    
    // Start is called before the first frame update
    void Start()
    {
        _stats.ResetScore();
    }
}
