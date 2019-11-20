using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathfindingScript : MonoBehaviour
{
    public PathfindingGrid grid;
    public Transform StartPosition;
    public List<Transform> EndPoints;
    public int endPointChoose;
    private EndPointManager EndPointManager;
    public PathfindingScript pathFindingScript;
    private void Start()
    {
        // grab the EndPointManager
        EndPointManager = GameObject.Find("EndPointManager").GetComponent<EndPointManager>();
        EndPoints = EndPointManager.endPointList;
        // get and set our end points of the room
        EndPointListUpdate();
        // add ourselves to the list of Pathfinders in the EndPointManager
        EndPointManager.pathFinders.Add(this);
    }

    public void EndPointListUpdate()
    {
        // fill the array of paths
        int count = 0; // to keep track of where we are in the loop
        foreach (Transform endPoint in EndPoints)
        {
            FindPath(StartPosition.position, EndPoints[count].position, count); // get our path, will also get final path
            count++; // starts at 0
            Debug.Log("Set count " + count);

            if (count < EndPoints.Count)
            { count = 0; }
        }
    }

    private void Update()
    { // live calculate ONE path at a time
        FindPath(StartPosition.position, EndPoints[endPointChoose].position, endPointChoose); // get our path, will also get final path
        // if this becomes too stressful, we can easily have this run once every X frames. That way it's far easier for the game to calculate.
    }

    // run when a path is requested
    void FindPath(Vector3 a_StartPos, Vector3 a_TargetPos, int arrayInt)
    {   // get our start node and our target node
        Node StartNode = grid.NodeFromWorldPosition(a_StartPos);
        Node TargetNode = grid.NodeFromWorldPosition(a_TargetPos);
        // create a new list of nodes that we'll add to
        List<Node> OpenList = new List<Node>();
        HashSet<Node> ClosedList = new HashSet<Node>(); // since we really only need to read the list of nodes that we'll be rejecting, we can make it a hashset
        // add our startnode to the path
        OpenList.Add(StartNode);
        // while our count is more than 0, continue to loop and add nodes to the list
        while(OpenList.Count > 0)
        {   // add our current node to the list and start pathfinding our route
            Node CurrentNode = OpenList[0];
            for(int i = 1; i < OpenList.Count; i++)
            {
                if (OpenList[i].FCost < CurrentNode.FCost || OpenList[i].FCost == CurrentNode.FCost && OpenList[i].hCost < CurrentNode.hCost)
                {
                    CurrentNode = OpenList[i];
                }
            }
            // remove our current node from the list, and add our next node
            OpenList.Remove(CurrentNode);
            ClosedList.Add(CurrentNode);

            if (CurrentNode == TargetNode)
            {
                GetFinalPath(StartNode, TargetNode, arrayInt);
                break;
            }
            // for every neighboring node in our path, check to see if it's a wall, then check to see if we've already been there
            foreach (Node NeighborNode in grid.GetNeighboringNodes(CurrentNode))
            {
                if (!NeighborNode.IsWall || ClosedList.Contains(NeighborNode))
                {
                    continue;
                }
                int MoveCost = CurrentNode.gCost + GetManhattenDistance(CurrentNode, NeighborNode);

                if (!OpenList.Contains(NeighborNode) || MoveCost < NeighborNode.FCost)
                {
                    NeighborNode.gCost = MoveCost;
                    NeighborNode.hCost = GetManhattenDistance(NeighborNode, TargetNode);
                    NeighborNode.Parent = CurrentNode;

                    if(!OpenList.Contains(NeighborNode))
                    {
                        OpenList.Add(NeighborNode);
                    }
                }
            }
        }
    }

    void GetFinalPath(Node a_StartingNode, Node a_EndNode, int arrayInt)
    {
        List<Node> FinalPath = new List<Node>();
        Node CurrentNode = a_EndNode;

        while(CurrentNode != a_StartingNode)
        {
            FinalPath.Add(CurrentNode);
            CurrentNode = CurrentNode.Parent;
        }

        FinalPath.Reverse();
        //Debug.Log("About to set arrayInt" + arrayInt);
        grid.FinalPaths[arrayInt] = FinalPath;
    }

    int GetManhattenDistance(Node a_nodeA, Node a_nodeB)
    {
        int ix = Mathf.Abs(a_nodeA.gridX - a_nodeB.gridX);
        int iy = Mathf.Abs(a_nodeA.gridY - a_nodeB.gridY);
        return ix + iy;
    }



}
