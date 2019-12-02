using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentCrafting : MonoBehaviour
{
    //public GameObject[] craftableEquipment;
    public List<GameObject> slots;
    public List<GameObject> parts;

    public GameObject swordPanel;


    //checks what item is being crafted
    public bool isSword = true;
    public bool isShield = false;
    public bool 


    //allows crafting slots to be added
    private bool addSword = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isSword == true)
        {
            if(addSword == true)
            {
                for (int i = 0; i < 3; i++)
                {
                    GameObject child = swordPanel.gameObject.transform.GetChild(i).gameObject;
                    slots.Add(child);
                }
                addSword = false;
            }
        }
    }

    void CraftItem()
    {
        //check list for what parts are in it
    }
}
