using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AlarmSensor : MonoBehaviour
{
    [SerializeField] private UnityEvent _houseEntered;
    [SerializeField] private UnityEvent _houseLeft;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player) == true)
            _houseEntered?.Invoke();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player) == true)
            _houseLeft?.Invoke();
    }
}
