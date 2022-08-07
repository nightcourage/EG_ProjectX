using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTriggerEveryNSeconds : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private float _timePeriod; 
    private float _timer;

    [SerializeField] private string _triggerName = "Attack";

    private void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= _timePeriod)
        {
            _timer = 0;
            _animator.SetTrigger(_triggerName);
        }
    }
}
