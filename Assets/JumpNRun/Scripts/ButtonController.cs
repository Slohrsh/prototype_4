using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour {

    public InventoryManager inventoryManager;
    public Sprite defaultSprite;

    private Button[] buttons;
    private CameraController cameraController;

    void Start () {
        buttons = GetComponentsInChildren<Button>();
        foreach (Button button in buttons)
        {
            button.onClick.AddListener(() => onButtonClick(button));
            UpdateButtonSprite(button);
        }
        cameraController = GetComponent<CameraController>();
    }

    private void UpdateButtonSprite(Button button)
    {
        if(inventoryManager.Slots != null)
        {
            switch (button.name)
            {
                case Buttons.SLOT_1:
                    button.image.sprite = inventoryManager.Slots[0] != null ? inventoryManager.Slots[0].sprite : defaultSprite;
                    button.GetComponentInChildren<Text>().text = inventoryManager.Slots[0] != null ? inventoryManager.Slots[0].Amount.ToString() : "";
                    break;
                case Buttons.SLOT_2:
                        button.image.sprite = inventoryManager.Slots[1] != null ? inventoryManager.Slots[1].sprite : defaultSprite;
                    button.GetComponentInChildren<Text>().text = inventoryManager.Slots[1] != null ? inventoryManager.Slots[1].Amount.ToString() : "";
                    break;
                case Buttons.SLOT_3:
                        button.image.sprite = inventoryManager.Slots[2] != null ? inventoryManager.Slots[2].sprite : defaultSprite;
                    button.GetComponentInChildren<Text>().text = inventoryManager.Slots[2] != null ? inventoryManager.Slots[2].Amount.ToString() : "";
                    break;
                case Buttons.SLOT_4:
                        button.image.sprite = inventoryManager.Slots[3] != null ? inventoryManager.Slots[3].sprite : defaultSprite;
                    button.GetComponentInChildren<Text>().text = inventoryManager.Slots[3] != null ? inventoryManager.Slots[3].Amount.ToString() : "";
                    break;
            }
        }
    }

    public void onButtonClick(Button button)
    {
        Debug.Log("Button has been triggered: " + button.name);
        switch(button.name)
        {
            case Buttons.TOGGLE_VIEW:
                cameraController.TogglePersonView();
                break;
            case Buttons.SLOT_1:
            case Buttons.SLOT_2:
            case Buttons.SLOT_3:
            case Buttons.SLOT_4:
                inventoryManager.UseItem(button.name);
                break;
            case Buttons.SHIFT_LEFT_BUTTON:
                inventoryManager.ShiftLeft();
                break;
            case Buttons.SHIFT_RIGHT_BUTTON:
                inventoryManager.ShiftRight();
                break;
        }
    }

    // Update is called once per frame
    void Update () {
        foreach (Button button in buttons)
        {
            UpdateButtonSprite(button);
        }
    }
}
