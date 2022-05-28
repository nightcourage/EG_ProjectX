using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _lerpSpeed = 10f;
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, _target.position, Time.deltaTime * _lerpSpeed);
    }
}
