using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup_Flag : Pickup_General
{
    bool bIsOtherAPlayer = true;

    protected override void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            bIsOtherAPlayer = false;
        }

        base.OnTriggerEnter(other);
    }
    public override void PickUp()
    {
        FindAnyObjectByType<GM>().AddFlag(true, bIsOtherAPlayer);
        bIsOtherAPlayer = false;
        base.PickUp();
    }  
}
