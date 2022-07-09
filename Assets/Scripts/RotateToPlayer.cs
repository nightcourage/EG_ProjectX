using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToPlayer : MonoBehaviour
{ 
    private Transform _playerTransform;
    [SerializeField] private Vector3 _leftEuler;
    [SerializeField] private Vector3 _rightEuler;
    [SerializeField] private float _rotationSpeed = 5f;
    private Vector3 _targetEuler;
    
    private void Start()
    {
        _playerTransform = FindObjectOfType<PlayerHealth>().transform;
    }

    private void Update()
    {
        Rotate();
    }

    private void Rotate()
    {
        if (transform.position.x < _playerTransform.position.x)
        {
            _targetEuler = _rightEuler;
        }
        else
        {
            _targetEuler = _leftEuler;
        }
        
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(_targetEuler), Time.deltaTime * _rotationSpeed);
    }
}
