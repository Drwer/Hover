using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_BlockHoverTrap : MonoBehaviour
{
   
    private bool isPlayerInside = false;
    private float blockDuration;
    private Player characterMovement; // Assuming you have a PlayerMovement script

    private void Start()
    {
        // Assuming the player has a PlayerMovement script attached to the same GameObject
        characterMovement = GetComponent<Player>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the entering collider is the player
        if (other.CompareTag("Player"))
        {
            // Block the player and start the timer
            BlockPlayer();
        }
    }

    private void BlockPlayer()
    {
        // Implement the logic to freeze player movement
        Debug.Log("Player movement frozen!");

        characterMovement.speed = 0;
        characterMovement.turning_speed = 0;
        Invoke("UnblockPlayer", blockDuration);
    }

    private void UnblockPlayer()
    {
        // Implement the logic to unfreeze player movement
        Debug.Log("Player movement unfrozen!");

        characterMovement.speed = characterMovement.speed_normal;
        characterMovement.turning_speed = characterMovement.turning_speed_normal;
    }
}