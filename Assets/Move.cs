using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private Rigidbody rb;
    public GameObject player_camera;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        int if_speed_x = 0, if_speed_z = 0;
        var ForwardDirection = player_camera.transform.forward;
        var RightDirection = player_camera.transform.right;

        if (Input.GetKey(KeyCode.W))
        {
            if_speed_z = 1;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            if_speed_z = -1;
        }
        else 
        {
            if_speed_z = 0;
        }
        if (Input.GetKey(KeyCode.D))
        {
            if_speed_x = 1;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            if_speed_x = -1;
        }
        else 
        {
            if_speed_x = 0;
        }
        rb.velocity = (if_speed_x * RightDirection + if_speed_z * ForwardDirection) * speed;
    }
}