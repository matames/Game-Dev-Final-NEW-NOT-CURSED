using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAssets : MonoBehaviour
{
    public static ItemAssets Instance { get; private set; }

    private void Start()
    {
        Instance = this;

    }

    public Sprite EpicFishSprite;
    public Sprite BasicFishSprite;
    public Sprite WeakFishSprite;
}
