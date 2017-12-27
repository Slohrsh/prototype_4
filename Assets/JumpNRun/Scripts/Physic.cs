using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Physic : MonoBehaviour {


    public const float ACCELERATION = 1.41f;
    public Vector3 velocity = Vector3.zero;
    public const float SCATE = 0.41f;

    private Vector3 gravity = Vector3.zero;

    // Use this for initialization
    void Start ()
    {

    }

    public Vector3 CalculateGravity(Vector3 direction, float jumpForce, bool isGrounded)
    {
        if(!isGrounded)
        {
            velocity.y -= jumpForce *ACCELERATION * Time.deltaTime * Time.deltaTime;
        }
        else
        {
            velocity = Vector3.zero;
        }
        /*if(!Mathf.Approximately(direction.x, 0f))
        {
            if (gravity.x > 0)
            {
                gravity.x -= SCATE * Time.deltaTime;
            }
            else
            {
                gravity.x += SCATE * Time.deltaTime;
            }
        }*/

        return direction += velocity;
    }

    // Update is called once per frame
    void Update ()
    {
               
    }
}
