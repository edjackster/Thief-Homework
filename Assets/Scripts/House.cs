using UnityEngine;

[RequireComponent(typeof(Collider))]
public class House : MonoBehaviour
{
    [SerializeField] private Alarm _alarm;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Thief>(out var _) == false)
            return;
        
        _alarm.TurnOn();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Thief>(out var _) == false)
            return;
        
        _alarm.TurnOff();
    }
}