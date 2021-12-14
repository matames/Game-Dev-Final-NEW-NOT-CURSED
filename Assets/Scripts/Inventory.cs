using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    public event EventHandler OnItemListChanged;

    public List<Item> itemList;

    public Inventory()
    {
        itemList = new List<Item>();

        

        Debug.Log(itemList.Count);
    }

    public void AddItem(Item item)
    {
        itemList.Add(item);
        OnItemListChanged?.Invoke(this, EventArgs.Empty); 
    }

    public List<Item> GetItemList()
    {
        return itemList;
    }

         
    }