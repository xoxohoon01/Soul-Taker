using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using DataTable;

public class ChooseCharacter : MonoBehaviour
{
    public enum CharacterType { Warrior, Archer, Mage, Rogue }
    public CharacterType type;
    public void Choose()
    {
        CharacterData newCharacter = DatabaseManager.Instance.Character.GetCharacter()[(int)type];
        CharacterCreator.Instance.nowCharacter = newCharacter;
        CharacterCreator.Instance.CreateNewCharacter();
    }
}
