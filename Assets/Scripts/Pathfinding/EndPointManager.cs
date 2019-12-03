using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPointManager : MonoBehaviour
{
    // the list containing our end points
    public List<Transform> endPointList;
    // the list of pathfinders that need to have their endpoint lists updated to the current one
    public List<PathfindingScript> pathFinders;
    // where is the shop entrance?
    public Transform shopEntrance; 
    // the update function for whenever we add a new point to our list so we can live update the pathfinding
    public void EndPointUpdate()
    {
        int count = 0;
        foreach (PathfindingScript pathfinder in pathFinders)
        {
            // update our end point list
            pathfinder.EndPointListUpdate();
            count++;

            if (count < pathFinders.Count)
            {
                EndPointUpdate();
            }
            else
            {
                Debug.Log("End Point List Updated.");
            }
        }
    }
}
