using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    [SerializeField] private float _speed = 1f;
    [SerializeField] private float _rotationSpeed = 1f;

    private Transform _playerTransform;

    private void Start()
    {
        _playerTransform = FindObjectOfType<PlayerMove>().transform;
        transform.position = new Vector3(3, 3, -0.1f); //погрешность минимальная, но это все равно не Z = 0, почему так? Как сделать полет "ровным"?
    }

    private void Update()
    {
        transform.position += transform.forward * _speed * Time.deltaTime;
        Vector3 toPlayer = _playerTransform.position - transform.position;

        Quaternion targetRotation = Quaternion.LookRotation(toPlayer, Vector3.forward);

        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * _rotationSpeed);
    }
}
