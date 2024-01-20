using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup_Flag : Pickup_General
{
    public override void PickUp()
    {
        GameObject.FindAnyObjectByType<GM>().AddFlag(true);
        base.PickUp();
    }  
}
