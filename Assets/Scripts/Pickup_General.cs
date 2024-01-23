using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup_General : MonoBehaviour
{
    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PickUp();
        }
    }

    public virtual void PickUp()
    {
        gameObject.SetActive(false);
    }
}
