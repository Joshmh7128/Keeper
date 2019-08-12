using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandScript : MonoBehaviour
{
    public GameObject heldItem;
    public GameObject targetItem;
    public Transform holdPoint;
    public bool handOpen = true; 
    public int grabBuffer = 0;

    //when the hand hovers over a target item, set that item to our target item
    public void OnTriggerStay2D(Collider2D other)
    {   //if the object is an item...
        if (other.tag == "Item")
        {
            //if our hand is empty, change the target item...
            if (handOpen)
            {
                targetItem = other.gameObject;
            }
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Item")
        {
            targetItem = null;
        }
    }

    public void Update()
    {
        //if you have an open hand, are hovering over an item, and press E, tell that item it is picked up
        if ((handOpen) && Input.GetKeyDown("e") && (grabBuffer < 0))
        {
            //add to our grabBuffer
            grabBuffer += 6;
            //tell this item that it is being held
            heldItem = targetItem;
            heldItem.GetComponent<ItemManipulationScript>().IsHeld();
            //since our hand is no longer empty set that as well
            handOpen = false;
        }

        //if we do not have an open hand and press E, drop the item in our hand, and open our hand
        if ((!handOpen) && (Input.GetKeyDown("e")) && (grabBuffer < 0))
        {
            //add to our grabBuffer
            grabBuffer += 6;
            //tell the item it is not held
            heldItem.GetComponent<ItemManipulationScript>().IsHeld();
            //the player's hand is now open
            handOpen = true;
        }

        //set our grab buffer so we can't spam the grabbing and dropping
        if (grabBuffer >= 0)
        {
            grabBuffer -= 1;
        }
    }

}
