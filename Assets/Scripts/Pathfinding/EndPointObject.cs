﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPointObject : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // add this object to the end point list upon it's creation
        GameObject.Find("EndPointManager").GetComponent<EndPointManager>().endPointList.Add(transform);
        // make sure everything knows we've updated the list of end points
        GameObject.Find("EndPointManager").GetComponent<EndPointManager>().EndPointUpdate();
    }
}