using System.Collections.Generic;

[System.Serializable]
public class Dungeon
{
    public int ID; // 던전 ID
    public string Name; // 던전 이름 
    public string Description; // 던전 설명 
    public int Difficulty; // 던전 난이도 
    public int PlayerLevel; // 적정 플레이어 레벨 
    public List<int> Spawners; // 스포너 데이터
}


 