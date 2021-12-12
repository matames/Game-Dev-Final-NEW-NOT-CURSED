using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
        [SerializeField] public UI_Inventory uiInventory;

    //will dictate which fish you get
        private float fishStatus;
        public Inventory inventory;
        // Start is called before the first frame update
        public void Start()
        {
            fishStatus = GameObject.Find("player").GetComponent<CastingBar>().fishStrength;
            inventory = new Inventory();
            uiInventory.SetInventory(inventory);
        }

        public void OnWinGame()
    {   
        fishStatus = GameObject.Find("player").GetComponent<CastingBar>().fishStrength;
        if ( FishingMiniGame.win == true)
        {
            if(fishStatus == 0) {
                inventory.AddItem(new Item { itemType = Item.ItemType.WeakFish, amount = 1 });
                
            }
            else if (fishStatus == 1)
            {
                inventory.AddItem(new Item { itemType = Item.ItemType.BasicFish, amount = 1 });
            }
            else if (fishStatus == 2)
            {
                inventory.AddItem(new Item { itemType = Item.ItemType.EpicFish, amount = 1 });
            }
        }


    }
        // Update is called once per frame
       
    }

