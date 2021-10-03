using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Events;

public class PlayerScore : MonoBehaviour
{
    [BoxGroup("Events"), SerializeField] private UnityEvent onLose;
    
    [BoxGroup("Properties"), SerializeField] private PlayerStats _playerStats;

    private void Start()
    {
        _playerStats.Reset();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.CompareTag("BlackHole"))
        {
            Lose();
        }
    }

    public void AddScore()
    {
        _playerStats.Increment();
        Debug.Log(_playerStats.Score);
    }

    public void Lose()
    {
        Debug.Log("Lose Game");
        onLose?.Invoke();
        if(gameObject != null) Destroy(gameObject);
    }
}
