﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{

    private Image image;

    public bool isColliding = false;
    //private bool selected;
    public Vector3 initialPos;

    private void Awake()
    {
        image = GetComponent<Image>();
        initialPos = transform.position;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        image.color = Color.green;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        image.color = Color.white;
        if (!isColliding)
        {
            transform.position = initialPos;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

    /*
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("part"))
        {
            isColliding = true;
            transform.position = Vector2.zero;

        }

    }*/

    private void Update()
    {
        /*
        if (selected == true)
        {
            Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector2(cursorPos.x, cursorPos.y);
        }

        if (Input.GetMouseButtonUp(0))
        {
            selected = false;
        }*/
    }

    /*
    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            selected = true;
        }
    }*/



}
