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

    public Sprite GetSprite()
    {
        switch (itemType)
        {
            default:
                case ItemType.BasicFish: return ItemAssets.Instance.BasicFishSprite;
                case ItemType.EpicFish: return ItemAssets.Instance.EpicFishSprite;
                case ItemType.WeakFish: return ItemAssets.Instance.WeakFishSprite;
}
}


}

