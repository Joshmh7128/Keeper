using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPointObject : MonoBehaviour
{
    public bool isEntrance;

    // Start is called before the first frame update
    void Start()
    {
        if (!isEntrance)
        {
            // add this object to the end point list upon it's creation
            GameObject.Find("EndPointManager").GetComponent<EndPointManager>().endPointList.Add(transform);
            // make sure everything knows we've updated the list of end points
            GameObject.Find("EndPointManager").GetComponent<EndPointManager>().EndPointUpdate();
        }
        else
        {   // if we're the entrance, add ourselves to the list of end point objects at the 0th point
            GameObject.Find("EndPointManager").GetComponent<EndPointManager>().endPointList.Insert(0, transform);
            // update our list
            GameObject.Find("EndPointManager").GetComponent<EndPointManager>().EndPointUpdate();
        }
    }
}
