using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.VisualScripting;

public class InventoryManager : MonoBehaviour
{
    //lists and dictionarys
    public List<InventoryItemData> InvItems = new List<InventoryItemData>();
    // script references
    public InventoryCanvasScript InvCanvasScript;

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
