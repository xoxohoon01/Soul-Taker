using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSystem : MonoBehaviour
{
    [SerializeField] private GameObject[] objectPool;

    public Spawn spawnData;
    public GameObject TestPrefab;

    private void Awake()
    {
        TestPrefab = Resources.Load<GameObject>("Monster");
    }

    //private void Start()
    //{
    //    objectPool = new GameObject[spawnData.SpawnCount];

    //    for (int i = 0; i < spawnData.SpawnCount; i++)
    //    {
    //        GameObject obj = Instantiate(TestPrefab);
    //        obj.SetActive(false);
    //        obj.transform.SetParent(this.transform);
    //        objectPool[i] = obj;
    //    }
    //    Spawn();
    //}
 
    public void MonsterSpawn() // 오브젝트 객체 활성화 
    {
        //if (objectPool == null || objectPool.Length == 0) // 예외 처리
        //{
        //    InitializeObjectPool();
        //}

        for (int i = 0; i < spawnData.SpawnCount; i++)
        {
            GameObject obj = objectPool[i];

            if (!obj.activeInHierarchy)
            {
                Vector3 Position = GetGridPosition(i, spawnData.SpawnCount); 
                obj.transform.localPosition = Position;
                obj.SetActive(true);
            }
        }
    }
    public void InitializeObjectPool(Spawn spawndata = null) // 오브젝트 객체 생성 
    {
        if (spawndata != null)
        { 
            this.spawnData = spawndata;
        }

        objectPool = new GameObject[spawnData.SpawnCount];
        for (int i = 0; i < spawnData.SpawnCount; i++)
        {
            GameObject obj = Instantiate(TestPrefab);
            obj.SetActive(false);
            obj.transform.SetParent(this.transform);
            objectPool[i] = obj;
        }
    }

    private Vector3 GetGridPosition(int index, int count) // 격자판에서 안 겹치도록 생성
    {
        int gridSize = Mathf.CeilToInt(Mathf.Sqrt(count));
        float spacing = 3f; // 간격 범위

        int row = index / gridSize;
        int col = index % gridSize;

        float x = (col - gridSize / 2) * spacing;
        float z = (row - gridSize / 2) * spacing;
        float y = 0; 

        return new Vector3(x, y, z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log(objectPool.Length);
            if (objectPool == null || objectPool.Length == 0)
            {
                return;
            }

            MonsterSpawn();
        }
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
