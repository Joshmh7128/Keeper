using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManipulationScript : MonoBehaviour
{
    /*/ 
     * this script is placed on an item we want to move
     * it allows us to manipulated it in the game world
    /*/
    public bool isHeld; //if this item being held?  
    public bool canDrop = true; //can this item be dropped?
    Transform holdPoint; //where is this item being held?

    public void Start()
    {  
        //find the object that will be the point at which we're held
        holdPoint = GameObject.Find("Hold Point").GetComponent<Transform>();
    }

    public void Update()
    {   
        //if we are being held, move to the hold point every frame
        if (isHeld)
        {
            transform.position = holdPoint.position;
        }
    }

    //this is used to tell if we're being held or not
    public void IsHeld()
    {
        if (canDrop) //if we can drop this item...
        isHeld = !isHeld;
    }

    public void OnTriggerStay2D(Collider2D col)
    {
        //if our col tag is equal to slot and the item is not being held, and the slot in question not full we can place the item in it
        if ((col.tag == "Slot") && (!isHeld) && ((col.GetComponent<ItemSlotScript>().heldItem == null) || (col.GetComponent<ItemSlotScript>().heldItem == gameObject))) 
        {
            transform.position = col.transform.position;
            transform.position += new Vector3(0, 0, -10);
        }
    }
}
