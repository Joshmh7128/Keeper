using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemProperties : MonoBehaviour
{
    public bool isMetal = false;
    public bool isWood = false;
    public bool isTreasure = false;

    public int power;
    public int durability;
    public int value;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isMetal)
        {
            power = 1;
            durability = 0;
            value = 0;
        }
        if (isWood)
        {
            power = 0;
            durability = 1;
            value = 0;
        }
        if (isTreasure)
        {
            power = 0;
            durability = 0;
            value = 1;
        }


    }
}
