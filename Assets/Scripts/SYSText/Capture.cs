using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public enum Grade
{
    Normal,
    Uncommon,
    Rare,
    Legend
}

public enum Size
{
    POT64,
    POT128,
    POT256,
    POT512,
    POT1024
}

public class Capture : MonoBehaviour
{
    public Camera cam;
    public RenderTexture renderTexture;
    public Image image;
    
    public Grade grade;
    public Size size;
    
    public GameObject[] objects;
    private int nowCount = 0;

    private void Start()
    {
        cam = Camera.main;
        SettingColor();
        SettingSize();
    }

    public void Create()
    {
        StartCoroutine(CaptureImage());
    }

    IEnumerator CaptureImage()
    {
        yield return null;
        
        Texture2D texture = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.ARGB32, false, true);
        RenderTexture.active = renderTexture;
        texture.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0);

        yield return null;
        
        var data = texture.EncodeToPNG();
        string name = "Thumbnail";
        string extention = ".png";
        string path = Application.persistentDataPath + "/Thumbnail/";
        
        Debug.Log(path);
        
        if(!Directory.Exists(path)) Directory.CreateDirectory(path);
        
        File.WriteAllBytes(path + name + extention, data);

        yield return null;
    }

    public void AllCreate()
    {
        StartCoroutine(AllCaptureImage());
    }

    IEnumerator AllCaptureImage()
    {
        while (nowCount < objects.Length)
        {
            var nowObject = Instantiate(objects[nowCount].gameObject);
            
            yield return null;
            
            Texture2D texture = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.ARGB32, false, true);
            RenderTexture.active = renderTexture;
            texture.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0);

            yield return null;
            
            var data = texture.EncodeToPNG();
            string name = $"Thumbnail_{objects[nowCount].gameObject.name}";
            string extention = ".png";
            string path = Application.persistentDataPath + "/Thumbnail/";
        
            Debug.Log(path);
        
            if(!Directory.Exists(path)) Directory.CreateDirectory(path);
        
            File.WriteAllBytes(path + name + extention, data);
            
            yield return null;
            
            DestroyImmediate(nowObject);
            nowCount++;
            
            yield return null;
        }
    }

    private void SettingColor()
    {
        switch (grade)
        {
            case Grade.Normal:
                cam.backgroundColor = Color.white;
                image.color = Color.white;
                break;
            case Grade.Uncommon:
                cam.backgroundColor = Color.green;
                image.color = Color.green;
                break;
            case Grade.Rare:
                cam.backgroundColor = Color.blue;
                image.color = Color.blue;
                break;
            case Grade.Legend:
                cam.backgroundColor = Color.yellow;
                image.color = Color.yellow;
                break;
            default:
                break;
        }
    }

    private void SettingSize()
    {
        switch (size)
        {
            case Size.POT64:
                renderTexture.width = 64;
                renderTexture.height = 64;
                break;
            case Size.POT128:
                renderTexture.width = 128;
                renderTexture.height = 128;
                break;
            case Size.POT256:
                renderTexture.width = 256;
                renderTexture.height = 256;
                break;
            case Size.POT512:
                renderTexture.width = 512;
                renderTexture.height = 512;
                break;
            case Size.POT1024:
                renderTexture.width = 1024;
                renderTexture.height = 1024;
                break;
            default:
                break;
        }
    }
}
