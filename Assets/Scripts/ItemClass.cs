using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime;

public class ItemClass : MonoBehaviour
{
    #region //Item Definitions//

    /*
     * Within this region of the script we're...
     * Defining our universal values, getting out base type, getting our subtype, getting our item
     * subtype values, essentially creating a blueprint that every item in the game can follow.
    */

    #region //Universal Values//
    [Header("Universal Values")]
    //Here are our universal attributes shared by all items
    public string itemName; //what is the name of the item?
    public enum itemQualities { Terrible, Bad, Okay, /* */ Fine, Refined, Polished, /* */
                                Good, Better, Nice, /* */ Great, Perfect, Supreme, Ultimate, /* */
                                Legendary, Godlike }; //made a total of 15 so we can experiment with some math, but the first 10 will be good to much about with
    public itemQualities itemQuality; //what is the quality of the item?
    public float itemValue; //how much is this item worth?
    public float itemDurability; //this will change based on if it's a weapon or an armor, 
    public TextMesh itemInfo;

    #region //Material Amounts//
    //basic materials
    public float woodAmount; public float metalAmount; public float magicAmount; public float treasureAmount;
    //advanced materials
    public float livingWoodAmount; public float metalWoodAmount; public float studdedWoodAmount;
    public float livingMetalAmount; public float studdedMetalAmount; public float magicGemsAmount;
    #endregion

    #endregion

    #region //Display Item Information Properly//

    void ItemInfoDisplay()
    {
        bool textDone = false;
        if (!textDone)
        {
            string displayText =
                (@"Name: " + itemName + "\n" +
                 "Quality: " + (itemQuality.ToString()) + "\n" +
                 "Value: " + itemValue + "\n" + "\n" +
                 "Wood Content: " + woodAmount + "\n" +
                 "Metal Content: " + metalAmount + "\n" +
                 "Magic Content: " + magicAmount + "\n" +
                 "Treasure Content: " + treasureAmount + "\n" +
                 "Living Wood Content: " + livingWoodAmount + "\n" +
                 "Metal Wood Content: " + metalWoodAmount + "\n" +
                 "Studded Wood Content: " + studdedWoodAmount + "\n" +
                 "Living Metal Content: " + livingMetalAmount + "\n" +
                 "Studded Metal Content: " + woodAmount + "\n" +
                 "Magic Gems Content: " + magicGemsAmount + "\n" + "\n" + "WEAPON VALUES:" + "\n" +
                 "Damage: " + weaponDamage +"\n" + 
                 "Class: " + (weaponClass.ToString()) +"\n" +
                 "Weight Class: " + (weaponWeight.ToString()));

            itemInfo.text = displayText;
            textDone = true;
        }
    }

    #endregion

    #region //Get the amount of materials in the object//
    public bool materialsSet = false;
    void SetMaterialAmounts()
    {   
        //have we set our material values if we havent...
        if (!materialsSet)
        //check for every part in parts list to add to the amounts of each material value
        //if our base type is equipment...
        if (baseType == baseTypes.equipment)
        {
            if (equipmentSubType == equipmentSubTypes.weapon)
            {
                foreach (PartClass part in weaponPartsList)
                { 
                    //check each part's slots one through 5, and add them to the item's value
                    GatherPartInfo(part, 1);
                    GatherPartInfo(part, 2);
                    GatherPartInfo(part, 3);
                    GatherPartInfo(part, 4);
                    GatherPartInfo(part, 5);
                }

                materialsSet = true;
            }

            if (equipmentSubType == equipmentSubTypes.armor)
            {
                foreach (PartClass part in armorPartsList)
                {
                    //check each part's slots one through 5, and add them to the item's value
                    GatherPartInfo(part, 1);
                    GatherPartInfo(part, 2);
                    GatherPartInfo(part, 3);
                    GatherPartInfo(part, 4);
                    GatherPartInfo(part, 5);
                }

                materialsSet = true;
            }

            if (equipmentSubType == equipmentSubTypes.shield)
            {
                foreach (PartClass part in shieldPartsList)
                {
                    //check each part's slots one through 5, and add them to the item's value
                    GatherPartInfo(part, 1);
                    GatherPartInfo(part, 2);
                    GatherPartInfo(part, 3);
                    GatherPartInfo(part, 4);
                    GatherPartInfo(part, 5);
                }

                materialsSet = true;
            }
        }
    }

    //helper script to get all of our material values
    void GatherPartInfo(PartClass part, int partSlot)
    {
        /* 
         * Use this script to get part amounts from each part slot, then
         * add those to our item's material values for deconstruction later on
        */

        Debug.Log("Checking " + part + " of " + partSlot);

        #region //part slot one checking//
       /* 
        * see how you can use dictionary mapping to improve this section
       */
        if (partSlot == 1)
        {
            if (part.partSlotOne == GameManager.materials.wood)
            { woodAmount += 1; }

            if (part.partSlotOne == GameManager.materials.metal)
            { metalAmount += 1; }

            if (part.partSlotOne == GameManager.materials.magic)
            { magicAmount += 1; }

            if (part.partSlotOne == GameManager.materials.treasure)
            { treasureAmount += 1; }

            if (part.partSlotOne == GameManager.materials.livingMetal)
            { livingMetalAmount += 1; }

            if (part.partSlotOne == GameManager.materials.livingWood)
            { livingWoodAmount += 1; }

            if (part.partSlotOne == GameManager.materials.magicGems)
            { magicGemsAmount += 1; }

            if (part.partSlotOne == GameManager.materials.metalWood)
            { metalWoodAmount += 1; }

            if (part.partSlotOne == GameManager.materials.studdedMetal)
            { studdedMetalAmount += 1; }

            if (part.partSlotOne == GameManager.materials.studdedWood)
            { studdedWoodAmount += 1; }
        }
        #endregion

        #region //part slot two checking//
        if (partSlot == 2)
        {
            if (part.partSlotTwo == GameManager.materials.wood)
            { woodAmount += 1; }

            if (part.partSlotTwo == GameManager.materials.metal)
            { metalAmount += 1; }

            if (part.partSlotTwo == GameManager.materials.magic)
            { magicAmount += 1; }

            if (part.partSlotTwo == GameManager.materials.treasure)
            { treasureAmount += 1; }

            if (part.partSlotTwo == GameManager.materials.livingMetal)
            { livingMetalAmount += 1; }

            if (part.partSlotTwo == GameManager.materials.livingWood)
            { livingWoodAmount += 1; }

            if (part.partSlotTwo == GameManager.materials.magicGems)
            { magicGemsAmount += 1; }

            if (part.partSlotTwo == GameManager.materials.metalWood)
            { metalWoodAmount += 1; }

            if (part.partSlotTwo == GameManager.materials.studdedMetal)
            { studdedMetalAmount += 1; }

            if (part.partSlotTwo == GameManager.materials.studdedWood)
            { studdedWoodAmount += 1; }
        }
        #endregion       
        
        #region //part slot three checking//
        if (partSlot == 3)
        {
            if (part.partSlotThree == GameManager.materials.wood)
            { woodAmount += 1; }

            if (part.partSlotThree == GameManager.materials.metal)
            { metalAmount += 1; }

            if (part.partSlotThree == GameManager.materials.magic)
            { magicAmount += 1; }

            if (part.partSlotThree == GameManager.materials.treasure)
            { treasureAmount += 1; }

            if (part.partSlotThree == GameManager.materials.livingMetal)
            { livingMetalAmount += 1; }

            if (part.partSlotThree == GameManager.materials.livingWood)
            { livingWoodAmount += 1; }

            if (part.partSlotThree == GameManager.materials.magicGems)
            { magicGemsAmount += 1; }

            if (part.partSlotThree == GameManager.materials.metalWood)
            { metalWoodAmount += 1; }

            if (part.partSlotThree == GameManager.materials.studdedMetal)
            { studdedMetalAmount += 1; }

            if (part.partSlotThree == GameManager.materials.studdedWood)
            { studdedWoodAmount += 1; }
        }
        #endregion  
        
        #region //part slot four checking//
        if (partSlot == 4)
        {
            if (part.partSlotFour == GameManager.materials.wood)
            { woodAmount += 1; }

            if (part.partSlotFour == GameManager.materials.metal)
            { metalAmount += 1; }

            if (part.partSlotFour == GameManager.materials.magic)
            { magicAmount += 1; }

            if (part.partSlotFour == GameManager.materials.treasure)
            { treasureAmount += 1; }

            if (part.partSlotFour == GameManager.materials.livingMetal)
            { livingMetalAmount += 1; }

            if (part.partSlotFour == GameManager.materials.livingWood)
            { livingWoodAmount += 1; }

            if (part.partSlotFour == GameManager.materials.magicGems)
            { magicGemsAmount += 1; }

            if (part.partSlotFour == GameManager.materials.metalWood)
            { metalWoodAmount += 1; }

            if (part.partSlotFour == GameManager.materials.studdedMetal)
            { studdedMetalAmount += 1; }

            if (part.partSlotFour == GameManager.materials.studdedWood)
            { studdedWoodAmount += 1; }
        }
        #endregion 
        
        #region //part slot five checking//
        if (partSlot == 5)
        {
            if (part.partSlotFive == GameManager.materials.wood)
            { woodAmount += 1; }

            if (part.partSlotFive == GameManager.materials.metal)
            { metalAmount += 1; }

            if (part.partSlotFive == GameManager.materials.magic)
            { magicAmount += 1; }

            if (part.partSlotFive == GameManager.materials.treasure)
            { treasureAmount += 1; }

            if (part.partSlotFive == GameManager.materials.livingMetal)
            { livingMetalAmount += 1; }

            if (part.partSlotFive == GameManager.materials.livingWood)
            { livingWoodAmount += 1; }

            if (part.partSlotFive == GameManager.materials.magicGems)
            { magicGemsAmount += 1; }

            if (part.partSlotFive == GameManager.materials.metalWood)
            { metalWoodAmount += 1; }

            if (part.partSlotFive == GameManager.materials.studdedMetal)
            { studdedMetalAmount += 1; }

            if (part.partSlotFive == GameManager.materials.studdedWood)
            { studdedWoodAmount += 1; }
        }
        #endregion
    }
    #endregion

    #region //Calculate the item's value based on it's quality//
    public bool valueCalculated = false;

    void DetermineItemValue()
    {
        if (!valueCalculated)
        {
            itemValue *= (int)itemQuality;
            valueCalculated = true;
        }
    }

    #endregion

    #region //Base Types and Sub Types//
    //here's where we define all the elements of an object   
    public enum baseTypes { none, equipment, magic, consumable, unique }; //What BASE type is it?

    [Header("Base Item Type")] [Space(10)]
    public baseTypes baseType;

    //after we decide our base type, get our subtypes and specific item types
    public enum equipmentSubTypes { none, armor, weapon, shield }; //what type of equiment is it?
    [Header("Equipment Subtype Definition (+Equipment Universals)")] [Space(10)]
    public equipmentSubTypes equipmentSubType;
    public float equipmentMagicLevel;
    public float equipmentStrengthLevel;

    public enum magicSubTypes { none, tome, talisman, artifact, scroll, spell, enchantment }; //what type of magical item is it?
    [Header("Magic Subtype Definition")] [Space(10)]
    public magicSubTypes magicSubType;

    public enum consumableSubTypes { none, potion, food, gear /* gear != equipment */, ammo }; //what type of consumable is it?
    [Header("Consumable Subtype Definition")] [Space(10)]
    public consumableSubTypes consumableSubType;
    #endregion
 
    //define our equipment items, things like durability, strength, magic, value, and naming are all in the functions below//

    #region //Weapon Definitions//
    public enum weaponTypes { none, Sword, Axe, Bow, Spear, Crossbow } //what weapon is this? NOTICE: these are capitalized because we're displaying them as strings!
    public enum weaponClasses { none, Ranged, Melee }; //what class of weapon is this? This should be defined by the weapon's type
    public enum weaponWeights { none, Light, Medium, Heavy }; //what weight is this weapon?
    [Header("Weapon Variables")]
    [Space(10)]
    public weaponTypes weaponType;        //define type
    public weaponClasses weaponClass;     //define the weapons class
    public weaponWeights weaponWeight;    //define the weight of the weapon
    public float weaponDamage;              //damage this weapon can output
    [Header("Don't modify the length of the array in-editor if this is a generated item")]
    public PartClass[] weaponPartsList = new PartClass[5]; /*IMPORTANT! MAKE SURE TO SET THIS INTEGER MANUALLY TO THE HIGHEST AMOUNT OF PARTS A WEAPON CAN HAVE!*/
    #endregion

    #region    //Armor Definitions//
    public enum armorPieces { none, Helmet, Chestplate, Leggings, Boots }; //what piece of armor is this? NOTICE: these are capitalized because we're displaying them as strings!
    public enum armorClasses { none, Wood, Metal, Magic, Studded };      //from the items used, what is the primary base crafting material used? NOTICE: these are capitalized because we're displaying them as strings!

    [Header("Armor Variables")]
    [Space(10)]
    public armorPieces armorPiece;   //define which piece of armor this is
    public armorClasses armorClass;  //define what class of armor this is
    public float armorWeight; //define the weight of the armor (strength + durability)
    [Header("Don't modify the length of the array in-editor if this is a generated item")]
    public PartClass[] armorPartsList = new PartClass[5]; /*IMPORTANT! MAKE SURE TO SET THIS INTEGER MANUALLY TO THE HIGHEST AMOUNT OF PARTS A WEAPON CAN HAVE!*/

    #endregion

    #region //Shields Definitions//
    public enum shieldTypes { none, Wood, Leather, Metal, Magic, Studded }; //from the items used, what is the primary base crafting material used? NOTICE: these are capitalized because we're displaying them as strings!
    public enum shieldSizes { none, Small, Normal, Large }; //what size is our shield? NOTICE: these are capitalized because we're displaying them as strings!
    public enum shieldWeights { none, Light, Medium, Heavy }; //what is the weight of our shield NOTICE: these are capitalized because we're displaying them as strings!

    [Header("Shield Variables")]
    [Space(10)]
    public shieldTypes shieldType;
    public shieldSizes shieldSize;
    public shieldWeights shieldWeight;
    [Header("Don't modify the length of the array in-editor if this is a generated item")]
    public PartClass[] shieldPartsList = new PartClass[3]; /*IMPORTANT! MAKE SURE TO SET THIS INTEGER MANUALLY TO THE HIGHEST AMOUNT OF PARTS A SHIELD CAN HAVE!*/
    #endregion

    #region //Magic Definitions//

    //define our magical items
    //scrolls and spells are both made up of the same tomes
    public enum scrollTypes { none, twoTome }; //how many tomes does this scroll have?
    public enum spellTypes { none, twoTome };  //what kind of spell is this?
    public enum tomeElements { none, Fire, Poison, Water, Air, Earth };   //list elements here
    public enum tomeAdjectives { none, Blast, Explosion, Cleanse, Ball }; //list adjectives here
                                                                          //enchantments are made up of talismans and artifacts
    public enum talismanTypes { none, Healing, Fire, Water, Shocking };   //list elements here, talisman
    [Header("Magical Variables (Scrolls and Spells)")]
    [Space(10)]
    public scrollTypes scrollType; //define type
    public spellTypes spellType;   //define type
    public tomeElements tomeElement; //define element
    public tomeAdjectives tomeAdjective; //define adjective
    [Header("Magical Variables (Enchantments)")]
    [Space(10)]
    public talismanTypes talismanType; //define type
    public float artifactLevel; //what level is our artifact
    #endregion

    //this is where we define our consumable stuff//

    #region //Consumables Definition//
    //potions have a total of 9 possible essense combos, so in reality we only need 9 potions. Actual crafting will be taken care of in the crafting script
    public enum potionTypes { none, Healing, Speed, Power };
    public enum foodTypes { none, Fruit, Vegetable, Meat, Meal };
    public enum gearTypes { none, Rope, Torch, Bombs };

    [Header("Consumable Variables (General)")]
    [Space(10)]
    public float consumablePower; //strength of the consumable, how much does it heal? how filling is the food, how powerful is the potion
    public float consumableValue; //how much is this worth?

    [Header("Consumable Variables (Potions)")]
    [Space(10)]
    public potionTypes potionType;

    [Header("Consumable Variables (Potions)")]
    [Space(10)]
    public foodTypes foodType;

    [Header("Consumable Variables (Gear)")]
    [Space(10)]
    public gearTypes gearType;
    #endregion

    #endregion

    /* 
     * here's where we generate random item types, obviously there will be a lot of tweaking here,
     * but for now from the ground up I'm making it completely randomized
     * so that we can test for any inconsistencies, as everything is randomized,
     * but we have to define it all manually.
    */ 
 
    #region //Start//

    void Start()
    {
        
    }

    #endregion

    #region //Update//

    public bool valueDetermined = false; //has our item value been determined

    public void Update()
    {
        #region //Generation Bool Check//

        if (generateObject)
        {
            if (!hasChosenGeneration)
            GenerationDecide(); //decide what object to generate
        }

        if (!generateObject)
        {

        }
        #endregion

        //after the start void has happened, run the naming conventions
        ItemInfoDisplay();

        //get the material values of all the parts within out item
        SetMaterialAmounts();

        //after this run our item's value calculations
        DetermineItemValue();

        //for debugging
        if (Input.GetKeyDown("space"))
        {
            bool canGen = true;
            if (canGen) { GenerateItem(baseType); }
        }

        if (!valueDetermined)
        {
            if (generationComplete)
            {
                float tA = treasureAmount;
                float wA = woodAmount;
                float mtA = metalAmount;
                float mgA = magicAmount;
                float lwA = livingWoodAmount;
                float lmA = livingMetalAmount;
                float swA = studdedWoodAmount;
                float mwA = metalWoodAmount;
                float smA = studdedMetalAmount;
                float mgGA = magicGemsAmount;

                itemValue += (tA *= 3f); Debug.Log("Item Value is... " + itemValue);
                itemValue += (wA *= 1f); Debug.Log("Item Value is... " + itemValue);
                itemValue += (mtA *= 1f); Debug.Log("Item Value is... " + itemValue);
                itemValue += (mgA *= 1.4f); Debug.Log("Item Value is... " + itemValue);
                itemValue += (lwA *= 1.8f); Debug.Log("Item Value is... " + itemValue);
                itemValue += (lmA *= 1.9f); Debug.Log("Item Value is... " + itemValue);
                itemValue += (swA *= 4.1f); Debug.Log("Item Value is... " + itemValue);
                itemValue += (mwA *= 2.1f); Debug.Log("Item Value is... " + itemValue);
                itemValue += (smA *= 4.9f); Debug.Log("Item Value is... " + itemValue);
                itemValue += (mgGA *= 6f); Debug.Log("Item Value is... " + itemValue);
                itemValue += 1f; Debug.Log("Item Value is... " + itemValue);

                itemValue *= (int)itemQuality; Debug.Log("Final Item Value is... " + itemValue);
                valueDetermined = true;
            }
        }
    }

    #endregion

    [Space(10)]
    [Header("Generation Manager")]
    public bool generateObject;

    public bool canGenEquipment;
    public bool canGenMagic;
    public bool canGenConsumable;
    public bool canGenUnique;
    public bool hasChosenGeneration = false;  //have we generated anything?
    public bool generationComplete = false;

    public void GenerationDecide()
    {
        bool conflictE = false; bool conflictM = false; bool conflictC = false; bool conflictU = false; //are there any conflicts?

        int i; //get our variable that will be randomized
        i = Random.Range(1, 4); //choose a number between 1 and the highest type of item
        Debug.Log("Chose... " + i);
        if (!hasChosenGeneration)
        {
            #region //check for any conflicts in the item generation
            if ((i == 1) && (!canGenEquipment))
            { conflictE = true; i = Random.Range(1, 4); Debug.Log("conflictE Generation conflict reinitializing... " + i); }

            if ((i == 2) && (!canGenMagic))
            { conflictM = true; i = Random.Range(1, 4); Debug.Log("conflictM Generation conflict reinitializing... " + i); }

            if ((i == 3) && (!canGenConsumable))
            { conflictC = true; i = Random.Range(1, 4); Debug.Log("conflictC Generation conflict reinitializing... " + i); }

            if ((i == 4) && (!canGenUnique))
            { conflictU = true; i = Random.Range(1, 4); Debug.Log("conflictU Generation conflict reinitializing... " + i); }
            #endregion
        }
        //generate our item
        if ((!conflictE) && (!conflictC) && (!conflictM) && (!conflictU))
        { GenerateItem((baseTypes)i); hasChosenGeneration = true; Debug.Log("Has Generated!"); }
    }

    //generator based on the base type of item
    public void GenerateItem(baseTypes type)
    {
        //generate quality of item
        int quality = Random.Range(1, 14);
        itemQuality = (itemQualities)quality;

        //next choose our type of item and go from there
        if (type == baseTypes.equipment) //if our type is equiment
        {
            Debug.Log("Generating equipment...");
            int equipmentType = Random.Range(1, 4); //decide between armor, weapon, or shield. Low end is inclusive, high end is exclusive
            Debug.Log("chose " + equipmentType);
            baseType = baseTypes.equipment; //make sure we set out base item type to the proper setting based on what item we generate
            equipmentSubType = (equipmentSubTypes)equipmentType; //set our equipment subtype to equal the given type

            #region //Armor Sub Section//

            #region //armor generator//
            if (equipmentType == (int)equipmentSubTypes.armor)
            {
                Debug.Log("Generating Armor Piece...");
                int armorPieceInt = Random.Range(1, 4); //randomly select which armor piece this is going to be

                #region //generation for each armor piece...//
                //if it's a helmet//
                if (armorPieceInt == (int)armorPieces.Helmet)
                {
                    Debug.Log("Generating Helmet...");
                    //set our piece
                    armorPiece = armorPieces.Helmet;

                    //helmets consist of 3 parts, but make sure all 5 slots are full
                    armorPartsList[0] = new PartClass();
                    armorPartsList[1] = new PartClass();
                    armorPartsList[2] = new PartClass();
                    armorPartsList[3] = new PartClass();
                    armorPartsList[4] = new PartClass();
                    //change 3
                    armorPartsList[0].partSlotOne = (GameManager.materials)Random.Range(1, 10); //randomly select a material for part 0 to have
                    armorPartsList[1].partSlotOne = (GameManager.materials)Random.Range(1, 10); //randomly select a material for part 1 to have
                    armorPartsList[2].partSlotOne = (GameManager.materials)Random.Range(1, 10); //randomly select a material for part 2 to have
                }

                //if it's a chestplate//
                if (armorPieceInt == (int)armorPieces.Chestplate)
                {
                    Debug.Log("Generating Chestplate...");
                    //set our piece
                    armorPiece = armorPieces.Chestplate;
                    
                    //chestplates consist of 4 parts, but make sure all 5 slots are full
                    armorPartsList[0] = new PartClass();
                    armorPartsList[1] = new PartClass();
                    armorPartsList[2] = new PartClass();
                    armorPartsList[3] = new PartClass();
                    armorPartsList[4] = new PartClass();


                    armorPartsList[0].partSlotOne = (GameManager.materials)Random.Range(1, 10); //randomly select a material for part 0 to have
                    armorPartsList[1].partSlotOne = (GameManager.materials)Random.Range(1, 10); //randomly select a material for part 1 to have
                    armorPartsList[2].partSlotOne = (GameManager.materials)Random.Range(1, 10); //randomly select a material for part 2 to have
                    armorPartsList[3].partSlotOne = (GameManager.materials)Random.Range(1, 10); //randomly select a material for part 3 to have
                }

                //if it's a leggings//
                if (armorPieceInt == (int)armorPieces.Leggings)
                {
                    Debug.Log("Generating Leggings...");
                    //set our piece
                    armorPiece = armorPieces.Leggings;

                    //leggings consist of 3 parts, but make sure all 5 slots are full
                    armorPartsList[0] = new PartClass();
                    armorPartsList[1] = new PartClass();
                    armorPartsList[2] = new PartClass();
                    armorPartsList[3] = new PartClass();
                    armorPartsList[4] = new PartClass();
                    //change 3
                    armorPartsList[0].partSlotOne = (GameManager.materials)Random.Range(1, 10); //randomly select a material for part 0 to have
                    armorPartsList[1].partSlotOne = (GameManager.materials)Random.Range(1, 10); //randomly select a material for part 1 to have
                    armorPartsList[2].partSlotOne = (GameManager.materials)Random.Range(1, 10); //randomly select a material for part 2 to have
                }

                //if it's boots//
                if (armorPieceInt == (int)armorPieces.Boots)
                {
                    Debug.Log("Generating Boots...");
                    //set our piece
                    armorPiece = armorPieces.Boots;

                    //boots consist of 2 parts, but make sure all 5 slots are full
                    armorPartsList[0] = new PartClass();
                    armorPartsList[1] = new PartClass();
                    armorPartsList[2] = new PartClass();
                    armorPartsList[3] = new PartClass();
                    armorPartsList[4] = new PartClass();
                    //change 2
                    armorPartsList[0].partSlotOne = (GameManager.materials)Random.Range(1, 10); //randomly select a material for part 0 to have
                    armorPartsList[1].partSlotOne = (GameManager.materials)Random.Range(1, 10); //randomly select a material for part 1 to have
                }
                #endregion

                //after we make our armor piece, add those values into the definitions
                foreach (PartClass p in armorPartsList)
                {
                    p.Start();

                    itemDurability += p.durability;       Debug.Log("Durability calculated...");
                    itemValue += p.value;                 Debug.Log("Value calculated...");
                    equipmentMagicLevel += p.magic;       Debug.Log("Magic calculated...");
                    equipmentStrengthLevel += p.strength; Debug.Log("Strength calculated...");
                    //set our armor's weight
                    armorWeight = itemDurability + equipmentStrengthLevel; Debug.Log("Weight calculated...");
                    Debug.Log("Done!");
                }

            }
            #endregion

            //armor naming//
            if (equipmentSubType == equipmentSubTypes.armor)
            {
                string AdjectiveA = "UNSET.DEBUG"; //if an adjective is unnamed return that it is unset
                string AdjectiveB = "UNSET.DEBUG"; //if an adjective is unnamed return that it is unset
                string pieceName = armorPiece.ToString(); //which piece is it?

                #region //Adjective Definition//
                if ((equipmentStrengthLevel > itemDurability) && (equipmentStrengthLevel > equipmentMagicLevel))
                {
                    AdjectiveA = "Strong";

                    if (itemDurability > equipmentMagicLevel)
                    {
                        AdjectiveB = "Tough";
                    }

                    if (equipmentMagicLevel > itemDurability)
                    {
                        AdjectiveB = "Magical";
                    }

                    if (itemDurability == equipmentMagicLevel)
                    {
                        AdjectiveB = "Balanced";
                    }
                }

                if ((itemDurability > equipmentStrengthLevel) && (itemDurability > equipmentMagicLevel))
                {
                    AdjectiveA = "Hardened";

                    if (equipmentStrengthLevel > equipmentMagicLevel)
                    {
                        AdjectiveB = "Firm";
                    }

                    if (equipmentMagicLevel > equipmentStrengthLevel)
                    {
                        AdjectiveB = "Magical";
                    }

                    if (equipmentMagicLevel == equipmentStrengthLevel)
                    {
                        AdjectiveB = "Balanced";
                    }
                }

                if ((equipmentMagicLevel > equipmentStrengthLevel) && (equipmentMagicLevel > itemDurability))
                {
                    AdjectiveA = "Mystic";

                    if (equipmentStrengthLevel > itemDurability)
                    {
                        AdjectiveB = "Firm";
                    }

                    if (itemDurability > equipmentStrengthLevel)
                    {
                        AdjectiveB = "Tough";
                    }

                    if (itemDurability == equipmentStrengthLevel)
                    {
                        AdjectiveB = "Balanced";
                    }
                }

                if ((equipmentMagicLevel == equipmentStrengthLevel) || (equipmentStrengthLevel == itemDurability || itemDurability == equipmentMagicLevel))
                {
                    AdjectiveA = "Stable";

                    if (equipmentStrengthLevel > itemDurability)
                    {
                        AdjectiveB = "Firm";
                    }

                    if (itemDurability > equipmentStrengthLevel)
                    {
                        AdjectiveB = "Tough";
                    }

                    if (itemDurability == equipmentStrengthLevel)
                    {
                        AdjectiveB = "Balanced";
                    }

                    if (equipmentStrengthLevel > equipmentMagicLevel)
                    {
                        AdjectiveB = "Firm";
                    }

                    if (equipmentMagicLevel > equipmentStrengthLevel)
                    {
                        AdjectiveB = "Magical";
                    }

                    if (equipmentMagicLevel == equipmentStrengthLevel)
                    {
                        AdjectiveB = "Balanced";
                    }

                    if (itemDurability > equipmentMagicLevel)
                    {
                        AdjectiveB = "Tough";
                    }

                    if (equipmentMagicLevel > itemDurability)
                    {
                        AdjectiveB = "Magical";
                    }

                    if (itemDurability == equipmentMagicLevel)
                    {
                        AdjectiveB = "Balanced";
                    }

                }
                #endregion

                itemName = (AdjectiveA + " " + AdjectiveB + " " + pieceName);
            }

            #endregion

            #region //Weapon Sub Section//
            if (equipmentSubType == equipmentSubTypes.weapon)
            { 
                int localWeaponType = Random.Range(1, 5); //can be sword, axe, bow, spear, crossbow 

                if (localWeaponType == (int)weaponTypes.Sword)
                {
                    Debug.Log("Generating Sword...");
                    //set our weapon type to sword
                    weaponType = (weaponTypes)localWeaponType;
                    weaponClass = weaponClasses.Melee;
                    weaponWeight = weaponWeights.Medium; //all weapons have predetermined values for their weight class

                    //swords are consist of 4 parts, but make sure all 5 slots are full
                    weaponPartsList[0] = new PartClass();
                    weaponPartsList[1] = new PartClass();
                    weaponPartsList[2] = new PartClass();
                    weaponPartsList[3] = new PartClass();
                    weaponPartsList[4] = new PartClass();
                    //change 4
                    weaponPartsList[0].partSlotOne = (GameManager.materials)Random.Range(1, 10); //randomly select a material for part 0 to have
                    weaponPartsList[1].partSlotOne = (GameManager.materials)Random.Range(1, 10); //randomly select a material for part 1 to have
                    weaponPartsList[2].partSlotOne = (GameManager.materials)Random.Range(1, 10); //randomly select a material for part 2 to have
                    weaponPartsList[3].partSlotOne = (GameManager.materials)Random.Range(1, 10); //randomly select a material for part 3 to have
                }

                if (localWeaponType == (int)weaponTypes.Axe)
                {
                    Debug.Log("Generating Axe...");
                    //set our weapon type to axe
                    weaponType = (weaponTypes)localWeaponType;
                    weaponClass = weaponClasses.Melee;
                    weaponWeight = weaponWeights.Heavy; //all weapons have predetermined values for their weight class

                    //axes consist of 5 parts, but make sure all 5 slots are full
                    weaponPartsList[0] = new PartClass();
                    weaponPartsList[1] = new PartClass();
                    weaponPartsList[2] = new PartClass();
                    weaponPartsList[3] = new PartClass();
                    weaponPartsList[4] = new PartClass();
                    //change 5
                    weaponPartsList[0].partSlotOne = (GameManager.materials)Random.Range(1, 10); //randomly select a material for part 0 to have
                    weaponPartsList[1].partSlotOne = (GameManager.materials)Random.Range(1, 10); //randomly select a material for part 1 to have
                    weaponPartsList[2].partSlotOne = (GameManager.materials)Random.Range(1, 10); //randomly select a material for part 2 to have
                    weaponPartsList[3].partSlotOne = (GameManager.materials)Random.Range(1, 10); //randomly select a material for part 2 to have
                    weaponPartsList[4].partSlotOne = (GameManager.materials)Random.Range(1, 10); //randomly select a material for part 4 to have
                }

                if (localWeaponType == (int)weaponTypes.Bow)
                {
                    Debug.Log("Generating Bow...");
                    //set our weapon type to axe
                    weaponType = (weaponTypes)localWeaponType;
                    weaponClass = weaponClasses.Ranged;
                    weaponWeight = weaponWeights.Light; //all weapons have predetermined values for their weight class

                    //bows consist of 3 parts, but make sure all 5 slots are full
                    weaponPartsList[0] = new PartClass();
                    weaponPartsList[1] = new PartClass();
                    weaponPartsList[2] = new PartClass();
                    weaponPartsList[3] = new PartClass();
                    weaponPartsList[4] = new PartClass();
                    //change 3
                    weaponPartsList[0].partSlotOne = (GameManager.materials)Random.Range(1, 10); //randomly select a material for part 0 to have
                    weaponPartsList[1].partSlotOne = (GameManager.materials)Random.Range(1, 10); //randomly select a material for part 1 to have
                    weaponPartsList[2].partSlotOne = (GameManager.materials)Random.Range(1, 10); //randomly select a material for part 2 to have
                }

                if (localWeaponType == (int)weaponTypes.Spear)
                {
                    Debug.Log("Generating Spear...");
                    //set our weapon type to spear
                    weaponType = (weaponTypes)localWeaponType;
                    weaponClass = weaponClasses.Melee;
                    weaponWeight = weaponWeights.Light; //all weapons have predetermined values for their weight class

                    //spears consist of 3 parts, but make sure all 5 slots are full
                    weaponPartsList[0] = new PartClass();
                    weaponPartsList[1] = new PartClass();
                    weaponPartsList[2] = new PartClass();
                    weaponPartsList[3] = new PartClass();
                    weaponPartsList[4] = new PartClass();
                    //change 3
                    weaponPartsList[0].partSlotOne = (GameManager.materials)Random.Range(1, 10); //randomly select a material for part 0 to have
                    weaponPartsList[1].partSlotOne = (GameManager.materials)Random.Range(1, 10); //randomly select a material for part 1 to have
                    weaponPartsList[2].partSlotOne = (GameManager.materials)Random.Range(1, 10); //randomly select a material for part 2 to have
                }

                if (localWeaponType == (int)weaponTypes.Crossbow)
                {
                    Debug.Log("Generating Crossbow...");
                    //set our weapon type to crossbow
                    weaponType = (weaponTypes)localWeaponType;
                    weaponClass = weaponClasses.Ranged;
                    weaponWeight = weaponWeights.Heavy; //all weapons have predetermined values for their weight class

                    //crossbows consist of 5 parts, but make sure all 5 slots are full
                    weaponPartsList[0] = new PartClass();
                    weaponPartsList[1] = new PartClass();
                    weaponPartsList[2] = new PartClass();
                    weaponPartsList[3] = new PartClass();
                    weaponPartsList[4] = new PartClass();
                    //change 5
                    weaponPartsList[0].partSlotOne = (GameManager.materials)Random.Range(1, 10); //randomly select a material for part 0 to have
                    weaponPartsList[1].partSlotOne = (GameManager.materials)Random.Range(1, 10); //randomly select a material for part 1 to have
                    weaponPartsList[2].partSlotOne = (GameManager.materials)Random.Range(1, 10); //randomly select a material for part 2 to have
                    weaponPartsList[3].partSlotOne = (GameManager.materials)Random.Range(1, 10); //randomly select a material for part 2 to have
                    weaponPartsList[4].partSlotOne = (GameManager.materials)Random.Range(1, 10); //randomly select a material for part 2 to have
                }

                //after we make our armor piece, add those values into the definitions
                foreach (PartClass p in weaponPartsList)
                {
                    p.Start();

                    itemDurability += p.durability; Debug.Log("Durability calculated...");
                    itemValue += p.value; Debug.Log("Value calculated...");
                    equipmentMagicLevel += p.magic; Debug.Log("Magic calculated...");
                    equipmentStrengthLevel += p.strength; Debug.Log("Strength calculated...");
                    weaponDamage = equipmentStrengthLevel *= (int)itemQuality;
                    //set our armor's weight
                    armorWeight = itemDurability + equipmentStrengthLevel; Debug.Log("Weight calculated...");
                    Debug.Log("Done!");
                }

                //armor naming//
                if (equipmentSubType == equipmentSubTypes.weapon)
                {
                    string AdjectiveA = "UNSET.DEBUG"; //if an adjective is unnamed return that it is unset
                    string AdjectiveB = "UNSET.DEBUG"; //if an adjective is unnamed return that it is unset
                    string weaponName = weaponType.ToString(); //which piece is it?

                    #region //Adjective Definition//
                    if ((equipmentStrengthLevel > itemDurability) && (equipmentStrengthLevel > equipmentMagicLevel))
                    {
                        AdjectiveA = "Powerful";

                        if (itemDurability > equipmentMagicLevel)
                        {
                            AdjectiveB = "Sturdy";
                        }

                        if (equipmentMagicLevel > itemDurability)
                        {
                            AdjectiveB = "Mystic";
                        }

                        if (itemDurability == equipmentMagicLevel)
                        {
                            AdjectiveB = "Balanced";
                        }
                    }

                    if ((itemDurability > equipmentStrengthLevel) && (itemDurability > equipmentMagicLevel))
                    {
                        AdjectiveA = "Dependable";

                        if (equipmentStrengthLevel > equipmentMagicLevel)
                        {
                            AdjectiveB = "Firm";
                        }

                        if (equipmentMagicLevel > equipmentStrengthLevel)
                        {
                            AdjectiveB = "Magical";
                        }

                        if (equipmentMagicLevel == equipmentStrengthLevel)
                        {
                            AdjectiveB = "Balanced";
                        }
                    }

                    if ((equipmentMagicLevel > equipmentStrengthLevel) && (equipmentMagicLevel > itemDurability))
                    {
                        AdjectiveA = "Mystic";

                        if (equipmentStrengthLevel > itemDurability)
                        {
                            AdjectiveB = "Firm";
                        }

                        if (itemDurability > equipmentStrengthLevel)
                        {
                            AdjectiveB = "Tough";
                        }

                        if (itemDurability == equipmentStrengthLevel)
                        {
                            AdjectiveB = "Balanced";
                        }
                    }

                    if ((equipmentMagicLevel == equipmentStrengthLevel) || (equipmentStrengthLevel == itemDurability || itemDurability == equipmentMagicLevel))
                    {
                        AdjectiveA = "Stable";

                        if (equipmentStrengthLevel > itemDurability)
                        {
                            AdjectiveB = "Firm";
                        }

                        if (itemDurability > equipmentStrengthLevel)
                        {
                            AdjectiveB = "Tough";
                        }

                        if (itemDurability == equipmentStrengthLevel)
                        {
                            AdjectiveB = "Balanced";
                        }

                        if (equipmentStrengthLevel > equipmentMagicLevel)
                        {
                            AdjectiveB = "Firm";
                        }

                        if (equipmentMagicLevel > equipmentStrengthLevel)
                        {
                            AdjectiveB = "Magical";
                        }

                        if (equipmentMagicLevel == equipmentStrengthLevel)
                        {
                            AdjectiveB = "Balanced";
                        }

                        if (itemDurability > equipmentMagicLevel)
                        {
                            AdjectiveB = "Tough";
                        }

                        if (equipmentMagicLevel > itemDurability)
                        {
                            AdjectiveB = "Magical";
                        }

                        if (itemDurability == equipmentMagicLevel)
                        {
                            AdjectiveB = "Balanced";
                        }

                    }
                    #endregion

                    //name the weapon
                    itemName = (AdjectiveA + " " + AdjectiveB + " " + weaponName);
                }
            }
            #endregion

            #region //Shield Sub Section//
            if (equipmentSubType == equipmentSubTypes.shield)
            {
                int localShieldType = Random.Range(1, 5); //can be wood, leather, metal, studded or magic

                if (localShieldType == (int)shieldTypes.Wood)
                {
                    Debug.Log("Generating Wooden Shield...");
                    //set our weapon type to sword
                    shieldType = (shieldTypes)localShieldType;

                    //shields consist of 3 parts, but make sure all 5 slots are full
                    shieldPartsList[0] = new PartClass();
                    shieldPartsList[1] = new PartClass();
                    shieldPartsList[2] = new PartClass();
                   
                    //change 3
                    shieldPartsList[0].partSlotOne = (GameManager.materials)Random.Range(1, 10); //randomly select a material for part 2 to have
                    shieldPartsList[1].partSlotOne = (GameManager.materials)Random.Range(1, 10); //randomly select a material for part 2 to have
                    shieldPartsList[2].partSlotOne = (GameManager.materials)Random.Range(1, 10); //randomly select a material for part 2 to have
                }

                if (localShieldType == (int)shieldTypes.Leather)
                {
                    Debug.Log("Generating Leather Shield...");
                    //set our weapon type to sword
                    shieldType = (shieldTypes)localShieldType;

                    //shields consist of 3 parts, but make sure all 5 slots are full
                    shieldPartsList[0] = new PartClass();
                    shieldPartsList[1] = new PartClass();
                    shieldPartsList[2] = new PartClass();
                   
                    //change 3
                    shieldPartsList[0].partSlotOne = (GameManager.materials)Random.Range(1, 10); //randomly select a material for part 2 to have
                    shieldPartsList[1].partSlotOne = (GameManager.materials)Random.Range(1, 10); //randomly select a material for part 2 to have
                    shieldPartsList[2].partSlotOne = (GameManager.materials)Random.Range(1, 10); //randomly select a material for part 2 to have
                }

                if (localShieldType == (int)shieldTypes.Metal)
                {
                    Debug.Log("Generating Metal Shield...");
                    //set our shield type to be the local setting
                    shieldType = (shieldTypes)localShieldType;

                    //shields consist of 3 parts, but make sure all 5 slots are full
                    shieldPartsList[0] = new PartClass();
                    shieldPartsList[1] = new PartClass();
                    shieldPartsList[2] = new PartClass();
                   
                    //change 3
                    shieldPartsList[0].partSlotOne = (GameManager.materials)Random.Range(1, 10); //randomly select a material for part 2 to have
                    shieldPartsList[1].partSlotOne = (GameManager.materials)Random.Range(1, 10); //randomly select a material for part 2 to have
                    shieldPartsList[2].partSlotOne = (GameManager.materials)Random.Range(1, 10); //randomly select a material for part 2 to have
                }

                if (localShieldType == (int)shieldTypes.Studded)
                {
                    Debug.Log("Generating Metal Shield...");
                    //set our shield type to be the local setting
                    shieldType = (shieldTypes)localShieldType;

                    //shields consist of 3 parts, but make sure all 5 slots are full
                    shieldPartsList[0] = new PartClass();
                    shieldPartsList[1] = new PartClass();
                    shieldPartsList[2] = new PartClass();

                    //change 3
                    shieldPartsList[0].partSlotOne = (GameManager.materials)Random.Range(1, 10); //randomly select a material for part 2 to have
                    shieldPartsList[1].partSlotOne = (GameManager.materials)Random.Range(1, 10); //randomly select a material for part 2 to have
                    shieldPartsList[2].partSlotOne = (GameManager.materials)Random.Range(1, 10); //randomly select a material for part 2 to have
                }

                if (localShieldType == (int)shieldTypes.Magic)
                {
                    Debug.Log("Generating Metal Shield...");
                    //set our shield type to be the local setting
                    shieldType = (shieldTypes)localShieldType;

                    //shields consist of 3 parts, but make sure all 5 slots are full
                    shieldPartsList[0] = new PartClass();
                    shieldPartsList[1] = new PartClass();
                    shieldPartsList[2] = new PartClass();

                    //change 3
                    shieldPartsList[0].partSlotOne = (GameManager.materials)Random.Range(1, 10); //randomly select a material for part 2 to have
                    shieldPartsList[1].partSlotOne = (GameManager.materials)Random.Range(1, 10); //randomly select a material for part 2 to have
                    shieldPartsList[2].partSlotOne = (GameManager.materials)Random.Range(1, 10); //randomly select a material for part 2 to have
                }


                //after we make our armor piece, add those values into the definitions
                foreach (PartClass p in shieldPartsList)
                {
                    p.Start();

                    itemDurability += p.durability; Debug.Log("Durability calculated...");
                    itemValue += p.value; Debug.Log("Value calculated...");
                    equipmentMagicLevel += p.magic; Debug.Log("Magic calculated...");
                    equipmentStrengthLevel += p.strength; Debug.Log("Strength calculated...");
                    //set our armor's weight
                    armorWeight = itemDurability + equipmentStrengthLevel; Debug.Log("Weight calculated...");
                    Debug.Log("Done!");
                }

                //shield naming//
                if (equipmentSubType == equipmentSubTypes.shield)
                {
                    string AdjectiveA = "UNSET.DEBUG"; //if an adjective is unnamed return that it is unset
                    string AdjectiveB = "UNSET.DEBUG"; //if an adjective is unnamed return that it is unset
                    string shieldName = shieldType.ToString(); //which piece is it?

                    #region //Adjective Definition//
                    if ((equipmentStrengthLevel > itemDurability) && (equipmentStrengthLevel > equipmentMagicLevel))
                    {
                        AdjectiveA = "Powerful";

                        if (itemDurability > equipmentMagicLevel)
                        {
                            AdjectiveB = "Sturdy";
                        }

                        if (equipmentMagicLevel > itemDurability)
                        {
                            AdjectiveB = "Mystic";
                        }

                        if (itemDurability == equipmentMagicLevel)
                        {
                            AdjectiveB = "Balanced";
                        }
                    }

                    if ((itemDurability > equipmentStrengthLevel) && (itemDurability > equipmentMagicLevel))
                    {
                        AdjectiveA = "Dependable";

                        if (equipmentStrengthLevel > equipmentMagicLevel)
                        {
                            AdjectiveB = "Firm";
                        }

                        if (equipmentMagicLevel > equipmentStrengthLevel)
                        {
                            AdjectiveB = "Magical";
                        }

                        if (equipmentMagicLevel == equipmentStrengthLevel)
                        {
                            AdjectiveB = "Balanced";
                        }
                    }

                    if ((equipmentMagicLevel > equipmentStrengthLevel) && (equipmentMagicLevel > itemDurability))
                    {
                        AdjectiveA = "Mystic";

                        if (equipmentStrengthLevel > itemDurability)
                        {
                            AdjectiveB = "Firm";
                        }

                        if (itemDurability > equipmentStrengthLevel)
                        {
                            AdjectiveB = "Tough";
                        }

                        if (itemDurability == equipmentStrengthLevel)
                        {
                            AdjectiveB = "Balanced";
                        }
                    }

                    if ((equipmentMagicLevel == equipmentStrengthLevel) || (equipmentStrengthLevel == itemDurability || itemDurability == equipmentMagicLevel))
                    {
                        AdjectiveA = "Stable";

                        if (equipmentStrengthLevel > itemDurability)
                        {
                            AdjectiveB = "Firm";
                        }

                        if (itemDurability > equipmentStrengthLevel)
                        {
                            AdjectiveB = "Tough";
                        }

                        if (itemDurability == equipmentStrengthLevel)
                        {
                            AdjectiveB = "Balanced";
                        }

                        if (equipmentStrengthLevel > equipmentMagicLevel)
                        {
                            AdjectiveB = "Firm";
                        }

                        if (equipmentMagicLevel > equipmentStrengthLevel)
                        {
                            AdjectiveB = "Magical";
                        }

                        if (equipmentMagicLevel == equipmentStrengthLevel)
                        {
                            AdjectiveB = "Balanced";
                        }

                        if (itemDurability > equipmentMagicLevel)
                        {
                            AdjectiveB = "Tough";
                        }

                        if (equipmentMagicLevel > itemDurability)
                        {
                            AdjectiveB = "Magical";
                        }

                        if (itemDurability == equipmentMagicLevel)
                        {
                            AdjectiveB = "Balanced";
                        }

                    }
                    #endregion

                    //name the shield
                    itemName = (AdjectiveA + " " + AdjectiveB + " " + shieldName + " Shield");
                }
            }
            #endregion
        }

        generationComplete = true;
    }
}
