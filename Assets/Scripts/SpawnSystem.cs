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
                Vector3 randomPosition = GetRandomPosition();
                obj.transform.localPosition = randomPosition; 
                obj.SetActive(true); 
            }
        }
    }

    private Vector3 GetRandomPosition()
    {
        float randomX = Random.Range(spawnAreaMin.x, spawnAreaMax.x);
        float randomY = Random.Range(spawnAreaMin.y, spawnAreaMax.y);
        float randomZ = Random.Range(spawnAreaMin.z, spawnAreaMax.z);
        return new Vector3(randomX, randomY, randomZ);
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
