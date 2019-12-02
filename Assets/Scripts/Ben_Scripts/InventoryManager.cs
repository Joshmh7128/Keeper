using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{ 
    public Inventory inventory;
    public EquipmentCraftingPanel equipmentPanel;

    private void Start()
    {
        inventory.OnItemRightClickedEvent += AddToCraft;
    }

    public void AddToCraft(Item item)
    {
        if(inventory.RemoveItem(item))
        {
            Item previousItem;
            if (equipmentPanel.AddItem(item, out previousItem))
            {
                if (previousItem != null)
                {
                    inventory.AddItem(previousItem);
                }
            }
            else
            {
                inventory.AddItem(item);
            }
        }
    }

    public void RemoveFromCraft(Item item)
    {
        if(!inventory.IsFull() && equipmentPanel.RemoveItem(item))
        {
            inventory.AddItem(item);
        }
    }

}
