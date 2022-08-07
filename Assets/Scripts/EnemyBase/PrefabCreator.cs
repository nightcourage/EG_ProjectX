using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabCreator : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private Transform _spawnPoint;

    public void Create()
    {
        Instantiate(_prefab, new Vector3(_spawnPoint.position.x, _spawnPoint.position.y, 0), _spawnPoint.rotation);
    }
}