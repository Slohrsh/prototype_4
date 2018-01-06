using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseHover : MonoBehaviour
{
    public GameObject picture;
    private RectTransform canvasRectTransform;
    private bool pictureShown = false;

    // Use this for initialization
    void Start()
    {
        Canvas canvas = GetComponentInParent<Canvas>();
        if (canvas != null)
        {
            canvasRectTransform = canvas.transform as RectTransform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;


        if (Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0)
        {
            foreach (Transform child in gameObject.transform)
            {
                Destroy(child.gameObject);
            }

            if (Physics.Raycast(ray, out hit, 1000f, LayerMask.GetMask("Default")))
            {
                Debug.Log(hit.collider.tag);
                if (hit.collider.tag == "Lift")
                {
                    var pictureInstance = Instantiate(picture, new Vector3(transform.position.x + 60,
                        transform.position.y - 60,
                        transform.position.z), Quaternion.identity);

                    pictureInstance.transform.parent = gameObject.transform;
                    gameObject.transform.position = Input.mousePosition;
                }
            }
        }
    }
}