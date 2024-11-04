using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEditor;

public class SlotScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Header("References")]
    public Image Icon;
    public TMP_Text Description;
    public Transform ReadHolder;

    public bool ReviewingObject;
    private bool mouseOver;

    private void Start()
    {
        //Description = TryGetComponent(TMP_Text);
    }

    public void EmptySlot()
    {
        Icon.enabled = false;
        Description.enabled = false;
    }

    public void CreateSlot(InventoryItemData WhatItem)
    {
        if (WhatItem == null)
        {
            EmptySlot();
            return;
        }

        Icon.enabled = true;

        Icon.sprite = WhatItem.itemdata.ItemIcon;
        Description.text = WhatItem.itemdata.ItemDescription;
    }

    private void Update()
    {
        mouseOver = Description.enabled ? false : true;

        if (Input.GetKeyDown(KeyCode.Escape) && ReviewingObject)
        {
            ReviewingObject = false;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        mouseOver = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        mouseOver = false;
    }
}
