using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildableHandler : MonoBehaviour
{
    // create a list of gameobjects that we can place
    public GameObject[] buildableObjects; // this will essentially be our hotbar
    public GameObject currentObject;      // this will be which object we have selected on the hotbar
    public int currentSelection;          // this will be the int indicator of the object on the hotbar
    public int lastSelection;
    public Vector2 mousePos;
    public GameManager gameManager;

    private void Start()
    {
        // get our game manager
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void Update()
    {
        if (gameManager.inBuildMode)
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); // get the mouse position from the camera
        }
        else
        {
            mousePos = new Vector2(0,200); // get the mouse position from the camera
        }

        transform.position = new Vector2(Mathf.Round(mousePos.x), Mathf.Round(mousePos.y)); // our position will be equal to the rounded position of the mouse


        // make sure we can never go outside the bounds of the objects we want to build with
        if (currentSelection > buildableObjects.Length-1)
        {
            currentSelection = 0;
        }

        if (currentSelection < 0)
        {
            currentSelection = buildableObjects.Length-1;
        }

        // when we scroll up and down cycle the hotbar
        currentSelection += (int)Input.mouseScrollDelta.y;
        if (currentSelection != lastSelection)
        {
            Destroy(currentObject);
            currentObject = Instantiate(buildableObjects[currentSelection], transform.position, Quaternion.identity);
            lastSelection = currentSelection;
        }

    }

    void ObjectFollow(int selection)
    {
        if (currentSelection == selection)
        {
            currentObject = Instantiate(buildableObjects[selection], transform.position, Quaternion.identity);
        }
    }
}
