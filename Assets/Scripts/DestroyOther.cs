using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOther : MonoBehaviour
{
    // destroy whatever touches this
    private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Destroying Object");
        Destroy(col.gameObject);
    }
}
