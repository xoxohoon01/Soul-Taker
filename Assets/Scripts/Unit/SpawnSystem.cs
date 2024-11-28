using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSystem : MonoBehaviour
{
    [SerializeField] private GameObject[] objectPool;
    [SerializeField] private Vector3 spawnAreaMin; 
    [SerializeField] private Vector3 spawnAreaMax; 

    public Spawn spawnData;
    public GameObject TestPrefab;

    private void Awake()
    {
        TestPrefab = Resources.Load<GameObject>("Monster");
    }
    private void Start()
    {
        objectPool = new GameObject[spawnData.SpawnCount];

        for (int i = 0; i < spawnData.SpawnCount; i++)
        {
            GameObject obj = Instantiate(TestPrefab);
            obj.SetActive(false);
            obj.transform.SetParent(this.transform);
            objectPool[i] = obj;
        }

        Spawn();
    }
    public void Spawn()
    {
        for (int i = 0; i < spawnData.SpawnCount; i++)
        {
            GameObject obj = objectPool[i];

            if (!obj.activeInHierarchy) 
            {
                Vector3 randomPosition = GetGridPosition(i, spawnData.SpawnCount);
                obj.transform.localPosition = randomPosition; 
                obj.SetActive(true); 
            }
        }
    }

    private Vector3 GetGridPosition(int index, int count)
    {
        int gridSize = Mathf.CeilToInt(Mathf.Sqrt(count));
        float spacing = 3f;

        int row = index / gridSize;
        int col = index % gridSize;

        float x = (col - gridSize / 2) * spacing;
        float z = (row - gridSize / 2) * spacing;
        float y = 0; 

        return new Vector3(x, y, z);
    }

    public void DeactivateAllObjects()
        {
            foreach (GameObject obj in objectPool)
            {
                if (obj.activeInHierarchy)
                {
                    obj.SetActive(false);
                }
            }
        }
    }
