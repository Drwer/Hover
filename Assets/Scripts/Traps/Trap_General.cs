using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap_General : MonoBehaviour
{
    protected Player Player_scr;

    private void OnTriggerEnter(Collider other)
    {
        // Check if the entering collider is the player
        if (other.CompareTag("Player"))
        {
            Player_scr = other.GetComponent<Player>();
            ActivateTrap();
        }
    }

    protected virtual void ActivateTrap()
    {

    }
}
