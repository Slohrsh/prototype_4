using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour {

    public int Amount = 1;
    public Sprite sprite;
    public string Name { get { return GetComponent<GameObject>().tag; } }

    public bool HasItem()
    {
        return Amount > 0;
    }

    // Use this for initialization
    void Start () {
		
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
            gameObject.SetActive(false);
        }
    }
}
