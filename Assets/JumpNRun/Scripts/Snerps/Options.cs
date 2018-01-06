using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Options : MonoBehaviour {

    public GameObject player;

    //Startvalues
    float walkSpeed = 6f;
    float runSpeed = 12f;

    //Scripts
    public InputController inputController;
    //UI
    public Slider walkSpeedSlider;
    public Slider runSpeedSlider;


    // Use this for initialization
    void Start () {
        //Script holen
        inputController = player.GetComponent<InputController>();

        SetStartValues();

        //UIListenerAnmelden
        walkSpeedSlider.onValueChanged.AddListener(delegate { ChangeWalkSpeedOnSliderValueChange(); });
        runSpeedSlider.onValueChanged.AddListener(delegate { ChangeRunSpeedOnSliderValueChange(); });
    }

    // Update is called once per frame
    void Update () {
		
	}

    private void SetStartValues()
    {
        SetUiStartVluaes();
        SetLogicStartValues();
    }

    private void SetUiStartVluaes()
    {
        walkSpeedSlider.value = walkSpeed;
        runSpeedSlider.value = runSpeed;

    }

    private void SetLogicStartValues()
    {
        ChangeWalkSpeedOnSliderValueChange();
        ChangeRunSpeedOnSliderValueChange();
    }

    public void ChangeWalkSpeedOnSliderValueChange()
    {
        inputController.WalkSpeed = walkSpeedSlider.value;
    }

    public void ChangeRunSpeedOnSliderValueChange()
    {
        inputController.RunSpeed = runSpeedSlider.value;
    }
}
