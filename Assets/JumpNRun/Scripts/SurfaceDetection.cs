using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurfaceDetection : MonoBehaviour {

    private float friction = 3f;
    private string tag = "Surface";
    private bool isFirstEntered = false;
    internal bool IsFirstEntered
    {
        get
        {
            bool tmp = isFirstEntered;
            isFirstEntered = false;
            return tmp;
        }
        set
        {
            isFirstEntered = value;
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}

    public float GetFriction()
    {
        return friction;
    }

    public string GetTag()
    {
        return tag;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag(tag) && !other.gameObject.CompareTag("Player"))
        {
            isFirstEntered = true;
        }
        Surface surface = other.gameObject.GetComponent<Surface>();
        if(surface != null)
        {
            friction = surface.friction;
            tag = surface.gameObject.tag;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag(tag))
        {
            tag = "Surface";
        }
    }

}
