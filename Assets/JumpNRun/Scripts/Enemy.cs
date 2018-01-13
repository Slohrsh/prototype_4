using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public bool isDead = false;

    private Animator anim;
    private bool isMovingRight = true;
    private Vector3 direction;
    private bool triggered = false;
    private Transform reference;


    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
    }

    internal void RunToReference(Transform transform)
    {
        triggered = true;
        reference = transform;
    }

    // Update is called once per frame
    void Update () {
        if(!isDead)
        {
            direction = this.transform.forward * Time.deltaTime;
            if (triggered)
            {
                MoveToReference();
                direction *= 4f;
            }
            else
            {
                Move();
            }
            transform.position += direction;
        }
	}

    private void MoveToReference()
    {
        anim.SetBool("Run", true);
        float moveDirection = reference.position.x - transform.position.x;
        if(moveDirection < 0)
        {
            isMovingRight = true;
            this.transform.rotation = Quaternion.Euler(0f, -90f, 0f);
        }
        else
        {
            isMovingRight = false;
            this.transform.rotation = Quaternion.Euler(0f, 90f, 0f);
        }
    }

    private void Move()
    {
        anim.SetBool("Run", false);
        if (isMovingRight)
        {
            this.transform.rotation = Quaternion.Euler(0f, -90f, 0f);
        }
        else
        {
            this.transform.rotation = Quaternion.Euler(0f, 90f, 0f);
        }
    }

    internal void Death()
    {
        anim.SetTrigger("isDead");
        isDead = true;
        Invoke("Destroy", 1);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Border"))
        {
            triggered = false;
            isMovingRight = !isMovingRight;
        }
    }

    internal void Attack()
    {
        anim.SetTrigger("Attack");
    }

    private void Destroy()
    {
        Destroy(this.gameObject);
    }
}
