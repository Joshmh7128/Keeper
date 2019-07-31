using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildableScript : MonoBehaviour
{
    public bool canBreak;

    public void Update()
    {
        if ((canBreak) && (Input.GetMouseButtonDown(0)))
        {
            Destroy(gameObject);
        }
    }

    //use this to check whether or not the item can be interacted with in different ways
    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Breaker")
        {
            canBreak = true;
        }
    }

    public void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Breaker")
        {
            canBreak = false;
        }
    }

}
