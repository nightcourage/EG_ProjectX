using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Transform _collider; 

    [Header("Movement settings")]
    [SerializeField] private float _sideForce;
    [SerializeField] private float _verticalForce;
    [SerializeField] private float _friction;
    [SerializeField] private float _maxSpeed;
    
    [Header("Jumping Settings")]
    [SerializeField] private bool _grounded = true;
    [Range(0, 90)]
    [SerializeField] private float _allowableAngle;

    [Header("Sitting settings")]
    [SerializeField] private float _scaleSpeed;

    private int _jumpFrameCounter;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_grounded)
            {
                Jump(); 
            }
        }
        Sit();
    }

    private void FixedUpdate()
    {
        Move();

        _jumpFrameCounter += 1;
        if (_jumpFrameCounter == 2)
        {
            _rigidbody.freezeRotation = false;
            _rigidbody.AddRelativeTorque(0f, 0f, 20f, ForceMode.VelocityChange);
        }
    }

    private void Move()
    {
        float speedMultiplier = 1;
        float movementInput = Input.GetAxis("Horizontal");

        if (_grounded == false)
        {
            speedMultiplier = 0.2f;
            
            if (_rigidbody.velocity.x > _maxSpeed && movementInput > 0)
            {
                speedMultiplier = 0;
            }
            
            if (_rigidbody.velocity.x < -_maxSpeed && movementInput <  0)
            {
                speedMultiplier = 0;
            }
        }

        _rigidbody.AddForce(movementInput * _sideForce * speedMultiplier,0f, 0f, ForceMode.VelocityChange);

        if (_grounded)
        {
            _rigidbody.AddForce(-_rigidbody.velocity.x * _friction, 0f, 0f, ForceMode.VelocityChange);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.identity, Time.deltaTime * 15f);
        }
    }

    private void Jump()
    {
        _rigidbody.AddForce(0f, _verticalForce, 0f, ForceMode.VelocityChange);
        _jumpFrameCounter = 0;
    }

    private void Sit()
    {
        float scale;
        if (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.S) || _grounded == false)
        {
            scale = 0.5f;
            _collider.localScale = Vector3.Lerp(_collider.localScale, new Vector3(1f, scale, 1f), Time.deltaTime * _scaleSpeed);
        }
        else
        {
            scale = 1f;
            _collider.localScale = Vector3.Lerp(_collider.localScale, new Vector3(1f, scale, 1f), Time.deltaTime * _scaleSpeed);
        }
    }

    private void OnCollisionStay(Collision collisionInfo)
    {
        for (int i = 0; i < collisionInfo.contactCount; i++)
        {
            float currentAngle = Vector3.Angle(collisionInfo.contacts[i].normal, Vector3.up);

            if (currentAngle < _allowableAngle)
            {
                _grounded = true;
                _rigidbody.freezeRotation = true;
            }
        }
    }

    private void OnCollisionExit(Collision other)
    {
        _grounded = false;
    }
}
