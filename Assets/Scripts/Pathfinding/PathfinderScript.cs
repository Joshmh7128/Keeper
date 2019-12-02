using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathfinderScript : MonoBehaviour
{
    public PathfindingGrid pathfindingGrid;
    public PathfindingScript pathfindingManagerScript;

    public Vector3 targetPos;
    public int endPointInt;
    public bool isLeaving;

    private void Start()
    {
        // add our starting position to the start pos list
        pathfindingManagerScript.StartPosition = transform;
        isLeaving = false; // we're not leaving
    }

    // Update is called once per frame
    void Update()
    {
        if (!isLeaving)
        {
            pathfindingManagerScript.endPointChoose = endPointInt;
            pathfindingGrid.showPath = endPointInt;
            // get our target position
            List<Node> FinalPath = pathfindingGrid.FinalPaths[endPointInt];
            targetPos = FinalPath[0].nodePos;
            transform.position = Vector3.MoveTowards(transform.position, targetPos, 0.025f);
        }
        else
        {

        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "EndPoint")
        {
            isLeaving = true;

        }
    }
}
