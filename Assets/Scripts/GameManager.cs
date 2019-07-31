using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    /*
     * this is our definite list of crafting materials, make sure that the game manager exists in the world and that this enum is active 
     * whenever debugging crafting issues.
    */

    public enum materials { none, wood, metal, magic, treasure, metalWood, livingWood, studdedWood, livingMetal, studdedMetal, magicGems };

    // hold all the info of the shop's availible items, if you plan on making multiple shops, make sure you have one array for each of them //

    public GameObject[] itemsForSale;

}
