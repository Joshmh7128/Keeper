using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float playerSpeed;
    public Rigidbody2D playerRigidbody;
    public GameObject playerSprite;

    void Update()
    {
        // Movement //
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 1.0f);
        playerRigidbody.MovePosition(transform.position + movement * (Time.deltaTime * playerSpeed));

        // Move the Player's Sprite //
        playerSprite.transform.position = transform.position;

        // Face Mouse //
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        playerSprite.transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position);

    }
}
