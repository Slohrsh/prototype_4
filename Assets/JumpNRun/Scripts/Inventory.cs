using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    public List<Item> Items { get; private set; }

    public const String LIFEPOT = "LifePot";
    public const String KEY = "Key";
    public const String ICE_AXE = "IceAxe";
    public const String BARREL = "Barrel";


    public void Start()
    {
        Items = new List<Item>();
    }

    public void Add(GameObject gameObject)
    {
        Item item = gameObject.GetComponent<Item>();
        if (item != null)
        {
            Items.Add(item);
        }
        Debug.Log(Items);
    }

    public void DecreaseItem(String tag)
    {
        manipulateItem(tag, -1);
    }

    private bool manipulateItem(String tag, int value)
    {
        bool isItem = false;
        foreach (Item item in Items)
        {
            if (item.name.Equals(tag))
            {
                item.Amount += value;
                isItem = true;
            }
        }
        return isItem;
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
