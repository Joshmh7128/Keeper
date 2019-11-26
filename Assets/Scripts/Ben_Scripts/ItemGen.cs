using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGen : MonoBehaviour
{
    public enum itemQualities {common, good, great, legendary};
    public itemQualities itemQuality;

    public enum itemTypes {shortRange, longRange, armor};
    public itemTypes itemType;

    public float itemValue;
    public TextMesh itemInfo;

    public float woodAmount;
    public float metalAmount;
    public float treasureAmount;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



}
