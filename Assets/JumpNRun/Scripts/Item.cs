using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour {

    public string Name;
    public int Amount = 1;
    public Sprite sprite;
    public GameObject droppableObject;
    public GameObject TutorialImagePrefab;

    public Inventory.BenefitOfItem Benefit;

    public bool HasItem()
    {
        return Amount > 0;
    }

    // Use this for initialization
    void Start ()
    {
		if(droppableObject == null)
        {
            droppableObject = GetComponent<GameObject>();
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Inventory inventory = other.GetComponent<Inventory>();
            inventory.Add(this.gameObject);
            if(TutorialImagePrefab != null)
            {
                GameManager.Instance.ShowTutorial(TutorialImagePrefab, Name);
            }
            gameObject.SetActive(false);
        }
    }
}
