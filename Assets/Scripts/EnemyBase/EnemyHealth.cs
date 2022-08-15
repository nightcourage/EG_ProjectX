using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int _health = 1;

    public UnityEvent EventOnTakeDamage;
    public UnityEvent EventOnDie;
    public void TakeDamage(int damageValue)
    {
        _health -= damageValue;
        if (_health <= 0)
        {
            Die();
        }

        EventOnTakeDamage.Invoke();
    }

    private void Die()
    {
        Destroy(gameObject);
        EventOnDie.Invoke();
    }
}
