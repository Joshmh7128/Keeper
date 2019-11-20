using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathfinderScript : MonoBehaviour
{
    public PathfindingGrid pathfindingGrid;
    public PathfindingScript pathfindingManagerScript;

    public Vector3 targetPos;
    public int endPointInt;

    private void Start()
    {
        // add our starting position to the start pos list
        pathfindingManagerScript.StartPosition = transform;

        // figure out where we're going
        //endPointInt = Random.Range(0, pathfindingManagerScript.EndPoints.Length);
        //Debug.Log("End Points List is " + pathfindingManagerScript.EndPoints.Length + " points long. " + "Set end point to: " + endPointInt);
    }

    // Update is called once per frame
    void Update()
    {
        pathfindingManagerScript.endPointChoose = endPointInt;
        pathfindingGrid.showPath = endPointInt;
        // get our target position
        List<Node> FinalPath = pathfindingGrid.FinalPaths[endPointInt];
        targetPos = FinalPath[0].nodePos;
        transform.position = Vector3.MoveTowards(transform.position, targetPos, 0.025f);
    }
}
