using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    public List<Item> Items { get; private set; }

    public const String Item = "Item";



    public void Start()
    {
        Items = new List<Item>();
    }

    public void Add(GameObject gameObject)
    {
        Item itemToAdd = gameObject.GetComponent<Item>();
        if (itemToAdd != null)
        {
            bool doesExist = false;
            foreach(Item item in Items)
            {
                if(item.CompareTag(itemToAdd.tag))
                {
                    item.Amount++;
                    doesExist = true;
                }
            }
            if(!doesExist)
            {
                Items.Add(itemToAdd);
            }
        }
    }

    public void DecreaseItem(String tag)
    {
        manipulateItem(tag, -1);
    }

    private void manipulateItem(String tag, int value)
    {
        foreach (Item item in Items.ToArray())
        {
            if (item.CompareTag(tag))
            {
                item.Amount += value;
                if(item.Amount <= 0)
                {
                    DropItem(item);
                }
            }

        }
    }

    private void DropItem(Item item)
    {
        Items.Remove(item);
    }

    public bool HasItem(string tag)
    {
        bool hasItem = false;
        foreach (Item item in Items)
        {
            if (item.name.Equals(tag) && item.Amount > 0)
            {
                hasItem = true;
            }
        }
        return hasItem;
    }
}
