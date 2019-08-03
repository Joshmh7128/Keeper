using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildableTemplateScript : MonoBehaviour
{
    public GameObject finalObject; //this is the object that the template will create a copy of
    public Vector2 mousePos; //get our mouse position
    public bool canPlace = true;
    public bool isBreaker;

    // Update is called once per frame
    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); //get the mouse position from the camera
        transform.position = new Vector2(Mathf.Round(mousePos.x), Mathf.Round(mousePos.y)); //our position will be equal to the rounded position of the mouse

        //if there's nothing underneath the player, they can place the objects in the game world
        if ((Input.GetMouseButtonDown(0)) && (canPlace))
        {
            Instantiate(finalObject, transform.position, Quaternion.identity);
        }
    }


    public void OnTriggerStay2D(Collider2D col)
    {
        //if we are colliding with another buildable object, we can't build
        if (col.tag == "Buildable")
        {
            canPlace = false;
        }
    }

    public void OnTriggerExit2D(Collider2D col)
    {
        //if we are colliding with another buildable object, we can't build
        if (col.tag == "Buildable")
        {
            canPlace = true;
            Debug.Log("canPlace = true");
        }
    }

}
