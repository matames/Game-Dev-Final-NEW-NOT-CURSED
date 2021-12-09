using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
        [SerializeField] private UI_Inventory uiInventory;
        private Inventory inventory;
        // Start is called before the first frame update
        void Start()
        {
            inventory = new Inventory();
            uiInventory.SetInventory(inventory);
        }

        // Update is called once per frame
       
    }

