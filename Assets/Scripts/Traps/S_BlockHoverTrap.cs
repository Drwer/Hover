using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_BlockHoverTrap : Trap_General
{

    protected override void ActivateTrap()
    {
        // Implement the logic to freeze player movement
        Debug.Log("Player movement frozen!");

        Player_scr.speed = 0;
        Invoke("UnblockPlayer", 6);
    }

    private void UnblockPlayer()
    {
        // Implement the logic to unfreeze player movement
        Debug.Log("Player movement unfrozen!");

        Player_scr.speed = Player_scr.speed_normal;
    }
}