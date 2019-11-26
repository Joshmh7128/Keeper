using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    //List of all items player has in their inventory
    public List<Item> items;
    
    //parent object that holds the Grid Layout Group script
    public Transform itemsParent;

    //Each Item Slot in the inventory
    public ItemSlot[] itemSlots;

    private void OnValidate()
    {
        //Gets parent ItemSlots
        if (itemsParent != null)
        {
            itemSlots = itemsParent.GetComponentsInChildren<ItemSlot>();
        }

        RefreshUI();
    }


    //Adds Items to their respective Item Slots in the inventory
    private void RefreshUI()
    {
        int i = 0;
        for (; i < items.Count && i < itemSlots.Length; i++)
        {
            itemSlots[i].Item = items[i];
        }

        for (; i < itemSlots.Length; i++)
        {
            itemSlots[i].Item = null;
        }

    }

    public bool AddItem(Item item)
    {
        if (IsFull())
        {
            return false;
        }

        items.Add(item);
        RefreshUI();
        return true;
    }

    public bool RemoveItem(Item item)
    {
        if (items.Remove(item))
        {
            RefreshUI();
            return true;
        }

        return false;
    }

    public bool IsFull()
    {
        return items.Count >= itemSlots.Length;
    }

}
