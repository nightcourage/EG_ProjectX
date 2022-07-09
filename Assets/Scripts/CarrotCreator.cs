using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarrotCreator : MonoBehaviour
{
    [SerializeField] private GameObject _carrotPrefab;
    [SerializeField] private Transform _spawn;

    public void Create()
    {
        Instantiate(_carrotPrefab, _spawn.position, Quaternion.identity);
    }
}
