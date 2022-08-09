using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesActivator : MonoBehaviour
{
    [SerializeField] public List<ActivateByDistance> _objectsToActivate = new List<ActivateByDistance>();
    [SerializeField] private Transform _playerTransform;

    private void Update()
    {
        for (int i = 0; i < _objectsToActivate.Count; i++)
        {
            _objectsToActivate[i].CheckDistance(_playerTransform.position);
        }
    }
}
