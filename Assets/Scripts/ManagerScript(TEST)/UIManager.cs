using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UIManager;

public class UIManager : MonoBehaviour
{

    private static UIManager _instance;
    public static UIManager instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindAnyObjectByType<UIManager>();
                if (_instance == null)
                    Debug.LogError("UIManager not found, can't create singleton object");
            }
            return _instance;
        }
    }

    public enum GameUI
    {
        NONE,
        Loading,
        MainMenu,
        Options
    }
    private Dictionary<GameUI, IGameUI> registeredUIs = new Dictionary<GameUI, IGameUI>();
    private IGameUI currentUI;

    public Transform UIContainer;


    public void RegisterUI(GameUI uiType, IGameUI uiToRegister)
    {
        registeredUIs.Add(uiType, uiToRegister);
    }

    private void Awake()
    {
        foreach (IGameUI enumeratedUI in UIContainer.GetComponentsInChildren<IGameUI>(true))
        {
            RegisterUI(enumeratedUI.GetUIType(), enumeratedUI);
        }

        ShowUI(GameUI.NONE);
    }

    public void ShowUI(GameUI uiType)
    {
        foreach (KeyValuePair<GameUI, IGameUI> kvp in registeredUIs)
        {
            kvp.Value.SetActive(kvp.Key == uiType);
        }
    }


}

