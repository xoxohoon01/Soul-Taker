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
        Character newCharacter = new Character();
        newCharacter.HP = Database.Characters.CharactersMap[(int)type].HP;
        newCharacter.MP = Database.Characters.CharactersMap[(int)type].HP;
        newCharacter.Damage = Database.Characters.CharactersMap[(int)type].HP;
        newCharacter.Defense = Database.Characters.CharactersMap[(int)type].HP;
        newCharacter.MoveSpeed = Database.Characters.CharactersMap[(int)type].HP;
        newCharacter.AttackSpeed = Database.Characters.CharactersMap[(int)type].HP;
        newCharacter.HPRegeneration = Database.Characters.CharactersMap[(int)type].HP;
        newCharacter.MPRegeneration = Database.Characters.CharactersMap[(int)type].HP;
        newCharacter.DrainLife = Database.Characters.CharactersMap[(int)type].HP;
        newCharacter.HPPerLevel = Database.Characters.CharactersMap[(int)type].HP;
        newCharacter.MPPerLevel = Database.Characters.CharactersMap[(int)type].HP;
        newCharacter.DamagePerLevel = Database.Characters.CharactersMap[(int)type].HP;
        newCharacter.DefensePerLevel = Database.Characters.CharactersMap[(int)type].HP;
        newCharacter.HPRegenerationPerLevel = Database.Characters.CharactersMap[(int)type].HP;
        newCharacter.MPRegenerationPerLevel = Database.Characters.CharactersMap[(int)type].HP;
        CharacterCreator.Instance.nowCharacter = newCharacter;
        CharacterCreator.Instance.CreateNewCharacter();
    }
}
