using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int _health = 5;
    [SerializeField] private int _maxHealth = 8;
    [SerializeField] private AudioSource _addHealthSound;
    [SerializeField] private HealthUI _healthUI;

    private bool _invulnerable = false;

    public UnityEvent EventOnTakeDamage;

    private void Start()
    {
        _healthUI.SetLives(_maxHealth);
        _healthUI.DispplayHealth(_health);
    }

    public void TakeDamage(int damageValue)
    {
        if (_invulnerable == false)
        {
            _health -= damageValue;
            if (_health <= 0)
            {
                _health = 0;
                Die();
            }
            EventOnTakeDamage.Invoke();
            _invulnerable = true;
            Invoke(nameof(StopInvulnerable), 1f);
        }
        _healthUI.DispplayHealth(_health);
    }

    private void StopInvulnerable()
    {
        _invulnerable = false;
    }
    
    public void AddHealth(int healthValue)
    {
        _health += healthValue;
        if (_health > _maxHealth)
        {
            _health = _maxHealth;
        }
        _addHealthSound.Play();
        _healthUI.DispplayHealth(_health);
    }

    private void Die()
    {
        Debug.Log("You Lose");
    }
}
