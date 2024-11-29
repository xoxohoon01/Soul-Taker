using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ChooseCharacter : MonoBehaviour
{
    public enum CharacterType { Warrior, Archer, Mage, Rogue }
    public CharacterType type;
    public void Choose()
    {
        Character newCharacter = DatabaseManager.Instance.Parse<Character>(Database.Characters.CharactersList[(int)type]);
        CharacterCreator.Instance.nowCharacter = newCharacter;
        CharacterCreator.Instance.CreateNewCharacter();
    }
}
