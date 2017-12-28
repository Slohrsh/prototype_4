using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour {

    public int Amount;
    public Image Texture;
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
            Destroy(this.gameObject);
        }
    }
}
