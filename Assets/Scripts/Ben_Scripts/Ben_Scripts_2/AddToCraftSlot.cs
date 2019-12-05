using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddToCraftSlot : MonoBehaviour
{

    public bool isColliding = false;
    private GameObject part;
    private DragAndDrop dragAndDrop;
    public EquipmentCrafting equipmentCraftingscript;
    //public AddToInventory AddToInventory;

    public bool isFull = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Part"))
        {
            
            part = other.gameObject;
            dragAndDrop = other.GetComponent<DragAndDrop>();
            isColliding = true;
            Debug.Log("yayuh");
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Part"))
        {
            isColliding = true;
            Debug.Log("staying");

        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Part"))
        {
            dragAndDrop = null;
            isColliding = false;
            Debug.Log("exited");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0) && isColliding && !isFull)
        {
            part.transform.SetParent(gameObject.transform, false);
            Debug.Log("IsFull");
            equipmentCraftingscript.parts.Add(part);  
            isFull = true;
            equipmentCraftingscript.CheckCraftingSlots();
            //add to parts list

        }

        if (Input.GetMouseButtonUp(0) && !isColliding)
        {
            //put detach children function in here?
            //part.transform.SetParent(null);
            part.transform.position = dragAndDrop.initialPos;
            isFull = false;
        }
    }
}
