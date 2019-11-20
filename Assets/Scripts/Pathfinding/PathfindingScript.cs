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
    }

    // run when a path is requested
    void FindPath(Vector3 a_StartPos, Vector3 a_TargetPos, int arrayInt)
    {
        Node StartNode = grid.NodeFromWorldPosition(a_StartPos);
        Node TargetNode = grid.NodeFromWorldPosition(a_TargetPos);

        List<Node> OpenList = new List<Node>();
        HashSet<Node> ClosedList = new HashSet<Node>();

        OpenList.Add(StartNode);

        while(OpenList.Count > 0)
        {
            Node CurrentNode = OpenList[0];
            for(int i = 1; i < OpenList.Count; i++)
            {
                if (OpenList[i].FCost < CurrentNode.FCost || OpenList[i].FCost == CurrentNode.FCost && OpenList[i].hCost < CurrentNode.hCost)
                {
                    CurrentNode = OpenList[i];
                }
            }

            OpenList.Remove(CurrentNode);
            ClosedList.Add(CurrentNode);

            if (CurrentNode == TargetNode)
            {
                GetFinalPath(StartNode, TargetNode, arrayInt);
                break;
            }

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
