using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lift : MonoBehaviour {

    public float height;

    private Vector3 initialPosition;
    private bool isActive = false;
    private bool isMovingUp = false;
    private float actualHeight = 0;

	// Use this for initialization
	void Start () {
        initialPosition = this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if(isActive)
        {
            Debug.Log("Active");
            if(isMovingUp)
            {
                if(actualHeight < height)
                {
                    actualHeight += Time.deltaTime * 1;
                    transform.position += new Vector3(0, Time.deltaTime * 1, 0);
                }
                else
                {
                    isActive = false;
                }
            }else
            {
                if(actualHeight > 0f)
                {
                    actualHeight -= Time.deltaTime * 1;
                    transform.position -= new Vector3(0, Time.deltaTime * 1, 0);
                }
                else
                {
                    isActive = false;
                }
            }
        }
	}

    public void OnMouseDown()
    {
        Activate();
    }

    public void Activate()
    {
        isActive = true;
        isMovingUp = !isMovingUp;
    }
}
