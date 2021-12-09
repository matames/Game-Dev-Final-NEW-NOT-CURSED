using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
     public enum ItemType
    {
        EpicFish,
        BasicFish,
        WeakFish
    }

    public ItemType itemType;
    public int amount;
}