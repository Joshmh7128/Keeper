using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSlotScript : MonoBehaviour
{
    public GameObject heldItem;
    public bool slotFull;
    public int setBuffer = 6; //use this to create a buffer between setting the slot to full or empty.

    public void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag == "Item")
        {   //make sure we only set this if the object we have contacting the slot is NOT being held by the player
            if (!col.gameObject.GetComponent<ItemManipulationScript>().isHeld)
            {
                //set our held item to the item being placed in the slot
                heldItem = col.gameObject;
            }
        }
    }

    public void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Item")
        {   //if an item leaves the slot, set it to null
            heldItem = null;
        }
    }
}
