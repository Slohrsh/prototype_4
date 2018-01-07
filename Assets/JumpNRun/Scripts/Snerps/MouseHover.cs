using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseHover : MonoBehaviour
{
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

            if (Physics.Raycast(ray, out hit, 1000f, LayerMask.GetMask("Clickable")))
            {
                Debug.Log(hit.collider.tag);

                Clickable clickable = hit.transform.GetComponent<Clickable>();

                if(clickable != null)
                {
                    var pictureInstance = Instantiate(clickable.Picture, new Vector3(transform.position.x + 30,
                    transform.position.y - 30,
                    transform.position.z), Quaternion.identity);

                    pictureInstance.transform.parent = gameObject.transform;
                    gameObject.transform.position = Input.mousePosition;
                }
            }
        }
    }
}