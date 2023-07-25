using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SensorController : MonoBehaviour
{
    [SerializeField] private UnityEvent _houseEntered;
    [SerializeField] private UnityEvent _houseLeft;
    
    public event UnityAction HouseEntered
    {
        add => _houseEntered.AddListener(value);
        remove => _houseEntered.RemoveListener(value);
    }
    
    public event UnityAction HouseLeft
    {
        add => _houseLeft.AddListener(value);
        remove => _houseLeft.RemoveListener(value);
    }
    
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
