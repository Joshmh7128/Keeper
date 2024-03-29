﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class ItemSlot : MonoBehaviour, IPointerClickHandler
{
    
    public Image image;

    private Item _item;

    public event Action<Item> OnRightClickEvent; 

    public Item Item
    {
        get {return _item;}
        set
        {
            _item = value;
            if (Item == null)
            {
                image.enabled = false;
            }
            else
            {
                image.sprite = _item.icon;
                image.enabled = true;
            }
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData != null && eventData.button == PointerEventData.InputButton.Right)
        {
            if (Item != null && OnRightClickEvent != null)
            {
                OnRightClickEvent(Item);
            }
        }
    }

    private void OnValidate()
    {
        if (image == null)
        {
            image = GetComponent<Image>();
        }
    }
}
