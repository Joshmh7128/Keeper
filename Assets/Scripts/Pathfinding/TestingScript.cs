using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingScript : MonoBehaviour
{
    public GameObject gameManager;
    public Vector3 targetPos;

    private void Start()
    {   //get the gamemanager
        gameManager = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update()
    {   //get our target position
        targetPos = gameManager.GetComponent<PathfindingGrid>().FinalPath[0].nodePos;
        
        transform.position = Vector3.MoveTowards(transform.position, targetPos, 0.025f);
    }
}
