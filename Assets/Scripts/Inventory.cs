using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    public List<Item> itemList;

    public Inventory()
    {
        itemList = new List<Item>();

        AddItem(new Item { itemType = Item.ItemType.BasicFish, amount = 1 });
        AddItem(new Item { itemType = Item.ItemType.EpicFish, amount = 1 });
        AddItem(new Item { itemType = Item.ItemType.WeakFish, amount = 1 });

        Debug.Log(itemList.Count);
    }

    public void AddItem(Item item)
    {
        itemList.Add(item);
    }

    public List<Item> GetItemList()
    {
        return itemList;
    }

         
    }