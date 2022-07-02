using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUI : MonoBehaviour
{
    [SerializeField] private GameObject HealthIconPrefab;

    private List<GameObject> _healthIconsList = new List<GameObject>();

    public void SetLives(int maxHealth)
    {
        for (int i = 0; i < maxHealth; i++)
        {
            GameObject newObject = Instantiate(HealthIconPrefab, transform);
            _healthIconsList.Add(newObject);
        }
    }

    public void DispplayHealth(int health)
    {
        for (int i = 0; i < _healthIconsList.Count; i++)
        {
            if (i < health)
            {
                _healthIconsList[i].SetActive(true);
            }
            else
            {
                _healthIconsList[i].SetActive(false);
            }
        }
    }
}
