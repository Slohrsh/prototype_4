using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour {

    public GameObject TutorialImagePrefab;
    public string Name;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (TutorialImagePrefab != null)
            {
                GameManager.Instance.ShowTutorial(TutorialImagePrefab, Name);
            }
        }
    }
}
