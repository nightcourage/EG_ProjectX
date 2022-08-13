using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    private float _startFixedDeltaTime;
    [SerializeField] private float _tiimeScale = 0.2f;

    private void Start()
    {
        _startFixedDeltaTime = Time.fixedDeltaTime;
    }

    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            Time.timeScale = _tiimeScale;
        }
        else
        {
            Time.timeScale = 1;
        }

        Time.fixedDeltaTime = _startFixedDeltaTime * Time.timeScale;
    }

    private void OnDestroy()
    {
        Time.fixedDeltaTime = _startFixedDeltaTime;
    }
}
