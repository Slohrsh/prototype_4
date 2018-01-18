using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Air : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController controller =  other.GetComponent<PlayerController>();
            controller.RefilAir();
            Destroy(gameObject);
        }
    }
}
