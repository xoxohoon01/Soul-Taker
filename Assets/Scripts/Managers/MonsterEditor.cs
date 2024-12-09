using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;
using System.Text;
using Unity.VisualScripting;
using UnityEngine.UI;
using DataTable;

public class MonsterEditor : MonoBehaviour
{
    public TMP_InputField HP;
    public TMP_InputField MP;
    public TMP_InputField Damage;
    public TMP_InputField Defense;
    public TMP_InputField MoveSpeed;
    public TMP_InputField AttackSpeed;
    public TMP_InputField HP_Regen;
    public TMP_InputField MP_Regen;
    public TMP_InputField Name;
    public TMP_InputField Description;

    public TMP_Dropdown Monsters;

    public GameObject MonsterPrefab;

    public void LoadMonsters()
    {
        int number = Monsters.value;

        Monsters.ClearOptions();
        // Monster의 옵션에 json 불러오기
        DirectoryInfo directoryInfo = new DirectoryInfo(Application.persistentDataPath + "/Monsters");
        for (int i = 0; i < directoryInfo.GetFiles().Length; i++)
        {
            string data = File.ReadAllText(Application.persistentDataPath + $"/Monsters/{directoryInfo.GetFiles()[i].Name}");
            MonsterData newMonster = JsonUtility.FromJson<MonsterData>(data);
            TMP_Dropdown.OptionData newOption = new TMP_Dropdown.OptionData();
            newOption.text = newMonster.displayName;
            Monsters.options.Add(newOption);
        }
        Monsters.value = (Monsters.options.Count > number - 1 || number == 0) ? -1 : number;
    }

    public void ChangeValues()
    {
        string data = File.ReadAllText(Application.persistentDataPath + $"/Monsters/{Monsters.options[Monsters.value].text}.json");
        MonsterData newMonster = JsonUtility.FromJson<MonsterData>(data);
        Name.text = newMonster.displayName.ToString();
        Description.text = newMonster.description.ToString();
        HP.text = newMonster.hp.ToString();
        MP.text = newMonster.mp.ToString();
        Damage.text = newMonster.damage.ToString();
        Defense.text = newMonster.defense.ToString();
        MoveSpeed.text = newMonster.moveSpeed.ToString();
        AttackSpeed.text = newMonster.attackSpeed.ToString();
        HP_Regen.text = newMonster.hpRegeneration.ToString();
        MP_Regen.text = newMonster.mpRegeneration.ToString();
    }

    public void SaveMonster()
    {
        string data = JsonUtility.ToJson(GetMonster(), true);
        File.WriteAllText(Application.persistentDataPath + $"/Monsters/{GetMonster().displayName}.json", data);
        LoadMonsters();
    }

    public void DeleteMonster()
    {
        if (Monsters.options.Count > 0)
        {
            if (File.Exists(Application.persistentDataPath + $"/Monsters/{Monsters.options[Monsters.value].text}.json"))
            {
                File.Delete(Application.persistentDataPath + $"/Monsters/{Monsters.options[Monsters.value].text}.json");
            }
            LoadMonsters();
        }
    }

    public void InstantiateMonster()
    {
        GameObject newMonster = Instantiate(MonsterPrefab);
        newMonster.GetComponent<Monster>().SetMonsterData(GetMonster());
    }

    private MonsterData GetMonster()
    {
        MonsterData newMonster = new MonsterData();
        newMonster.displayName = Name.text;
        newMonster.description = Description.text;
        float.TryParse(HP.text, out newMonster.hp);
        float.TryParse(MP.text, out newMonster.mp);
        float.TryParse(Damage.text, out newMonster.damage);
        float.TryParse(Defense.text, out newMonster.defense);
        float.TryParse(MoveSpeed.text, out newMonster.moveSpeed);
        float.TryParse(AttackSpeed.text, out newMonster.attackSpeed);
        float.TryParse(HP_Regen.text, out newMonster.hpRegeneration);
        float.TryParse(MP_Regen.text, out newMonster.mpRegeneration);
        return newMonster;
    }

    private void Awake()
    {
        LoadMonsters();

        Monsters.onValueChanged.AddListener(delegate { ChangeValues(); });
    }

    private void Start()
    {
        
    }
}
