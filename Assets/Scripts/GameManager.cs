using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    #region Crafting Definitions

    /*
     * this is our definite list of crafting materials, make sure that the game manager exists in the world and that this enum is active 
     * whenever debugging crafting issues.
    */

    public enum materials { none, wood, metal, magic, treasure, metalWood, livingWood, studdedWood, livingMetal, studdedMetal, magicGems };

    // hold all the info of the shop's availible items, if you plan on making multiple shops, make sure you have one array for each of them //

    #endregion

    #region Shop Activities and managements

    // this is where we manage the state of shop

    public bool isShopOpen; // is the shop open?
    public bool inBuildMode; // is the player in build mode?



    #region Shop Items

    // list of items we have for sale in our shop
    List<ItemClass> itemsForSale;


    #endregion

    #endregion

    // declared here so we can work with it in the UI section
    public Animator BuildingUI;

    private void Update()
    {
        // flip the player from regular mode to build mode
        if (Input.GetKeyDown("b"))
        {
            inBuildMode = !inBuildMode;
        }

        #region UI Management
        // any and all UI management happens here

        

        if (inBuildMode)
        {
            BuildingUI.Play("BuildingUIEnter");
        }
        else
        {
            BuildingUI.Play("BuildingUIExit");
        }

        #endregion
    }
}
