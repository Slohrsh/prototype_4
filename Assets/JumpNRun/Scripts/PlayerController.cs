using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour, Movable
{

    public Animator anim;
    public Physic physic;
    public float Gravity = 1.41f;
    public float JumpForce = 0.5f;

    private CharacterController controller = null;
    private bool jump;
    private float walkDirection;
    private Vector3 moveDirection;
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
        controller = GetComponent<CharacterController>();
        if (controller == null)
        {
            Debug.LogError("Missing Character Controller");
        }
        controller.detectCollisions = true;
        physic = GetComponent<Physic>();
    }

    // Update is called once per frame
    void Update()
    {
        moveDirection = Math.Abs(walkDirection) * this.transform.forward * Time.deltaTime;

        if (walkDirection > 0f)
        {
            this.transform.rotation = Quaternion.Euler(0f, 90f, 0f);
        }
        else if (walkDirection < 0f)
        {
            this.transform.rotation = Quaternion.Euler(0f, -90f, 0f);
        }

        if (!controller.isGrounded)
        {
            gravity += new Vector3(0f, -Gravity, 0f) * Time.deltaTime;
        }
        else
        {
            if (jump)
            {
                gravity = Vector3.zero;
                gravity.y = JumpForce;
                jump = false;
            }
        }
        moveDirection += gravity;
        controller.Move(moveDirection);
        UpdateAnimation();
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "Death")
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
        if (Mathf.Approximately(walkDirection, 0f))
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
        switch (state)
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


    public void Move(float value)
    {
        walkDirection = value;
    }

    public void Jump(float value)
    {
        if(controller.isGrounded)
        {
            jump = true;
        }
    }
}