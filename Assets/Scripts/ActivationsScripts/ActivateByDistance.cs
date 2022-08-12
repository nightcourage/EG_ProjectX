using System;
using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

public class ActivateByDistance : MonoBehaviour
{

    public float distanceToActivate = 20f;

    private bool _isActive = true;
    private EnemiesActivator _activator;


    private void Start()
    {
        _activator = FindObjectOfType<EnemiesActivator>();
        _activator._objectsToActivate.Add(this);
        
    }

    public void CheckDistance(Vector3 playerPosition)
    {
        float distance = Vector3.Distance(transform.position, playerPosition);

        if (_isActive)
        {
            if (distance > distanceToActivate + 2f)
            {
                Deactivate();
            }
        }
        else
        {
            if (distance < distanceToActivate)
            {
                Activate();
            }
        }
       
    }
    public void Activate()
    {
        _isActive = true;
        gameObject.SetActive(true);
    }

    public void Deactivate()
    {
        _isActive = false;
        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        _activator._objectsToActivate.Remove(this);
    }

    #if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        Handles.color = Color.gray;
        Handles.DrawWireDisc(transform.position, Vector3.forward, distanceToActivate);
    }
    #endif
}
