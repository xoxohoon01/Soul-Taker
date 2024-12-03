using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataTable;

public class SpawnSystem : MonoBehaviour
{
    [SerializeField] private GameObject[] objectPool;
    [SerializeField] private GameObject TestPrefab;
    [SerializeField] private SpawnerData spawnData;
    [SerializeField] private int spawnerRoomID;

    public int GetRoomId() => spawnerRoomID;

    private void Awake()
    {
        TestPrefab = Resources.Load<GameObject>("TestMonster");
    }

    public void InitializeObjectPool(SpawnerData spawndata = null) // 오브젝트 객체 생성 
    {
        if (spawndata != null)
        {
            this.spawnData = spawndata;
        }

        objectPool = new GameObject[spawnData.SpawnCount];
        for (int i = 0; i < spawnData.SpawnCount; i++)
        {
            GameObject obj = Instantiate(TestPrefab);
            //obj.GetComponent<MonsterStatus>().InitializeLevel(spawnData.MonsterLevel);
            obj.GetComponent<MonsterStatus>().InitializeStatus(DataManager.Instance.Monster.GetMonster(spawndata.MonsterID));
            obj.SetActive(false);
            obj.transform.SetParent(this.transform);
            objectPool[i] = obj;
        }

        spawnerRoomID = spawnData.SpawnRoom;
        Debug.Log(spawnerRoomID);

    }

    public void InitializeSpawner() // 객체 초기화 (pull)
    {
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

    public void ActivateSpawner()
    {
        Debug.Log("몬스터 활성화 할 거임.");
        InitializeSpawner();
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
