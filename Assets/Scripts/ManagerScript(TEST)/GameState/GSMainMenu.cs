using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GSMainMenu : MonoBehaviour, IGameState
{
    public void Playclik()
    {
        Debug.Log("Ho Premuto Play");
        SceneManager.LoadScene("Scenes/TestScene");
    }

    public void OnStateEnter()
    {

    }
    public void OnStateExit() 
    { 

    }
    public void OnStateUpdate()
    {

    }

}


