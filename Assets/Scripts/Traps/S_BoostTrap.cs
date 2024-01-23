    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

public class S_BoostTrap : Trap_General
{
    public float push_force;
    public float push_time;
    public float push_duration;

    protected override void ActivateTrap()
    {
        StartCoroutine(Boost_Player());
    }

    IEnumerator Boost_Player()
    {
        // Push the player forward
        Player_scr.rb2d.AddForce(Vector3.forward * push_force);

        yield return new WaitForSeconds(push_time);

        Player_scr.SpeedManager(Player_scr.speed_max);

        yield return new WaitForSeconds(1.5f);

        Player_scr.SpeedManager(Player_scr.speed - Player_scr.speed_max);
    }
}
