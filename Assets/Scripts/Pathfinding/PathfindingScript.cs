﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathfindingScript : MonoBehaviour
{
    PathfindingGrid grid;
    public Transform StartPosition;
    public Transform TargetPosition;

    private void Awake()
    {
        grid = GetComponent<PathfindingGrid>();
    }

    private void Update()
    {
        FindPath(StartPosition.position, TargetPosition.position);
    }

    void FindPath(Vector3 a_StartPos, Vector3 a_TargetPos)
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
                GetFinalPath(StartNode, TargetNode);
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

    void GetFinalPath(Node a_StartingNode, Node a_EndNode)
    {
        List<Node> FinalPath = new List<Node>();
        Node CurrentNode = a_EndNode;

        while(CurrentNode != a_StartingNode)
        {
            FinalPath.Add(CurrentNode);
            CurrentNode = CurrentNode.Parent;
        }

        FinalPath.Reverse();

        grid.FinalPath = FinalPath;
    }

    int GetManhattenDistance(Node a_nodeA, Node a_nodeB)
    {
        int ix = Mathf.Abs(a_nodeA.gridX - a_nodeB.gridX);
        int iy = Mathf.Abs(a_nodeA.gridY - a_nodeB.gridY);
        return ix + iy;
    }



}
