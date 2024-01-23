using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM : MonoBehaviour
{
    public int flag_counter;
    public GameObject[] red_flags;
    public GameObject[] blue_flags;

    public void AddFlag(bool bDoAdd, bool bIsFlagBlue)
    {
        if (bDoAdd)
        {
            flag_counter++;
        }
        else 
        {
            flag_counter--;

            if (bIsFlagBlue)
            {
                foreach(GameObject flag in blue_flags) 
                {
                    if(!flag.activeSelf)
                    {
                        flag.SetActive(true);
                        break;
                    }
                }
            }
            else
            {
                foreach (GameObject flag in red_flags)
                {
                    if (!flag.activeSelf)
                    {
                        flag.SetActive(true);
                        break;
                    }
                }
            }
        }

        Debug.Log(flag_counter);
    }
}
