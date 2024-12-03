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
    public void InitializeObjectPool(SpawnerData spawndata = null) // 스포너 초기화 
    {
        if (spawndata != null)
        {
            this.spawnData = spawndata;
        }

        objectPool = new GameObject[spawnData.SpawnCount];
        for (int i = 0; i < spawnData.SpawnCount; i++)
        {
            GameObject obj = Instantiate(TestPrefab);
            //obj.GetComponent<MonsterStatus>().InitializeStatus(DataManager.Instance.Monster.GetMonster(spawndata.MonsterID));
            obj.SetActive(false);
            obj.transform.SetParent(this.transform);
            objectPool[i] = obj;
        }

        spawnerRoomID = spawnData.SpawnRoom;
    }
    public void InitializeSpawner() // 객체 활성화 
    {
        for (int i = 0; i < spawnData.SpawnCount; i++)
        {
            GameObject obj = objectPool[i];

            if (!obj.activeInHierarchy)
            {
                Vector3 Position = GetGridPosition(i, spawnData.SpawnCount, spawnData.SpawnType);
                obj.transform.localPosition = Position;
                obj.SetActive(true);
            }
        }
    }
    private Vector3 GetGridPosition(int index, int count, int spawnType) // 생성 규칙
    {
        int gridSize = Mathf.CeilToInt(Mathf.Sqrt(count));
        float spacing = 3f; // 기본 간격

        int row = index / gridSize;
        int col = index % gridSize;

        float x = 0, y = 5, z = 0;

        switch (spawnType)
        {
            case 0: // 기본 격자 생성
                x = (col - gridSize / 2) * spacing;
                z = (row - gridSize / 2) * spacing;
                break;

            case 1: // 원형 생성
                float angle = (360f / count) * index;
                float radius = 5f;
                x = Mathf.Cos(angle * Mathf.Deg2Rad) * radius;
                z = Mathf.Sin(angle * Mathf.Deg2Rad) * radius;
                break;

            case 2: // 라인 생성
                x = index * spacing;
                z = 0;
                break;

            //case 3: // 랜덤 생성 (범위 제한)
            //    x = Random.Range(-5f, 5f);
            //    z = Random.Range(-5f, 5f);
            //    break;

            //case 4: // 계단 형태
            //    x = index * spacing;
            //    y = index * 0.5f; // 높이 증가
            //    z = 0;
            //    break;

            default:
                Debug.LogWarning("알 수 없는 SpawnType입니다. 기본 생성 규칙을 사용합니다.");
                x = (col - gridSize / 2) * spacing;
                z = (row - gridSize / 2) * spacing;
                break;
        }

        return new Vector3(x, y, z);

    }
    public void ActivateSpawner()
    {
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
