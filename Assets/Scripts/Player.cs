using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float speed_max;
    public float speed_normal;
    public float turning_speed;
    public float turning_speed_normal;
    public float distance_from_ground;
    public float angle_speed;
    public Rigidbody rb2d;

    private void Awake()
    {
        speed = speed_normal;
        turning_speed = turning_speed_normal;
        rb2d = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        GroundCheck();
    }

    private void FixedUpdate()
    {
        Move(Input.GetAxis("Vertical"));
    }

    public void Move(float Ver)
    {
        transform.Translate(Vector3.forward * Ver * speed * Time.fixedDeltaTime);
        transform.Rotate(0, Input.GetAxis("Horizontal") * turning_speed * Time.fixedDeltaTime, 0);
    }

    public void SpeedManager(float speed_mod)
    {
        speed = Mathf.Clamp(speed + speed_mod, 0, speed_max);
    }

    public void GroundCheck()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, Vector3.down, out hit))
        {
            if (hit.distance < distance_from_ground)
            {
                transform.Translate(Vector3.up * (distance_from_ground - hit.distance));
                rb2d.velocity = new Vector3(rb2d.velocity.x, 0, rb2d.velocity.z);

                Debug.Log("Player not far enought from ground");
            }
        }
    }
}
