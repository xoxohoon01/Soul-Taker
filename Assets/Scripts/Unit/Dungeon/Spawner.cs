using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataTable;

public class Spawner : MonoBehaviour
{
    private int currentRoomID;

    private GameObject[] objectPool;
    private GameObject testPrefab;
    private SpawnerData spawnData;
    public int GetRoomId() => currentRoomID;

    private void Awake() // 테스트 프리펩 초기화, 차후 삭제 
    {
        testPrefab = Resources.Load<GameObject>("TestMonster");
    }
    public void InitializeSpawner(SpawnerData spawndata) // 데이터 초기화 
    {
        if (spawndata != null)
        {
            this.spawnData = spawndata;
        }

        currentRoomID = spawnData.roomID; 
    }
    public void CreatMonster() // 몬스터 스폰 
    { 
        for (int i = 0; i < spawnData.count; i++)
        {
            GameObject obj = Instantiate(testPrefab, GetGridPosition(i, spawnData.count, spawnData.type), Quaternion.identity);
            obj.GetComponent<MonsterStatus>().InitializeStatus(DataManager.Instance.Monster.GetMonster(spawnData.monsterID));
            obj.transform.SetParent(this.transform); // 부모 설정
        }
    }
    private Vector3 GetGridPosition(int index, int count, int spawnType) // 생성 규칙
    {
        int gridSize = Mathf.CeilToInt(Mathf.Sqrt(count));
        float spacing = 2f; 

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
                x = (col - gridSize / 2) * spacing;
                z = (row - gridSize / 2) * spacing;
                break;
        }

        return new Vector3(x, y, z);

    }
    //public void InitializeObjectPool(SpawnerData spawndata = null) // 스포너 초기화 
    //{
    //    if (spawndata != null) 
    //    {
    //        this.spawnData = spawndata;
    //    }

    //    objectPool = new GameObject[spawnData.count];


    //    for (int i = 0; i < spawnData.count; i++)
    //    {

    //        GameObject obj = Instantiate(testPrefab);
    //        //obj.GetComponent<MonsterStatus>().InitializeStatus(DataManager.Instance.Monster.GetMonster(spawndata.MonsterID));
    //        obj.SetActive(false);
    //        obj.transform.SetParent(this.transform);
    //        objectPool[i] = obj;
    //    }

    //    currentRoomID = spawnData.roomID;
    //}
    //public void InitializeSpawner() // 객체 활성화 
    //{
    //    for (int i = 0; i < spawnData.count; i++)
    //    {
    //        GameObject obj = objectPool[i];

    //        if (!obj.activeInHierarchy)
    //        {
    //            Vector3 Position = GetGridPosition(i, spawnData.count, spawnData.type);
    //            obj.transform.localPosition = Position;
    //            obj.SetActive(true);
    //        }
    //    }
    //}
    //public void ActivateSpawner()
    //{
    //    InitializeSpawner();
    //}
    //public void DeactivateAllObjects()
    //{
    //    foreach (GameObject obj in objectPool)
    //    {
    //        if (obj.activeInHierarchy)
    //        {
    //            obj.SetActive(false);
    //        }
    //    }
    //}
}
