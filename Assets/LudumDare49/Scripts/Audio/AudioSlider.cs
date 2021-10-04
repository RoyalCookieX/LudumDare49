using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Events;


public class AudioSlider : MonoBehaviour
{
    [BoxGroup("Events"), SerializeField] private UnityEvent<string, float> onValueChanged;
    
    [BoxGroup("Properties"), SerializeField] private string _volumeName;

    public void UpdateValue(float value)
    {
        onValueChanged?.Invoke(_volumeName, value);
    }
}
