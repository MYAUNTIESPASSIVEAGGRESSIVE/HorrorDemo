using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SlotScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Header("References")]
    public Image Icon;
    public TMP_Text Description;

    private bool mouseOver;

    private void Start()
    {
        //Description = TMP_Text.Find
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
        if (mouseOver)
        {
            Description.enabled = true;
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
