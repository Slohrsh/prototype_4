using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeIndicator : MonoBehaviour {

    public Canvas Reference;
    public GameObject LifeIndicatorPrefab;
    private GameObject lifeIndicator;
    // Use this for initialization
    void Start () {
        lifeIndicator = Instantiate(LifeIndicatorPrefab, Reference.transform);
        lifeIndicator.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
        lifeIndicator.transform.position = this.transform.position + new Vector3(0f,3f);
	}
}
