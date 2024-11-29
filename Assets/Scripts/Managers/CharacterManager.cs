using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoSingleton<CharacterManager>
{
    private Player player;
    public Player Player
    {
        get { return player; }
        set { player = value; }
    }
}
