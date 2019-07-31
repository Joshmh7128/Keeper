using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartClass
{
    /* 
     * This script is used to define the parts that weapons are made of.
     * Within this we're going to be holding all of the attributes parts have,
     * durability, strength, magic, value, and part name.
     * using this we can build different weapons, armors, and shields
     * with a system based around values we can both modify and watch with ease.
     * Additionally, although these variables are public, this is a lot cost
     * system that doesn't use as much memory as I expected. It's also inherently
     * based off of number generation, allowing us to randomly make not only equipment,
     * but their parts as well.
    */

    //define all of our part attributes//
    public float durability = 0;
    public float strength = 0;
    public float magic = 0;
    public float value = 0; //value is 1 by default//
    public string partName;

    //define all possible inputs for each individual part//
    public GameManager.materials partSlotOne;
    public GameManager.materials partSlotTwo;
    public GameManager.materials partSlotThree;
    public GameManager.materials partSlotFour;
    public GameManager.materials partSlotFive;

    /*
     * We'll make a helper script here to read off our part values and return values 
     * based on what each slot has, we'll run this for every part slot and get a value
     * this is where we define the values of every material as well and how much they're all worth
    */
    public void GetValues(GameManager.materials element)
    {
        switch (element)
        {
            case GameManager.materials.none:
                //don't add anything
                break;

            case GameManager.materials.wood:
                durability += 1;
                break;

            case GameManager.materials.metal:
                strength += 1;
                break;

            case GameManager.materials.magic:
                magic += 1;
                break;

            case GameManager.materials.treasure:
                value += 1;
                break;

            case GameManager.materials.metalWood:
                durability += 1;
                strength += 1;
                break;

            case GameManager.materials.livingWood:
                durability += 1;
                magic += 1;
                break;

            case GameManager.materials.studdedWood:
                durability += 1;
                value += 1;
                break;

            case GameManager.materials.livingMetal:
                magic += 1;
                strength += 1;
                break;

            case GameManager.materials.studdedMetal:
                value += 1;
                strength += 1;
                break;

            case GameManager.materials.magicGems:
                durability += 1;
                strength += 1;
                break;
        }

        //setup our value modifiers for our items
        /*
        float valMultiplierMagic   = (magic *= 0.1f);
        float valMultiplierDur     = (durability *= 0.05f);
        float valMultiplierStr     = (strength *= 0.05f);
        float valMultiplier        = (valMultiplierMagic += valMultiplierDur += valMultiplierStr);*/
        //value *= valMultiplier;
    }
    
    public void Start()
    {
        //run our values script the moment this starts//
        GetValues(partSlotOne);
        GetValues(partSlotTwo);
        GetValues(partSlotThree);
        GetValues(partSlotFour);
        GetValues(partSlotFive);
    }
}
