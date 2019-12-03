using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiatePrefab : MonoBehaviour
{
    public int secondsInterval; // how long are we waiting to spawn the new objects
    public GameObject prefabObject;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("SpawnObject");
    }

    IEnumerator SpawnObject()
    {
        while (true) // repeat it
        {
            Instantiate(prefabObject, transform.position, Quaternion.identity); // spawn the item
            Debug.Log("Spawned a new customer");
            yield return new WaitForSeconds(secondsInterval); // how long are we waiting
        }
    }
}
