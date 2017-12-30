using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeIndicator : MonoBehaviour {

    public Canvas Reference;
    public GameObject LifeIndicatorPrefab;
    public enum Life { Green, Yellow, Red}
    public Sprite lifeIndicatorGreen;
    public Sprite lifeIndicatorYellow;
    public Sprite lifeIndicatorRed;

    private GameObject lifeIndicator;
    // Use this for initialization
    void Start () {
        lifeIndicator = Instantiate(LifeIndicatorPrefab, Reference.transform);
        Image image = lifeIndicator.GetComponent<Image>();
        image.sprite = lifeIndicatorGreen;
        lifeIndicator.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
        lifeIndicator.transform.position = this.transform.position + new Vector3(0f,3f);
	}

    public void SetLifeIndicatorTexture(Life life)
    {
        Image image = lifeIndicator.GetComponent<Image>();
        switch (life)
        {
            case Life.Green:
                image.sprite = lifeIndicatorGreen;
                break;
            case Life.Yellow:
                image.sprite = lifeIndicatorYellow;
                break;
            case Life.Red:
                image.sprite = lifeIndicatorRed;
                break;
        }
    }
}
