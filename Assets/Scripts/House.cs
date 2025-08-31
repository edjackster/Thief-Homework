using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class House : MonoBehaviour
{
    [SerializeField] private Alarm _alarm;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entered " + other.gameObject.name);
        if (other.TryGetComponent<Thief>(out var thief) == false)
            return;
        
        _alarm.TurnOn();
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Exited " + other.gameObject.name);
        if (other.TryGetComponent<Thief>(out var thief) == false)
            return;
        
        _alarm.TurnOff();
    }
}