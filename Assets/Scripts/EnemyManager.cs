using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private EnemyHealth[] _enemiesArray;

    private Transform _playerTransform;
    
    void Start()
    {
        _playerTransform = FindObjectOfType<PlayerHealth>().transform;
       _enemiesArray = FindObjectsOfType<EnemyHealth>();
       foreach (var enemy in _enemiesArray)
       {
           enemy.gameObject.SetActive(false);
       }
    }
    
    void Update()
    {
        for (int i = 0; i < _enemiesArray.Length; i++)
        {
            if (_enemiesArray[i] != null)
            {
                if (_enemiesArray[i].transform.position.x - _playerTransform.position.x <= 20)
                {
                    _enemiesArray[i].gameObject.SetActive(true);
                }
            }
        }
    }
}
