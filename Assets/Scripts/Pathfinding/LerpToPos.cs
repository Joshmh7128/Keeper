using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpToPos : MonoBehaviour
{
    public Transform targetPos;
    public float lerpSpeed;

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, targetPos.position, lerpSpeed);
    }
}
