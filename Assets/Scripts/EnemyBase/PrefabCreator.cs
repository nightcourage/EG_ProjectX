using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabCreator : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private Transform _spawnPoint;

    public void Create()
    {
        //без понятия в чем прблема, но префаб создается с каким-то отклонением в сторону. В результате игрок не может попасть по ракете. Лучше всего видно на медведе.
        //Просидел несколько часов так и не понял, где ошибка.
        Instantiate(_prefab, _spawnPoint.position, _spawnPoint.localRotation);
    }
}