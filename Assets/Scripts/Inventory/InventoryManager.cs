using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InventoryManager : MonoBehaviour
{

    public List<InventoryItemData> InvItems = new List<InventoryItemData>();

    public InventoryCanvasScript InvCanvasScript;

    //private Dictionary<SO_InventoryItems, InventoryItemData> InvObjects;

    private void OnEnable()
    {
        DocumentPickUp.AddToInventory += Add;
    }
    private void OnDisable ()
    {
        DocumentPickUp.AddToInventory -= Add;
    }

    public void Add(SO_InventoryItems SOitem)
    {
        InventoryItemData addObj = new InventoryItemData(SOitem);
        InvItems.Add(addObj);

        InvCanvasScript.CreateInventory(InvItems);
    }
}
