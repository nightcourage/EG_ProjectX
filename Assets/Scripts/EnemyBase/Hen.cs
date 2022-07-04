using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hen : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    private Transform _targetTransform;

    [SerializeField] private float _maxSpeed = 3;
    [SerializeField] private float _timeToMaxSpeed = 1;

    private void Start()
    {
        _targetTransform = FindObjectOfType<PlayerMove>().transform;
    }

    private void FixedUpdate()
    {
        Vector3 toTarget = (_targetTransform.position - transform.position).normalized;
        
        Vector3 force = _rigidbody.mass * (toTarget * _maxSpeed - _rigidbody.velocity)/_timeToMaxSpeed;
        
        _rigidbody.AddForce(force);
    }
}
