using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    public Animator anim;
    public float WalkSpeed = 6f;
    public float RunSpeed = 12f;
    public float Gravity = 1.41f;
    public float JumpForce = 0.5f;


    private Vector3 move = Vector3.zero;
    private bool jump = false;
    private CharacterController characterController = null;
    private Vector3 gravity = Vector3.zero;

    private enum AnimState
    {
        Idle,
        Running,
        Jumping,
    };

    // Use this for initialization
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        if(characterController == null)
        {
            Debug.LogError("Missing Character Controller"); 
        }
        characterController.detectCollisions = true; 
    }

    // Update is called once per frame
    void Update()
    {
        move = Math.Abs(Input.GetAxis("Horizontal")) * this.transform.forward * Time.deltaTime;

        if(Input.GetAxis("Horizontal") > 0f)
        {
            this.transform.rotation = Quaternion.Euler(0f, 90f, 0f);
        }
        else if(Input.GetAxis("Horizontal") < 0f)
        {
            this.transform.rotation = Quaternion.Euler(0f, -90f, 0f);
        }
        if(Input.GetKey(KeyCode.LeftShift))
        {
            move *= RunSpeed;
        }
        else
        {
            move *= WalkSpeed;
        }

        if(!characterController.isGrounded)
        {
            gravity += new Vector3(0f, -Gravity, 0f) * Time.deltaTime;
        }
        else
        {
            if(jump)
            {
                gravity = Vector3.zero;
                gravity.y = JumpForce;
                jump = false;
            }
        }

        if(Input.GetButtonDown("Jump") && characterController.isGrounded)
        {
            jump = true;
        }

        move += gravity;

        characterController.Move(move);
        UpdateAnimation();
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.gameObject.tag == "Death")
        {
            SceneManager.LoadScene(0);
        }
    }

    private void UpdateAnimation()
    {
        if (jump)
        {
            SwitchAnim(AnimState.Jumping);
        }
        if (Mathf.Approximately(move.x, 0f))
        {
            SwitchAnim(AnimState.Idle);
        }
        else
        {
            SwitchAnim(AnimState.Running);
        }
    }

    private void SwitchAnim(AnimState state)
    {
        switch(state)
        {
            case AnimState.Idle:
                anim.SetBool("isRunning", false);
                anim.SetBool("isIdle", true);
                break;
            case AnimState.Running:
                anim.SetBool("isRunning", true);
                anim.SetBool("isIdle", false);
                break;
            case AnimState.Jumping:
                anim.SetTrigger("isJumping");
                break;
        }
    }
}
