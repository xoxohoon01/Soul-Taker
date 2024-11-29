using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCreator : MonoSingleton<CharacterCreator>
{
    public Character nowCharacter;
    public GameObject characterObject;

    public void CreateNewCharacter()
    {
        GameObject newCharacter = Instantiate(characterObject, new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0));
        newCharacter.GetComponent<Player>().Character = nowCharacter;
    }
}
