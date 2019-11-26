using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentCraftingPanel : MonoBehaviour
{

    public Transform craftingSlotsParent;
    public ItemSlot[] craftingSlots;

    private void OnValidate()
    {
        craftingSlots = craftingSlotsParent.GetComponentsInChildren<ItemSlot>();
    }

    public bool AddItem(Item item, out Item previousItem)
    {
        for (int i = 0; i < craftingSlots.Length; i++)
        {
            if (craftingSlots[i].Item == item)
            {
                previousItem = (Item)craftingSlots[i].Item;
                craftingSlots[i].Item = item;
                return true;
            }
        }
        previousItem = null;
        return false;
    }

    public bool RemoveItem(Item item)
    {
        for (int i = 0; i < craftingSlots.Length; i++)
        {
            if (craftingSlots[i].Item == item)
            {
                
                craftingSlots[i].Item = null;
                return true;
            }
        }
        return false;
    }
}
