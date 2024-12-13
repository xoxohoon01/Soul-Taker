using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class SpriteManager : MonoSingleton<SpriteManager>
{
    public SpriteAtlas spriteAtlas;
    private void Start()
    {
        spriteAtlas = Resources.Load<SpriteAtlas>("/SpriteAtlas/SpriteAtlas");
    }

    public Sprite SpriteReturn(string spriteName)
    {
        return spriteAtlas.GetSprite(spriteName);
    }
}
