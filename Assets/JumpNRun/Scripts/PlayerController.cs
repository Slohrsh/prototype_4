using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour, Movable
{

    public Animator anim;
    public float Gravity = 1.41f;
    public float JumpForce = 0.5f;
    public GameManager gameManager;

    private CharacterController controller = null;
    private bool jump;
    private float walkDirection;
    private Vector3 moveDirection;
    private Vector3 gravity = Vector3.zero;
    private float rotation = 90f;

    private int life = 3;

    private LifeIndicator lifeIndicator;

    private enum AnimState
    {
        Idle,
        Running,
        Jumping,
    };

    void Start()
    {
        lifeIndicator = GetComponent<LifeIndicator>();
        controller = GetComponent<CharacterController>();
        controller.detectCollisions = true;
    }

    void Update()
    {
        CheckIfDead();

        if(gameManager.View == View.ThirdPerson)
        {
            moveDirection = HandleThirdPersonInput();
        }
        else
        {
            moveDirection = HandleFirstPersonInput();
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

    private void CheckIfDead()
    {
        if(life <= 0)
        {
            gameManager.GameOver();
        }
    }

    private Vector3 HandleFirstPersonInput()
    {
        Vector3 direction = walkDirection * this.transform.forward * Time.deltaTime;
        return direction;
    }

    private Vector3 HandleThirdPersonInput()
    {
        Vector3 direction = Math.Abs(walkDirection) * this.transform.forward * Time.deltaTime;
        if (walkDirection > 0f)
        {
            this.transform.rotation = Quaternion.Euler(0f, 90f, 0f);
        }
        else if (walkDirection < 0f)
        {
            this.transform.rotation = Quaternion.Euler(0f, -90f, 0f);
        }
        return direction;
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "Death")
        {
            gameManager.GameOver();
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

    public void Damage()
    {
        life--;
        switch(life)
        {
            case 3:
                lifeIndicator.SetLifeIndicatorTexture(LifeIndicator.Life.Green);
                break;
            case 2:
                lifeIndicator.SetLifeIndicatorTexture(LifeIndicator.Life.Yellow);
                break;
            case 1:
                lifeIndicator.SetLifeIndicatorTexture(LifeIndicator.Life.Red);
                break;
        }
    }


    public void Rotate(float value)
    {
        if(value == 1)
        {
            rotation += 90;
            this.transform.rotation = Quaternion.Euler(0f, rotation, 0f);
        }
        else
        {
            rotation -= 90;
            this.transform.rotation = Quaternion.Euler(0f, rotation, 0f);
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