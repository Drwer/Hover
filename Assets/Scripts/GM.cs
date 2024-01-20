using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM : MonoBehaviour
{
    public int flag_counter;

    public void AddFlag(bool doAdd)
    {
        if (doAdd)
        {
            flag_counter++;
        }
        else 
        {
            flag_counter--; 
        }

        Debug.Log(flag_counter);
    }
}
