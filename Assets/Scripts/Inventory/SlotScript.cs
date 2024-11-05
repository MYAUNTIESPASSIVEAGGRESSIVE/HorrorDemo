using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SlotScript : MonoBehaviour
{
    [Header("References")]
    public Image Icon;
    public TMP_Text Description;
    public Transform ReadHolder;
    public InventoryCanvasScript CanvasScript;

    [Header("Variables")]
    public bool ButtonPressed;

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
        Description.enabled = true;

        Icon.sprite = WhatItem.itemdata.ItemIcon;
        Description.text = WhatItem.itemdata.ItemDescription;
    }
}
