using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilemapPathfinding : MonoBehaviour
{
	Grid _grid;

    // Start is called before the first frame update
    void Start()
    {
		_grid = FindObjectOfType<Grid>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
