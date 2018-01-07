using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeBar : MonoBehaviour {

    public PlayerController player;
    public Slider slider;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        slider.value = player.life;
        Debug.Log(slider.value);
	}
}
