using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour {

    public Movable movable;
    public float WalkSpeed = 6f;
    public float RunSpeed = 12f;
    public float JumpForce = 5f;

    private Vector3 move = Vector3.zero;
    
    // Use this for initialization
    void Start () {
        movable = GetComponent<Movable>();
		if(movable == null)
        {
            Debug.LogError("Movable Controller not found");
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        move.x = Input.GetAxis("Horizontal");

        if (Input.GetKey(KeyCode.LeftShift))
        {
            move *= RunSpeed;
        }
        else
        {
            move *= WalkSpeed;
        }

        if (Input.GetButtonDown("Jump"))
        {
            movable.Jump(JumpForce);
        }
        movable.Move(move.x);
    }
}
