using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventHorizon : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if(!other.transform.CompareTag("Player")) return;

        if (other.transform.TryGetComponent(out PlayerScore playerScore))
        {
            playerScore.Lose();
        }
    }
}
