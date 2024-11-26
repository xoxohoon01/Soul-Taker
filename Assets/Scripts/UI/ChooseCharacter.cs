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
        switch (type)
        {
            case CharacterType.Warrior:
                CharacterCreator.Instance.nowCharacter = DatabaseManager.Instance.CharacterDB[0];
                break;
            case CharacterType.Archer:
                CharacterCreator.Instance.nowCharacter = DatabaseManager.Instance.CharacterDB[1];
                break;
            case CharacterType.Mage:
                CharacterCreator.Instance.nowCharacter = DatabaseManager.Instance.CharacterDB[2];
                break;
            case CharacterType.Rogue:
                CharacterCreator.Instance.nowCharacter = DatabaseManager.Instance.CharacterDB[3];
                break;
        }
        CharacterCreator.Instance.CreateNewCharacter();
    }
}
