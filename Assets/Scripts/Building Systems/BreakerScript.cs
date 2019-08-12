using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakerScript : MonoBehaviour
{
    public Vector2 mousePos; //get our mouse position
    public GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
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
    }
}
