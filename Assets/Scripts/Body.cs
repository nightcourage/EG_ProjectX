using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body : MonoBehaviour
{
    [SerializeField] private Transform _aim;
    
    private void Update()
    {
        RotatePlayer();
    }

    private void RotatePlayer()
    {
        float x = Mathf.Clamp( _aim.position.x - transform.position.x, -1, 1);
        float angle = -x * 50f;
        Quaternion finalDirection = Quaternion.Euler(transform.rotation.x,angle, transform.rotation.z);
        
        transform.localRotation = Quaternion.Lerp(transform.localRotation, finalDirection, Time.deltaTime * 15f);
    }
}
