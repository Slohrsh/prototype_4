using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour {

    public float force;
    private Enemy enemy;

	// Use this for initialization
	void Start () {
        enemy = GetComponentInParent<Enemy>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(!enemy.isDead)
        {
            if (other.CompareTag("Player"))
            {
                PlayerController controller = other.GetComponentInParent<PlayerController>();
                controller.Bounce(force);
                enemy.Death();
            }
        }
    }
}
