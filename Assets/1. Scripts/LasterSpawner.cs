using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class LasterSpawner : MonoBehaviour
{
    public GameObject prefab;
    public GameObject target;
    float radius = 1f;
    int amountToSpawn = 10;
    private List<GameObject> prefabList = new List<GameObject>();

    public GameObject enemyPrefab;

    private void Start()
    {
        CreateEnemiesAroundPoint();
    }

    public void CreateEnemiesAroundPoint()
    {
        for (int i = 0; i < amountToSpawn; i++)
        {
            float theta = i * 2 * Mathf.PI / amountToSpawn;
            float x = Mathf.Sin(theta) * radius;
            float y = Mathf.Cos(theta) * radius;

            var ob = Instantiate(prefab, target.transform);
            ob.transform.parent = transform;
            ob.transform.position = new Vector3(x, y, 0);  
        }
        
    }
}
