using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inseguimento : MonoBehaviour
{
    public Transform player;
    public float enemySpeed;
    public float EnemyDistance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float Distance = Vector3.Distance( player.transform.position, transform.position);
        Debug.Log(Distance);

        if (Distance >= EnemyDistance)
        {
            transform.LookAt(player);
            transform.position= Vector3.Lerp(transform.position, player.transform.position,enemySpeed);
        }
    }
}
