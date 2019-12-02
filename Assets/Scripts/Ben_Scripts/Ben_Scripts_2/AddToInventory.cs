using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddToInventory : MonoBehaviour
{
    public InventoryScript inventory;
    public GameObject itemButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddInventory()
    {
        for (int i = 0; i < inventory.slots.Length; i++)
        {
            //checks if inventory is full
            if (inventory.isFull[i] == false)
            {
                //Item is added to inv
                inventory.isFull[i] = true;
                //check if part is already in inventory, would need to stack
                GameObject item = Instantiate(itemButton, inventory.slots[i].transform, false);
                item.SetActive(true);
                break;
            }
        }
    }
}
