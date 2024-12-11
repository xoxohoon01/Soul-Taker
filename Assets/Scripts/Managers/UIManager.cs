using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoSingleton<UIManager>
{
    [SerializeField] private Transform canvas;

    public static float ScreenWidth = 1920;
    public static float ScreenHeight = 1080;
    private Dictionary<string, UIBase> uiDictionary = new Dictionary<string, UIBase>();

    public T Show<T>(params object[] param) where T : UIBase
    {
        string uiName = typeof(T).ToString();
        if (uiDictionary.TryGetValue(uiName, out UIBase existingUI))
        {
            existingUI.Opened(param);
            return (T)existingUI;
        }
        UIBase go = Resources.Load<UIBase>("UI/" + uiName);
        if (go == null) 
        {
            return null;
        }
        var ui = Load<T>(go, uiName);
        uiDictionary.Add(uiName, ui);
        ui.Opened(param);

        return (T)ui;
    }

    private T Load<T>(UIBase prefab, string uiName) where T : UIBase
    {
        GameObject newUIObject = Instantiate(prefab.gameObject, canvas);
        newUIObject.name = uiName;

        UIBase ui = newUIObject.GetComponent<UIBase>();
        ui.canvas = canvas.GetComponent<Canvas>();
        ui.canvas.sortingOrder = uiDictionary.Count;
        return (T)ui;
    }

    public void Hide<T>() where T : UIBase
    {
        string uiName = typeof(T).ToString();

        Hide(uiName);
    }

    public void Hide(string uiName)
    {
        if (uiDictionary.TryGetValue(uiName, out UIBase go))
        {
            uiDictionary.Remove(uiName);
            Destroy(go.gameObject);
        }
    }

    private void Start()
    {
        DontDestroyOnLoad(canvas);
    }
}

