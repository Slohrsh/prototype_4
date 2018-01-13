using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaterTimer : MonoBehaviour {

    public GameObject player;
    public Slider slider;
    public GameObject parent;

    private PlayerController playerController;
    // Use this for initialization
    void Start()
    {
        playerController = player.GetComponent<PlayerController>();
        parent.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(slider.value != playerController.actualWaterTime)
        {
            parent.SetActive(true);
        }
        else
        {
            parent.SetActive(false);
        }
        slider.value = playerController.actualWaterTime;

    }
}
