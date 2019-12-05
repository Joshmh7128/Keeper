using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentCrafting : MonoBehaviour
{
    //public GameObject[] craftableEquipment;
    public List<GameObject> slots;
    public List<GameObject> parts;

    public GameObject swordPanel;
    public GameObject axePanel;
    public GameObject shieldPanel;

    public Transform equipmentItemSpawnSpot;
    public GameObject equipmentItem;


    //checks what item is being crafted
    public bool isSword = true;
    public bool isAxe = false;
    public bool isShield = false;

    //part stats
    public int power = 0;
    public int durability = 0;
    public int value = 0;

    private bool isFull = false;

    //allows crafting slots to be added
    private bool addSword = true;

    //true if all crafting slots are full
    private bool isAllSlotsFull;

    private bool isCrafting = true;

    //The number of full slots
    public float slotsFull = 0;

    //The number of full slots
    public float totalValue = 0;



    void Update()
    {
        if (isSword == true)
        {
            //Adds the sword crafting slots to the menu
            if (addSword == true)
            {
                for (int i = 0; i < 3; i++)
                {
                    GameObject child = swordPanel.gameObject.transform.GetChild(i).gameObject;
                    slots.Add(child);
                }
                addSword = false;
            }
        }

        //CheckCraftingSlots();


        

        //If Sword is selected and 3 slots are full, craft the item
        if (isSword && (slotsFull >= 3) && isCrafting)
        {
            CraftItem();
            //isCrafting = false;
        }
    }

    public void CheckCraftingSlots()
    {
        //Checks each crafting slot to see if there is an item in it
        for (int i = 0; i < parts.Count; i++)
        {
            GameObject part = parts[i].gameObject;
            Transform partParent = part.transform.parent;
            AddToCraftSlot addToCraftSlot = partParent.GetComponent<AddToCraftSlot>();

            //Checks if an individual crafting slot is full
            if (addToCraftSlot.isFull)
            {
                Debug.Log("slot full");
                //If there is something in it, add 1 to the number of full slots
                slotsFull = slotsFull + 1;
                //addToCraftSlot.isFull = false;
            }
        }
    }

    void CraftItem()
    {

        for (int i = 0; i < parts.Count; i++)
        {
            GameObject part = parts[i];
            ItemProperties partScript = part.GetComponent<ItemProperties>();

            

            if (partScript.isMetal)
            {
                power = power + 1;
                totalValue = totalValue + 1;
            }
            if (partScript.isWood)
            {
                durability = durability + 1;
                totalValue = totalValue + 1;
            }
            if (partScript.isTreasure)
            {
                value = value + 1;
                totalValue = totalValue + 1;
            }

            
        }

        GameObject equipItem = Instantiate(equipmentItem, equipmentItemSpawnSpot, false);
        //equipmentItem.transform.position = Vector3.zero;
        equipItem.SetActive(true);
        isCrafting = false;
    }
}
