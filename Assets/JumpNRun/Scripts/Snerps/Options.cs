using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Options : MonoBehaviour {

    public PlayerController player;
    public Slider JumpHeight;


    void Start () {
        JumpHeight.value = player.JumpForce;
        JumpHeight.onValueChanged.AddListener(delegate { ChangeJumpHeigth(); });
    }

    void Update () {
		
	}

    public void ChangeJumpHeigth()
    {
        player.JumpForce = JumpHeight.value;
    }
}
