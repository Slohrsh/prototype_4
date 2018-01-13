using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public View view { get; set; }
    private float deltaTime = 0;
    internal bool isGameOver;
    internal bool isGamePause = false;
    public GameObject ResumeButton;

    private Canvas canvas;
    private List<String> shownTutorials = new List<String>();
    private GameObject actualTutorial;

    public static GameManager Instance;

    void Start ()
    {
        canvas = GetComponent<Canvas>();
		if(Instance == null)
        {
            Instance = this;
        }
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

    internal void ShowTutorial(GameObject tutorialImagePrefab, String name)
    {
        if(!shownTutorials.Contains(name))
        {
            pauseGame();
            shownTutorials.Add(name);
            actualTutorial = Instantiate(tutorialImagePrefab, canvas.transform);
            actualTutorial.SetActive(true);

            ResumeButton.SetActive(true);
        }
    }

    public void pauseGame()
    {
        Time.timeScale = 0;
        isGamePause = true;
    }

    public void resumeGame()
    {
        Destroy(actualTutorial.gameObject);
        Time.timeScale = 1;
        isGamePause = false;
    }

    internal void GameOver()
    {
        view = View.ThirdPerson;
        isGameOver = true;
    }
}
