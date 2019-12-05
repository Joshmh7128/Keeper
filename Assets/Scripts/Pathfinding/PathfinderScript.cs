using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathfinderScript : MonoBehaviour
{
    public PathfindingGrid pathfindingGrid;
    public PathfindingScript pathfindingManagerScript;
    public GameObject ownLerp;
    public GameObject ownGrid;
    public GameObject ownParent;

    public Vector3 targetPos;
    public int endPointInt;
    public bool isLeaving;
    public float movementSpeed;

    private void Start()
    {
        // add our starting position to the start pos list
        pathfindingManagerScript.StartPosition = transform;
        isLeaving = false; // we're not leaving
        endPointInt = Random.Range(1, 4);
    }

    // Update is called once per frame
    void Update()
    {   // our pathfinding, runs once per tick when placed in the update
        pathfindingManagerScript.endPointChoose = endPointInt;
        pathfindingGrid.showPath = endPointInt;
        // get our target position
        List<Node> FinalPath = pathfindingGrid.FinalPaths[endPointInt];
        // check to see that the node exists
        if (FinalPath.Count > 0)
        {   // set our target path
            targetPos = FinalPath[0].nodePos;
        }
        else if (endPointInt == 0)
        {
            Debug.Log("Left the shop successfully");
            // clean up
            Destroy(ownLerp);
            Destroy(ownGrid);
            Destroy(ownParent);
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("No more nodes in path");
            //have it return to the shop entrance
            endPointInt = 0;
        }

        // move to our target pos
        transform.position = Vector3.MoveTowards(transform.position, targetPos, movementSpeed);

        // if we're leaving, go to the exit
        if (isLeaving) { endPointInt = 0; };
     }

    public void OnTriggerEnter2D(Collider2D col)
    {
        /*if (col.gameObject.tag == "EndPoint")
        {*/
            isLeaving = true;
            Debug.Log("Collision checked, returning to shop entrance.");
        //}
    }
}
