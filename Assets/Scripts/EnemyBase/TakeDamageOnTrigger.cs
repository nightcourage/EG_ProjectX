using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamageOnTrigger : MonoBehaviour
{
    [SerializeField] private EnemyHealth _enemyHealth;
    [SerializeField] private bool _dieOnAnyCollision = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody)
        {
            if (other.attachedRigidbody.GetComponent<Bullet>())
            {
                _enemyHealth.TakeDamage(1);
            }
        }

        if (_dieOnAnyCollision)
        {
            if (other.isTrigger == false)
            {
                _enemyHealth.TakeDamage(10000);
            }
        }
    }
}
