using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private int poolSize = 5;
    [SerializeField] private float respawnTimer = 1f;

    private GameObject[] pool;

    private void Awake()
    {
        PopulatePool();
    }
    
    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }
    
    private void PopulatePool()
    {
        pool = new GameObject[poolSize];

        for (int i = 0; i < pool.Length; i++)
        {
            pool[i] = Instantiate(enemyPrefab, transform);  
            pool[i].SetActive(false);
        }
    }
    
    private void EnableObjectsInPool()
    {
        foreach(GameObject enemy in pool)
        {
            if (!enemy.activeInHierarchy)
            {
                enemy.SetActive(true);
                return;
            }
        }
    }
    
    private IEnumerator SpawnEnemies()
    {
        while(true)
        {
            EnableObjectsInPool();
            yield return new WaitForSeconds(respawnTimer);
        }
    }

    
}
