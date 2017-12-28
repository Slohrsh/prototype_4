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
    private Button[] buttons;

    void Start()
    {
        gameManager = GetComponent<GameManager>();
        buttons = GetComponentsInChildren<Button>();
        foreach (Button button in buttons)
        {
            button.onClick.AddListener(() => onButtonClick(button));
        }
    }

    // Update is called once per frame
    void Update ()
    {
        ThirdPersonCamera.enabled = !isFirstPerson;
        FirstPersonCamera.enabled = isFirstPerson;
    }

    public void onButtonClick(Button button)
    {
        Debug.Log("Button has been triggered: " + button.name);
        if(button.name == "ToggleView")
        {
            TogglePersonView();
        }
    }

    private void TogglePersonView()
    {
        isFirstPerson = !isFirstPerson;
        gameManager.View = isFirstPerson == true ? View.FirstPerson : View.ThirdPerson;
        ThirdPersonCamera.enabled = !isFirstPerson;
        FirstPersonCamera.enabled = isFirstPerson;
    }
}
