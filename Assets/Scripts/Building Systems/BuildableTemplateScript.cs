﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildableTemplateScript : MonoBehaviour
{
    public GameObject finalObject; //this is the object that the template will create a copy of
    public GameObject BuildCursor;
    public GameManager gameManager;
    public PathfindingGrid pathGrid;
    public Vector2 mousePos; //get our mouse position
    public bool canPlace = true;
    public bool isBreaker;

    private void Start()
    {
        BuildCursor = GameObject.Find("Building Mode Curor");
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        pathGrid = GameObject.Find("GameManager").GetComponent<PathfindingGrid>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.inBuildMode)
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); // get the mouse position from the camera
        }
        else
        {
            mousePos = new Vector2(0, 200); // get the mouse position from the camera
        }
        transform.position = new Vector2(Mathf.Round(mousePos.x), Mathf.Round(mousePos.y)); //our position will be equal to the rounded position of the mouse
        transform.rotation = Quaternion.Euler(0, 0, 0); // rotate the object 45 degress to match the isometrics

        //if there's nothing underneath the player, they can place the objects in the game world
        if ((Input.GetMouseButtonDown(0)) && (canPlace) && (gameManager.inBuildMode))
        {
            Instantiate(finalObject, transform.position, Quaternion.Euler(0,0,0));
            pathGrid.CreateGrid();
        }
    }

    public void OnTriggerStay2D(Collider2D col)
    {
        //if we are colliding with another buildable object, we can't build
        if ((col.tag == "Buildable") || (col.tag == "Player") || (col.tag == "NPC"))
        {
            canPlace = false;
        }
    }

    public void OnTriggerExit2D(Collider2D col)
    {
        //if we are colliding with another buildable object, we can't build
        if ((col.tag == "Buildable") || (col.tag == "Player") || (col.tag == "NPC")) 
        {
            canPlace = true;
            Debug.Log("canPlace = true");
        }
    }

}
