using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataTable;

public class CharacterDataManager : CharacterData
{
    public List<CharacterData> GetCharacter()
    {
        return CharacterDataList;
    }

    public CharacterData GetCharacterid(int id)
    {
        return CharacterDataMap[id];
    }
}
