using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    public List<Item> Items { get; private set; }

    public enum BenefitOfItem { Health, Mana, Jump }

    private PlayerController player;

    public void Start()
    {
        Items = new List<Item>();
        player = GetComponent<PlayerController>();
    }

    public void Add(GameObject gameObject)
    {
        Item itemToAdd = gameObject.GetComponent<Item>();
        if (itemToAdd != null)
        {
            bool doesExist = false;
            foreach(Item item in Items)
            {
                if(item.Name == itemToAdd.Name)
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

    public void UseItem(String tag)
    {
        Item item = GetItem(tag);
        if(item != null)
        {
            UseBenefit(item.Benefit);
            item.Amount--;
            if (item.Amount <= 0)
            {
                DropItem(item);
            }
        }
    }

    private void UseBenefit(BenefitOfItem benefit)
    {
        switch(benefit)
        {
            case BenefitOfItem.Health:
                player.IncreaseLife();
                break;
            case BenefitOfItem.Jump:
                break;
            case BenefitOfItem.Mana:
                break;
        }
    }

    private Item GetItem(String tag)
    {
        foreach (Item item in Items.ToArray())
        {
            if (item.CompareTag(tag))
            {
                return item;
            }
        }
        return null;
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
