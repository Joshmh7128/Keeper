using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeClass
{
    public int gridX; //our x pos in the array
    public int gridY; //our y pos in the array
    public bool IsWall; //is this a wall or not?
    public Vector3 nodePos; //the actual position of this node in the game world

    public NodeClass Parent; //for the astar algorith, will store what node it previously came from so it can trace the shortest path

    public int gCost; //the cost of moving to the next square
    public int hCost; //the distance to the goal from this node

    public int FCost { get { return gCost + hCost; } } //since we don't modify this we just add the g cost and h cost together

    public NodeClass(bool a_IsWall, Vector3 a_Pos, int a_gridX, int a_gridY) //node constructor
    {
        IsWall = a_IsWall; //is the node obstructed?
        nodePos = a_Pos;   //the world pos of the node
        gridX = a_gridX;   //x pos of node in array
        gridY = a_gridY;   //y pos of node in array
    }
}
