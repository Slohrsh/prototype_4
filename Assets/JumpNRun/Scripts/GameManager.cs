using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour {

    public View view { get; set; }
    public bool isGameOver;
    private float deltaTime = 0;

	void Start ()
    {
		
	}
	
	void Update ()
    {
        if(isGameOver)
        {
            deltaTime += Time.deltaTime;
            if(deltaTime > 2)
            {
                SceneManager.LoadScene(0);
            }
        }
	}
    internal void GameOver()
    {
        view = View.ThirdPerson;
        isGameOver = true;
    }
}
