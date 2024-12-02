using DataTable;
using UGS;

public class DatabaseManager : MonoSingleton<DatabaseManager>
{
    // 클래스명 변경, MonoSingleton -> Mono 떼세요;
    public CharacterDataManager Character;
    public ItemDataManager Item;
    public QuestDataManager Quest;
    public DungeonDataManager Dungeon;
    public SpawnerDataManager Spawner;

    public void Initialize()
    {
        UnityGoogleSheet.LoadAllData();
        Character = new CharacterDataManager();
        Item = new ItemDataManager();
        Quest = new QuestDataManager();
        Dungeon = new DungeonDataManager();
        Spawner = new SpawnerDataManager();
    }
}