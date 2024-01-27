using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UIMainMenu : MonoBehaviour
{
    public UIManager.GameUI UIType;

    public UIManager.GameUI GetUIType()
    {
        return UIType;
    }

    public void Init()
    {

    }

    public void SetActive(bool active)
    {
        gameObject.SetActive(active);
    }
}

