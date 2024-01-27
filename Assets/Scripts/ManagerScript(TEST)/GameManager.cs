using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    public static GameManager instance
    {
        get
        {
            
            return _instance;
        }
    }


  


    private void Awake()
    {
        GameStateManager.instance.RegisterState(GameStateManager.GameStates.Loading, new GSLoading());
        GameStateManager.instance.RegisterState(GameStateManager.GameStates.MainMenu, new GSMainMenu());
        GameStateManager.instance.RegisterState(GameStateManager.GameStates.GamePlay, new GSMainMenu());
        GameStateManager.instance.RegisterState(GameStateManager.GameStates.Win, new GSMainMenu());
        GameStateManager.instance.RegisterState(GameStateManager.GameStates.Lose, new GSMainMenu());
       
        


    }
    void Start()
    {
        GameStateManager.instance.SetCurrentGameState(GameStateManager.GameStates.MainMenu);
    }
}