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
            newOption.text = newMonster.DisplayName;
            Monsters.options.Add(newOption);
        }
        Monsters.value = (Monsters.options.Count > number - 1 || number == 0) ? -1 : number;
    }

    public void ChangeValues()
    {
        string data = File.ReadAllText(Application.persistentDataPath + $"/Monsters/{Monsters.options[Monsters.value].text}.json");
        MonsterData newMonster = JsonUtility.FromJson<MonsterData>(data);
        Name.text = newMonster.DisplayName.ToString();
        Description.text = newMonster.Description.ToString();
        HP.text = newMonster.HP.ToString();
        MP.text = newMonster.MP.ToString();
        Damage.text = newMonster.Damage.ToString();
        Defense.text = newMonster.Defense.ToString();
        MoveSpeed.text = newMonster.MoveSpeed.ToString();
        AttackSpeed.text = newMonster.AttackSpeed.ToString();
        HP_Regen.text = newMonster.HPRegeneration.ToString();
        MP_Regen.text = newMonster.MPRegeneration.ToString();
    }

    public void SaveMonster()
    {
        string data = JsonUtility.ToJson(GetMonster(), true);
        File.WriteAllText(Application.persistentDataPath + $"/Monsters/{GetMonster().DisplayName}.json", data);
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
        newMonster.GetComponent<Monster>().Status.InitializeStatus(GetMonster());
    }

    private MonsterData GetMonster()
    {
        MonsterData newMonster = new MonsterData();
        newMonster.DisplayName = Name.text;
        newMonster.Description = Description.text;
        float.TryParse(HP.text, out newMonster.HP);
        float.TryParse(MP.text, out newMonster.MP);
        float.TryParse(Damage.text, out newMonster.Damage);
        float.TryParse(Defense.text, out newMonster.Defense);
        float.TryParse(MoveSpeed.text, out newMonster.MoveSpeed);
        float.TryParse(AttackSpeed.text, out newMonster.AttackSpeed);
        float.TryParse(HP_Regen.text, out newMonster.HPRegeneration);
        float.TryParse(MP_Regen.text, out newMonster.MPRegeneration);
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
