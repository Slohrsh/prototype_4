using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour {

    public Inventory inventory;

    public Item[] Slots { get; private set; }

    public int shiftRightCount = 0;

	void Start ()
    {
        Slots = new Item[4];
    }
	
	void Update ()
    {
        UpdateSlots();
    }

    public void UseItem(String slot)
    {
        Item item = GetItemOfSlot(slot);
        if(item != null)
            inventory.UseItem(item.tag);
    }

    public void ShiftRight()
    {
        if(shiftRightCount + 4 < inventory.Items.Count)
        {
            shiftRightCount++;
            UpdateSlots();
        }
    }

    public void ShiftLeft()
    {
        if(shiftRightCount != 0)
        {
            shiftRightCount--;
            UpdateSlots();
        }
    }

    private void UpdateSlots()
    {
        int size = inventory.Items.Count;
        Clear(Slots);
        for (int i = shiftRightCount; i < shiftRightCount + 4 && i < size; i++)
        {
            Slots[i - shiftRightCount] = inventory.Items[i];
        }
    }

    private void Clear(Item[] slots)
    {
        for(int i = 0; i < 4; i++)
        {
            Slots[i] = null;
        }
    }

    private Item GetItemOfSlot(string slot)
    {
        return Slots[Int32.Parse(slot) - 1];
    }
}
