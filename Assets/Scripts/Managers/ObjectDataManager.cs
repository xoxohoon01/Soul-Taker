using System.Collections.Generic;
using DataTable;

public class ObjectDataManager : ObjectData
{
    public List<ObjectData> GetObject()
    {
        return ObjectDataList;
    }

    public ObjectData GetObjectid(int DungeonId)
    {
        return ObjectDataList.Find(x => x.ID == DungeonId);
    }
}