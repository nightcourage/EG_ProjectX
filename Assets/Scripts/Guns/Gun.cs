using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private float _bulletSpeed = 10f;
    [SerializeField] private float _attackSpeed = 0.2f;

    [SerializeField] private AudioSource _fireSound;
    [SerializeField] private GameObject _flashRender;

    private float _timer;

    private void Update()
    {
        FireBullet();
    }

    private void FireBullet()
    {
        _timer += Time.deltaTime;
        if (Input.GetMouseButton(0) && _timer > _attackSpeed)
        {
            Shot();
        }
    }

    private void HideFlash()
    {
        _flashRender.SetActive(false);
    }

    public virtual void AddBullets(int numberOfBullets)
    {
        
    }

    public virtual void Shot()
    {
        _timer = 0;
        GameObject newBullet = Instantiate(_bulletPrefab, _spawnPoint.position, _spawnPoint.rotation);
        newBullet.GetComponent<Rigidbody>().velocity = _spawnPoint.forward * _bulletSpeed;
        _fireSound.Play();
        _flashRender.SetActive(true);
        Invoke(nameof(HideFlash), 0.12f);
    }

    public virtual void Activate()
    {
        gameObject.SetActive(true);
    }

    public virtual void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
