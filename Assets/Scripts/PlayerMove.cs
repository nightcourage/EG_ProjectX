using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Transform _collider;
    [SerializeField] private Transform _aim;
    
    [Header("Movement settings")]
    [SerializeField] private float _sideForce;
    [SerializeField] private float _verticalForce;
    [SerializeField] private float _friction;
    [SerializeField] private float _maxSpeed;
    
    [Header("Jumping Settings")]
    [SerializeField] private bool _grounded;
    [Range(0, 90)]
    [SerializeField] private float _allowableAngle;

    [Header("Sitting settings")]
    [SerializeField] private float _scaleSpeed;

    private void Update()
    {
        Jump();
        Sit();
        RotatePlayer();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void RotatePlayer()
    {
        float aimRelativePosition = _aim.localPosition.x;
        Quaternion finalDirection;
        
        if (aimRelativePosition < transform.position.x)
        {
            finalDirection = Quaternion.Euler(0, 50, 0);
        }
        else
        {
            finalDirection = Quaternion.Euler(0, -50, 0);
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, finalDirection, Time.deltaTime * 15f);
    }

    private void Move()
    {
        float speedMultiplier = 1;
        float movementInput = Input.GetAxis("Horizontal");

        if (_grounded == false)
        {
            speedMultiplier = 0.2f;
        }

        if (Mathf.Abs(_rigidbody.velocity.x) > _maxSpeed && Mathf.Abs(movementInput) > 0)
        {
            speedMultiplier = 0;
        }
        
        _rigidbody.AddForce(movementInput * _sideForce * speedMultiplier,0f, 0f, ForceMode.VelocityChange);

        if (_grounded)
        {
            _rigidbody.AddForce(-_rigidbody.velocity.x * _friction, 0f, 0f, ForceMode.VelocityChange);
        }
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _grounded)
        {
            _rigidbody.AddForce(0f, _verticalForce, 0f, ForceMode.VelocityChange);
        }
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
            }
        }
    }

    private void OnCollisionExit(Collision other)
    {
        _grounded = false;
    }
}
