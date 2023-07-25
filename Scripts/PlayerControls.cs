using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] private KeyCode _moveLeft;
    [SerializeField] private KeyCode _moveRight; 
    [SerializeField] private float _maxVelocity;
    [SerializeField] private float _movePower;

    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKey(_moveLeft))
            MoveLeft();
        
        if (Input.GetKey(_moveRight))
            MoveRight();
    }

    private void MoveLeft()
    {
        if (_rigidbody.velocity.x >= -_maxVelocity)
            _rigidbody.velocity += Vector2.left * _movePower * Time.deltaTime;
    }
    
    private void MoveRight()
    {
        if (_rigidbody.velocity.x <= _maxVelocity)
            _rigidbody.velocity += Vector2.right * _movePower * Time.deltaTime;
    }
}
