using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cooldown : MonoBehaviour
{
	public GameObject player;
	public Slider slider;

	private PlayerController playerController;
	// Use this for initialization
	void Start ()
	{
		playerController = player.GetComponent<PlayerController>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		slider.value = playerController.endurance;
		if (slider.value <= 0)
		{
			slider.value = 3;
		}
	}
}
