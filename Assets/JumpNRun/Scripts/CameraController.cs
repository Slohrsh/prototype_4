using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour {

    // Use this for initialization
    public Camera ThirdPersonCamera;
    public Camera FirstPersonCamera;
    public GameManager gameManager;

    private bool isFirstPerson = false;


    void Start()
    {
        gameManager = GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update ()
    {
        ThirdPersonCamera.enabled = !isFirstPerson;
        FirstPersonCamera.enabled = isFirstPerson;
    }

    public void TogglePersonView()
    {
        isFirstPerson = !isFirstPerson;
        gameManager.View = isFirstPerson == true ? View.FirstPerson : View.ThirdPerson;
        ThirdPersonCamera.enabled = !isFirstPerson;
        FirstPersonCamera.enabled = isFirstPerson;
    }
}
