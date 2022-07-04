using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carrot : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _carrotSpeed;
    
    void Start()
    {
        Transform playerTransform = FindObjectOfType<PlayerHealth>().transform;
        Vector3 toPlayer = (playerTransform.position - transform.position).normalized;

        _rigidbody.velocity = toPlayer * _carrotSpeed;
    }
}
